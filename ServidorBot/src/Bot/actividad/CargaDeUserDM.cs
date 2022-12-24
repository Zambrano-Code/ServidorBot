using System;
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
using MySqlX.XDevAPI;
using System.Reactive.Linq;
using ServidorBot.src.View.Dictionarys;
using System.Collections.ObjectModel;

namespace bot.actividad
{
    public class CargaDeUserDM : ObservableCollection<IDMChannel>
    {

        private configJson config = new configJson();

        private crudUserDM dbDMUser = new crudUserDM();

        public CargaDeUserDM()
        {
            cargarTabla();

        }
        public bool agregarDMUser(IDMChannel sUserDM)
        {
            int verif = dbDMUser.verificInTable(sUserDM.Id);
            if (verif == 1) { return false; }

            if (verif == 0)
            {
                bool vr = dbDMUser.insertRow(sUserDM);
                if (vr)
                {
                    Add(sUserDM);
                    Console.WriteLine("se agrego");
                    return true;

                }
                else { throw new EventsException("Error al agregar el usuari a la coleccion de mensajes directos", EventsException.ERROR_INSERT); }


            }
            else
            {
                throw new EventsException("Error al agregar el usuari a la coleccion de mensajes directos en la base de datos", EventsException.ERROR_INSERT);
            }


        }

        public bool verificarDMUser(ulong id)
        {
            foreach (var a in this.ToObservable())
            {
                if (a.Recipient.Id != id) continue;
                return true;
            }
            return false;
        }

        private void cargarTabla()
        {
            var temp = dbDMUser.getTable().AsEnumerable();
            if (temp != null)
            {
                foreach(var item in dbDMUser.getTable().AsEnumerable())
                {
                    Add(item);
                }
                return;
            }

            if (dbDMUser.createTable()) Console.WriteLine($"Se acaba de crear la tabla 'userdm' con exito.");
            else throw new Exception("No se pudo obtener datos de la tabla, ni crear la tabla. (CargaDeUserDM.cs - cargarTabla())");
        }


    }
}
