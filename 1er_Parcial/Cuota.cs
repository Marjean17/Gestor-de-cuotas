using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    public class Cuota
    {

        public string Legajo { get; set; }
        public int IdCuota { get; private set; } //lo generarmos desde esta la clase por lo que deshabilitamos el set
        public DateTime PeriodoDeCuota { get; set; }
        public DateTime FechaDePago { get; set; }
        public decimal ImporteCuota { get; set; }
        public decimal ImporteBecas { get; set; }
        public decimal Beneficio { get; set; }
        public decimal APagar { get; set; }
        public bool Paga { get; set; }

        //definimos un listado de números únicos y una variable para el valor random
        private static readonly HashSet<int> IdUsados = new HashSet<int>();
        private static readonly Random Random = new Random();

        //la fecha de pago será inicializada para que sea a los 36 dias posteriores
        //a la emisión aunque será modificada por la efectiva  
        public Cuota(string legajo, DateTime periodoDeCuota, decimal importeCuota)
        {
            Legajo = legajo;
            IdCuota = GenerarID();
            PeriodoDeCuota = periodoDeCuota;
            FechaDePago = PeriodoDeCuota.AddDays(36);
            ImporteCuota = importeCuota;
        }
        //generamos un valor mientras cada nro generado esté en la lista 
        //de los ID usados, cuando tengamos uno único lo agregamos en 
        //dicha lista y lo retornamos para su único uso
        private static int GenerarID()
        {
            int valor;
            do
            {
                valor = Random.Next(1, 10000);
            } while (IdUsados.Contains(valor));
            IdUsados.Add(valor);
            return valor;
        }  

    }
}
