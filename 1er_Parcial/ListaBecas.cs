using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1er_Parcial
{
    internal class ListaBecas
    {
        public List<Beca> Becas;
        public ListaBecas()
        {
            Becas = new List<Beca>(); //instanciasmos una lista del tipo Beca
        }

        public void AgregarBeca(Beca beca) //agregamos una beca
        {
            Becas.Add(beca);
        }

        public Beca ObtenerBecaPorCodigo(string Codigo) //buscamos por el código y retornamos la beca que coincida
        {
            return Becas.Find(beca => beca.Codigo == Codigo);
        }

        public void ModificarBeca(Beca becaSeleccionada) //retornamos una beca modificada
        {
            Beca becaModificada = Becas.Find(beca => beca.Codigo == becaSeleccionada.Codigo);
        }

        public void EliminarBecaPorCodigo(string Codigo) //Eliminamos una baca mediante el método remove luego de encontrarla
        {
            var becaAEliminar = Becas.Find(beca => beca.Codigo == Codigo);
            if (becaAEliminar != null)
            {
                Becas.Remove(becaAEliminar);
            }
            else
            {
                throw new Exception("No se encontró ninguna beca con el codigo especificado.");
            }
        }

        public bool ExisteBeca(string codigo) // retornamos un booleano para confirmar si existe la beca
        {
            return Becas.Exists(beca => beca.Codigo == codigo);
        }

        public bool validarCodigo(string codigo)
        {
            try
            {
                // Definimos la expresión regular para validar 2 decimales y 2 letras (mayusculas o minúsculas)
                string pattern = @"^\d{2}[a-zA-Z]{2}$";
                Regex regex = new Regex(pattern);
                                
                return regex.IsMatch(codigo); // Validamos el ingreso al TextBox
            }
            catch (Exception ex)
            {
                return false; // retornamos false si no se cumplió lo requerido
            }
        }
    }
}
