using _1er_Parcial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{  

    internal class ListaAlumnos
    {
        public List<Alumno> Alumnos;

        public ListaAlumnos()
        {
            Alumnos = new List<Alumno>(); //instanciamos la lista tipo Alumno
        }

        public void AgregarAlumno(Alumno alumno) //usamos el método add para agregar uno nuevo
        {
            Alumnos.Add(alumno);
        }

        public Alumno ObtenerAlumnoPorLegajo(string Legajo) //buscamos el slumno la lista por legajo
        {
            return Alumnos.Find(alumno => alumno.Legajo == Legajo);
        }

        public void ModificarAlumno(Alumno alumnoSeleccionado)
        {
            Alumno alumnoModificado = Alumnos.Find(alumno => alumno.Legajo == alumnoSeleccionado.Legajo);
        }                               //retornamos el alumno modificado

        public void EliminarAlumnoPorLegajo(string Legajo) //Eliminamos por legajo
        {
            var alumnoAEliminar = Alumnos.Find(alumno => alumno.Legajo == Legajo);
            if (alumnoAEliminar != null)
            {
                Alumnos.Remove(alumnoAEliminar);
            }
            else
            {
                throw new Exception("No se encontró ningún alumno con el Legajo especificado.");
            }
        }

        public bool ExisteLegajo(string Legajo) //retornamos un booleano segun exista o no por legajo 
        {
            return Alumnos.Exists(alumno => alumno.Legajo == Legajo);
        }
        public bool ExisteDNI(string DNI)  //o por DNI
        {
            return Alumnos.Exists(alumno => alumno.DNI == DNI);
        }


        public bool BecaYaAsignada(DataGridViewRow selectedRow, DataGridView dataGridView)
        {
            // Obtenemos el codigo de la beca seleccionada
            string codigoSeleccionado = selectedRow.Cells["Codigo"].Value.ToString();

            // Recorremos todos los alumnos en la lista de alumnos
            foreach (var alumno in Alumnos)
            {
                // Verificamos si el alumno tiene becas asignadas
                if (alumno.BecasEnAlumno.Count > 0)
                {
                    // Recorrer las posibles dos becas asignadas al alumno
                    foreach (var beca in alumno.BecasEnAlumno)
                    {
                        // Comparar el codigo del alumno asignado con el codigo de la beca seleccionada
                        if (beca.Codigo == codigoSeleccionado)
                        {
                            // Si los codigos coinciden, la beca ya está asignada a otra persona
                            return true;
                        }
                    }
                }
            }
            return false; //si no está asignada retornamos false
        }

        public bool TieneNumeros(string texto) //verificamos si un caracter se puede convertir a número para validar
        {
            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}


