using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    internal class ListaCuotas
    {

        public List<Cuota> Cuotas;

        public ListaCuotas()
        {
            Cuotas = new List<Cuota>();
        }

        public Cuota ObtenerCuotaPorID(int IdCuota) //obtenemos la cuota por su ID
        {
            return Cuotas.Find(cuota => cuota.IdCuota == IdCuota);
        }
        public Cuota ObtenerCuotaPorLeg(string Legajo)//obtenemos la cuota por su legajo que nos servirá
                                                      //para relacionarlas con el alumno sobre el que sea generada
        {
            return Cuotas.Find(cuota => cuota.Legajo == Legajo);
        }
        public void ModificarCuota(Cuota cuotaSeleccionada) //retornamos la cuota modificada
        {
            Cuota cuotaModificada = Cuotas.Find(cuota => cuota.IdCuota == cuotaSeleccionada.IdCuota);
        }

        public bool CuotaYaEmitida(Alumno alumno, DateTime periodoSeleccionado)
        {

            // Verificamos si el alumno tiene cuotas emitidas
            if (alumno.CuotasEnAlumno.Count > 0)
            {
                // Recorremos las cuotas emitidas al alumno
                foreach (var cuota in alumno.CuotasEnAlumno)
                {
                    // Comparamos los periodos de todas las cuotas del alumno contra el elegido
                    if (cuota.PeriodoDeCuota == periodoSeleccionado)
                    {
                        // Si coinciden, la cuota ya está generada
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
