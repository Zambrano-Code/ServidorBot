﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


using bot.acciones;
using Discord;
using Discord.WebSocket;
using bot.funciones;
using bot.mysql;
using bot.Exceptions;

namespace bot.actividad
{
    public class CargaDeEvento
    {
        private Dictionary<int, MensageRepetitive> collecionMensageRepetitive;

        private configJson config = new configJson();

        private crudEvento dbEvents = new crudEvento();

        public CargaDeEvento()
        {
            
            cargarTabla();
            activarEventos();


        }

        public int agregarMRepetitivo(MensageRepetitive mensageR)
        {

            // 1 si se agrego correctamente
            // 0 si el dato name ya esta registrado
            // -1 si ocurrio un error al agregar a la base de datos
            // -2 Si ubo un error al verificar en la base de datos el name

            int vrf_row = dbEvents.verificInTable(mensageR.name);

            if (vrf_row == 1)
            {
                return 0;
            }
            else if(vrf_row == 0)
            {

                bool vr = dbEvents.insertRow(mensageR);
                if (vr)
                {
                    int id = dbEvents.obtenerIdForName(mensageR.name);
                    collecionMensageRepetitive.Add(id, mensageR);
                    return 1;

                }
                else { return -1; }


            }else
            {
                return -2;
            }


        }

        public bool deleteMRepetitivo(int id)
        {

            bool vr = dbEvents.deleteRow(id);
            if(vr)
            {
                var tempEvent = collecionMensageRepetitive[id];
                tempEvent.Stop();

                collecionMensageRepetitive.Remove(id);
                return true;
            }
            else
                return false;
        }

        public bool updateMRepetitivo(int id, MensageRepetitive mensageR)
        {
            bool vr = dbEvents.updateRow(mensageR);

            if (vr)
            {
                var tempEvent = collecionMensageRepetitive[id];
                tempEvent.Stop();

                collecionMensageRepetitive[id] = mensageR;

                return true;
            }
            else return false;

        }

        private void cargarTabla()
        {
            try
            {
                collecionMensageRepetitive = dbEvents.getTable();

            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1146)
                {
                    if(dbEvents.createTable()) Console.WriteLine($"Se acaba de crear la tabla events con exito.");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void activarEventos()
        {
            foreach(var element in collecionMensageRepetitive)
            {
                element.Value.Star();
            }
        }

        public void pararEventos()
        {
            foreach (var element in collecionMensageRepetitive)
            {
                element.Value.Stop();
            }
        }

        public Dictionary<int, MensageRepetitive> get() { return collecionMensageRepetitive; }
    }
}