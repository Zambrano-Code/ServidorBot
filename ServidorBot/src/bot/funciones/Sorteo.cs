using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.funciones
{
    public class Sorteo
    {
        public List<string> miembros { get; private set; }
        public int cantGanadores { get; private set; }
        public int cantEliminados { get; private set; }
        public Sorteo(List<string> miembros, int cantGanadores, int cantEliminados)
        {
            this.miembros = miembros;
            this.cantGanadores = cantGanadores;
            this.cantEliminados = cantEliminados;
        }

        private void eliminarPlayer(string player)
        {
            miembros.Remove(player);
        }

        public string obtMemberRandom()
        {
            Random random = new Random();

            int count = miembros.Count;

            int mrI = random.Next(count);

            string mrS = miembros[mrI];

            miembros.Remove(mrS);

            return mrS;
        }

    }
}
