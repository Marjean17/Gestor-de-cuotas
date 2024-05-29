using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    public class BecaEventArgs : EventArgs  //creamos la clase del tipo EventArgs para pasar los argumentos personalizados
    {
        public Alumno Alumno { get; }
        public decimal Cuota { get; }
        public decimal TotalBecas { get; }

        public BecaEventArgs(Alumno alumno, decimal cuota, decimal totalBecas)
        {
            Alumno = alumno;
            Cuota = cuota;
            TotalBecas = totalBecas;
        }
    }
}
