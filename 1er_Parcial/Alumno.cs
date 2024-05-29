using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    public class Alumno : Persona
    {
        public string Legajo { get; set; } //Heredaremos de Persona Nombre, Apellido y DNI 
        public string Condicion { get; set; }
        public List<Beca> BecasEnAlumno { get; set; }
        public List<Cuota> CuotasEnAlumno { get; set; }

        public Alumno(string legajo, string nombre, string apellido, string dni, string condicion)
        {
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Condicion = condicion;
            BecasEnAlumno = new List<Beca>();
            CuotasEnAlumno = new List<Cuota>();
        }

        //método destructor (no se requiere llamarlo pero sirve para ver su funcionamiento)
        ~Alumno()
        {
            MessageBox.Show($"El titular del {Environment.NewLine}" +
                           $"DNI: {DNI}{Environment.NewLine}" +
                           $"Fue dado de baja...");
        }
    }
}
