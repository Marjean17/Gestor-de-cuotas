using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    public class Beca
    {
        public string Codigo { get; set; }
        public decimal ImporteBeca { get; set; }
        public DateTime FechaOtorgamiento { get; set; }

        public Beca(string codigo, decimal importeBeca)
        {
            Codigo = codigo;
            ImporteBeca = importeBeca;
        }

        //método destructor (no se requiere llamarlo pero sirve para ver su funcionamiento)
        ~Beca()
        {
            MessageBox.Show($"La beca con {Environment.NewLine}" +
                           $"Codigo: {Codigo}{Environment.NewLine}" +
                           $"Fue dada de baja...");
        }

    }
}
