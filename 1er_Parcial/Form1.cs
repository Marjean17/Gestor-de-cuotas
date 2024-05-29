using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using _1er_Parcial;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1er_Parcial
{
    public partial class Form1 : Form
    {
        private ListaAlumnos listaAlumnos;
        private Alumno alumnoSeleccionado; // Almacenaremos el alumno seleccionado en el DataGridView
        private ListaBecas listaBecas;
        private Beca becaSeleccionada; // Almacenaremos la beca seleccionada en el DataGridView
        private ListaCuotas listaCuotas;
        private Cuota cuotaSeleccionada; // Almacenaremos la cuota seleccionada en el DataGridView

        public event EventHandler<BecaEventArgs> BecaSuperaCuota;

        public Form1()
        {
            InitializeComponent();
            BecaSuperaCuota += OnBecaSuperaCuota; //Suscribimos el evento con argumentos personalizados
  
            listaAlumnos = new ListaAlumnos(); //instanciamos los objetos del tipo lista
            listaBecas = new ListaBecas();
            listaCuotas = new ListaCuotas();

            alumnoSeleccionado = null; // Inicializamos las variables como nulas al inicio
            becaSeleccionada = null; 
            cuotaSeleccionada = null;

            #region"Declaración de columnas" 
            //declaramos el nombre relacionado con los datos y luego el nombre que mostraremos para cada fila
            dataGAlum.Columns.Add("Legajo", "Legajo");
            dataGAlum.Columns.Add("Nombre", "Nombre");
            dataGAlum.Columns.Add("Apellido", "Apellido");
            dataGAlum.Columns.Add("DNI", "DNI");
                       
            dataGBecas.Columns.Add("Codigo", "Codigo");
            dataGBecas.Columns.Add("FechaOtorgamiento", "Fecha de Otorgamiento");
            dataGBecas.Columns.Add("ImporteBeca", "Importe");

            dataGBecasEnAlum.Columns.Add("Codigo", "Codigo");
            dataGBecasEnAlum.Columns.Add("FechaOtorgamiento", "Fecha de Otorgamiento");
            dataGBecasEnAlum.Columns.Add("ImporteBeca", "Importe");
                        
            dataGCuotaImpaga.Columns.Add("IdCuota", "ID");
            dataGCuotaImpaga.Columns.Add("PeriodoDeCuota", "Mes / Año");
            dataGCuotaImpaga.Columns.Add("ImporteCuota", "Importe Cuota");

            dataGCuotaPaga.Columns.Add("IdCuota", "ID");
            dataGCuotaPaga.Columns.Add("PeriodoDeCuota", "Mes / Año");
            dataGCuotaPaga.Columns.Add("FechaDePago", "Fecha de Pago");
            dataGCuotaPaga.Columns.Add("ImporteCuota", "Importe Cuota");
            dataGCuotaPaga.Columns.Add("ImporteBecas", "Importe Beca");
            dataGCuotaPaga.Columns.Add("Beneficio", "Beneficio");
            dataGCuotaPaga.Columns.Add("aPagar", "Neto a pagar");

            #endregion
        }

        #region"Form loader" 

        private decimal ultimaCuota;
        private void Form1_Load(object sender, EventArgs e)
        {
            bool inputValido = false;
            do
            {
                try
                {
                    string inputValue = Interaction.InputBox("Ingrese el valor actual de la cuota", "Ingreso de cuota actual");
                    //validamos viendo si esta vacio o si no se puede parsear a decimal o si pudiendose parsear es menor a 0
                    if (string.IsNullOrEmpty(inputValue) || !(decimal.TryParse(inputValue, out decimal ImporteCuota) && ImporteCuota > 0))
                    {
                        throw new Exception("El valor de la cuota actual debe ser un número positivo");
                    }

                    textBImpActual.Text = inputValue;
                    inputValido = true; // Si todo es correcto, salimos del bucle
                                        // lo almacenamos y lo mostramos en el texBox. 
                }                       // Evitaremos luego que se ingresen cuotas por menor valor
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            while (!inputValido);

        }
        #endregion

        #region"Alumnos"

        private void btnAltaAlu_Click(object sender, EventArgs e) //Creamos un objeto Alumno
        {
            try
            {
                string legajo = textBLeg.Text;
                string DNI = textBDNI.Text;
                if (listaAlumnos.ExisteLegajo(legajo))
                {
                    throw new Exception("El Legajo ingresado ya está registrado.");
                } //evitamos que alguno de los campos esté vacio
                if (string.IsNullOrEmpty(textBLeg.Text) || string.IsNullOrEmpty(textBNom.Text) ||
                    string.IsNullOrEmpty(textBApe.Text) || string.IsNullOrEmpty(textBDNI.Text))
                {
                    throw new Exception("Todos los campos deben ser completados.");
                }
                if (listaAlumnos.TieneNumeros(textBNom.Text) || listaAlumnos.TieneNumeros(textBApe.Text))
                {  //validamos que los ingresos no sean numéricos
                    throw new Exception("El Nombre y Apellido no deben contener números.");
                }  //utilizamos el método para ver si ya se encuentra una persona con dicho DNI
                if (listaAlumnos.ExisteDNI(DNI))
                { 
                    throw new Exception("El DNI ingresado ya está registrado.");
                }   //validamos que legajo y DNI se pueda parsear y sean positivos
                if (!(decimal.TryParse(textBLeg.Text, out decimal leg) && leg > 0) ||
                    !(decimal.TryParse(textBDNI.Text, out decimal dni) && dni > 0))
                {
                    throw new Exception("El Legajo y DNI esta conformado solo por números positivos.");
                }
                //Instanciamos un alumno a partir de los ingresos y del radio button seleccionado el que tomamos de método
                Alumno alumno = new Alumno(textBLeg.Text, textBNom.Text, textBApe.Text, textBDNI.Text, ObtenerCondicion());
                listaAlumnos.AgregarAlumno(alumno);
                dataGAlum.Rows.Add(alumno.Legajo, alumno.Nombre, alumno.Apellido, alumno.DNI, alumno.Condicion);
                //finalmente poblamos la grilla correspondiente con el alumno instanciado
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModAlu_Click(object sender, EventArgs e) //modificamos un objeto Alumno
        {
            // Actualizamos los datos del alumno seleccionado
            alumnoSeleccionado.Nombre = textBNom.Text;
            alumnoSeleccionado.Apellido = textBApe.Text;
            alumnoSeleccionado.DNI = textBDNI.Text;
            alumnoSeleccionado.Condicion = ObtenerCondicion();

            // Actualizamos la fila en el DataGridView
            int rowIndex = dataGAlum.SelectedRows[0].Index;
            dataGAlum.Rows[rowIndex].SetValues(alumnoSeleccionado.Legajo, alumnoSeleccionado.Nombre, alumnoSeleccionado.Apellido, alumnoSeleccionado.DNI);

            // Actualizamos la lista de alumnos
            listaAlumnos.ModificarAlumno(alumnoSeleccionado);
            dataGAlum.Refresh();
            ActualizaGCuotaPaga();
        }

        private void btnBajaAlu_Click(object sender, EventArgs e) //eliminamos un objeto Alumno
        {
            //   Persona alumnoSeleccionado = new Persona(dataGPers.SelectedRows[0].DataBoundItem);

            if (alumnoSeleccionado != null)
            {
                listaAlumnos.EliminarAlumnoPorLegajo(alumnoSeleccionado.Legajo);
                alumnoSeleccionado = null; // Liberar la persona seleccionada
                GC.Collect(); // Llamamos al recolector de basura
                ActualizaGAlum();
                ActualizaGBecasEnA();
                ActualizaGCuotaPaga();
            }
        }

        #endregion

        #region"Becas"


        private void btnAltaBeca_Click(object sender, EventArgs e) //Creamos un objeto Beca
        {
            try
            {   //previamente realizamos las validaciones para capturar las excepciones en forma personalizada
                if (alumnoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un alumno antes de crear una beca.");
                }
                string codigoIngresado = textBCod.Text;

                if (listaBecas.ExisteBeca(codigoIngresado))
                {
                    throw new Exception("El código ingresado ya está registrado.");
                }
                if (!listaBecas.validarCodigo(codigoIngresado))
                {
                    throw new Exception("El código ingresado debe estar compuesto por dos números seguidos de dos letras.");
                }
                if (string.IsNullOrEmpty(textBImporteBeca.Text) ||
                    !(decimal.TryParse(textBImporteBeca.Text, out decimal imp) && imp > 0))
                {
                    throw new Exception("El importe de la beca tiene que ser un número y debe estar completo.");
                }
                if (alumnoSeleccionado.BecasEnAlumno.Count >= 2)
                {
                    throw new Exception("Se pueden tener hasta 2 becas por alumno.");
                }

                decimal ImporteBeca = Convert.ToDecimal(textBImporteBeca.Text); //Almacenamos el monto de la beca pretendida
                                                                                 //y le sumamos la posible suma ya becada 
                decimal valorTotalBecas = alumnoSeleccionado.BecasEnAlumno.Sum(beca => beca.ImporteBeca) + ImporteBeca;
                decimal cuotaActual = Convert.ToDecimal(textBImpActual.Text);



                if (valorTotalBecas > cuotaActual) //si al comparar lo becado supera la cuota disparamos el evento  
                {                                  // con los argumentos personalizados cuotaActual y valorTotalBecas
                    BecaSuperaCuota?.Invoke(this, new BecaEventArgs(alumnoSeleccionado, cuotaActual, valorTotalBecas));
                    return;
                }


                Beca beca = new Beca(codigoIngresado, ImporteBeca); //pasadas las validaciones instanciamos el objeto Beca
                beca.FechaOtorgamiento = DateTime.Now.Date;          //y le asignamos fecha de otorgamiento
                listaBecas.AgregarBeca(beca);                       //la agregamos a la lista 
                alumnoSeleccionado.BecasEnAlumno.Add(beca);
                becaSeleccionada = beca; // Asignamos la beca creada como seleccionada

                dataGBecas.Rows.Add(beca.Codigo, beca.FechaOtorgamiento.ToString("dd/MM/yyyy"), beca.ImporteBeca);

                ActualizaGBecasEnA(); //eliminamos los registros y repoblamos las grillas
                ActualizaValorBecasEnA();
                ActualizaGCuotaPaga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModBeca_Click(object sender, EventArgs e) //modificamos un objeto del tipo Beca (que no se encuentre asignada)
        {
            try
            {       //realizamos todas las validaciones
                string codigoIngresado = textBCod.Text;
                if (becaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar la beca a modificar.");
                }
                if (!listaBecas.validarCodigo(codigoIngresado))
                {   //usamos el método creado al efecto
                    throw new Exception("El codigo ingresado debe estar compuesto por dos números seguidos de dos letras.");
                }
                if (listaAlumnos.BecaYaAsignada(dataGBecas.SelectedRows[0], dataGBecasEnAlum))
                {   //usamos un método que recibe la fila seleccionada del datagridview solicitado y retorna true o false
                    throw new Exception("Las becas asignadas no se pueden modificar.");
                }

                // Actualizamos los datos de la beca seleccionada
                becaSeleccionada.Codigo = codigoIngresado;
                becaSeleccionada.ImporteBeca = Convert.ToDecimal(textBImporteBeca.Text);

                // Actualizamos la fila en el DataGridView
                int rowIndex = dataGBecas.SelectedRows[0].Index;
                dataGBecas.Rows[rowIndex].SetValues(becaSeleccionada.Codigo, becaSeleccionada.ImporteBeca);

                // Actualizamos la lista de becas y las grillas
                listaBecas.ModificarBeca(becaSeleccionada);
                dataGBecas.Refresh();
                ActualizaGBecasEnA();
                ActualizaGCuotaPaga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBajaBeca_Click(object sender, EventArgs e) // damos de baja una beca ya sea que esté o no asignada
        {
            if (becaSeleccionada != null)
            {
                string codigoHallado = becaSeleccionada.Codigo;
                listaBecas.EliminarBecaPorCodigo(becaSeleccionada.Codigo); //utilizamos para ello el 
                alumnoSeleccionado.BecasEnAlumno.RemoveAll(auto => auto.Codigo == becaSeleccionada.Codigo);
                becaSeleccionada = null; // Liberamos la beca seleccionada
                GC.Collect(); // Llamamos al recolector de basura (no es necesario aunque sirve para ver su funcionamiento)

                if (dataGBecasEnAlum.Rows.Count > 0) // Verificamos si la DataGridView dataGBecasEnAlu no está vacía
                {  
                    foreach (DataGridViewRow row in dataGBecasEnAlum.Rows) 
                    { 
                        if (row != null)// Verificamos si la fila actual no es nula
                        {
                            if (row.Cells["Codigo"] != null && row.Cells["Codigo"].Value != null) //Verificamos si la celda Código no es nnula
                            {
                                // Comparamos el codigo de la fila actual con la codigo de lal beca seleccionada
                                if (row.Cells["Codigo"].Value.ToString() == codigoHallado)
                                {
                                    // Eliminamos la fila actual
                                    dataGBecasEnAlum.Rows.Remove(row);
                                    break; // Salimos del bucle una vez eliminada la fila
                                }
                            }
                        }
                    }
                } //actualizamos las grillas
                ActualizaGBecas();
                ActualizaGBecasEnA();
                ActualizaValorBecasEnA();
                ActualizaGCuotaPaga();
            }
        }
        #endregion

        #region"Actualizar grillas"

        private void ActualizaGAlum() //truncamos la grilla, recorremos la lista recibida y repoblamos  
        {                              //una fila por alumno con el valor de las propiedades de cada alumno  
            dataGAlum.Rows.Clear();    //en la columna correspondiente
            foreach (var alumno in listaAlumnos.Alumnos)
            {
                dataGAlum.Rows.Add(alumno.Legajo, alumno.Nombre, alumno.Apellido, alumno.DNI);
            }
        }

        private void ActualizaGBecas() //truncamos la grilla, recorremos la lista recibida y repoblamos  
        {
            dataGBecas.Rows.Clear();
            foreach (var beca in listaBecas.Becas)
            {
                dataGBecas.Rows.Add(beca.Codigo, beca.ImporteBeca);
            }
        }

        private void ActualizaGBecasEnA() //truncamos la grilla, recorremos la lista recibida y repoblamos 
        {
            dataGBecasEnAlum.Rows.Clear();
            if (dataGAlum.SelectedRows.Count > 0)
            {
                foreach (var beca in alumnoSeleccionado.BecasEnAlumno)
                {
                    dataGBecasEnAlum.Rows.Add(beca.Codigo, beca.FechaOtorgamiento.ToString("dd/MM/yyyy"), beca.ImporteBeca);
                }
            }
        }

        private void ActualizaGCuotaImpaga() //truncamos la grilla, recorremos la lista recibida y repoblamos 
        {
            dataGCuotaImpaga.Rows.Clear();
            foreach (var cuota in listaCuotas.Cuotas)
            {
                if (!cuota.Paga)
                {
                    dataGCuotaImpaga.Rows.Add(cuota.IdCuota, cuota.PeriodoDeCuota.ToString("MM/yyyy"), cuota.ImporteCuota);
                }
            }
        }
        private void ActualizaGCuotaPaga() //truncamos la grilla, recorremos la lista recibida y repoblamos 
        {
            dataGCuotaPaga.Rows.Clear();
            foreach (var cuota in listaCuotas.Cuotas)
            {
                if (cuota.Paga)
                {
                    dataGCuotaPaga.Rows.Add(
                    cuota.IdCuota,
                    cuota.PeriodoDeCuota.ToString("MM/yyyy"),
                    cuota.FechaDePago.ToString("dd/MM/yyyy"),
                    cuota.ImporteCuota,
                    cuota.ImporteBecas,
                    cuota.Beneficio,
                    cuota.APagar);
                }
            }
        }

        #endregion

        #region"Selección en grilla"


        private void dataGAlu_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos si hay al menos una fila seleccionada
            if (dataGAlum.SelectedRows.Count > 0)
            {
                // buscamos el DNI de la persona seleccionada en la grilla y lo usamos para recuperar los datos
                string legajo = dataGAlum.SelectedRows[0].Cells["Legajo"].Value.ToString();
                alumnoSeleccionado = listaAlumnos.ObtenerAlumnoPorLegajo(legajo);
                ActualizaGBecasEnA();
                ActualizaValorBecasEnA();
                // Actualizamos el formulario con los datos del alumno seleccionado
                if (alumnoSeleccionado != null)
                {
                    textBLeg.Text = alumnoSeleccionado.Legajo;
                    textBNom.Text = alumnoSeleccionado.Nombre;
                    textBApe.Text = alumnoSeleccionado.Apellido;
                    textBDNI.Text = alumnoSeleccionado.DNI;
                }
            }
        }

        private void dataGBecas_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos si hay al menos una fila seleccionada
            if (dataGBecas.SelectedRows.Count > 0)
            {
                // buscamos el codigo de la beca seleccionada en la grilla y lo usamos para recuperar los datos
                string codigo = dataGBecas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                becaSeleccionada = listaBecas.ObtenerBecaPorCodigo(codigo);

                // Actualizamos el formulario con los datos del alumno seleccionado
                if (becaSeleccionada != null)
                {
                    textBCod.Text = becaSeleccionada.Codigo;
                    textBImporteBeca.Text = becaSeleccionada.ImporteBeca.ToString();
                }    
            }
        }

        private void dataGCuotaImpaga_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos si hay al menos una fila seleccionada
            if (dataGCuotaImpaga.SelectedRows.Count > 0)
            {
                // buscamos la codigo de la beca seleccionada en la grilla y lo usamos para recuperar los datos
                int IdCuota = Convert.ToInt32(dataGCuotaImpaga.SelectedRows[0].Cells["IdCuota"].Value);
                cuotaSeleccionada = listaCuotas.ObtenerCuotaPorID(IdCuota);
            }
        }

        #endregion

        #region"operaciones en becas"

        private void btnAsigBeca_Click(object sender, EventArgs e) //Sin perjuicio de ser asignadas a su creación las becas 
        {                                                           // podran ser reasignadas de haberse desasignado
            try
            {   //Realizamos todas las validaciones a fin de capturar las excepciones en forma personalizada
                if (alumnoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar al alumno.");
                }
                if (alumnoSeleccionado.BecasEnAlumno.Count >= 2)
                {
                    throw new Exception("Se pueden tener hasta 2 becas por alumno.");
                }

                if (dataGBecas.SelectedRows.Count == 0)
                {
                    throw new Exception("Debe seleccionar una beca.");
                }

                if (listaAlumnos.BecaYaAsignada(dataGBecas.SelectedRows[0], dataGBecasEnAlum))
                {
                    throw new Exception("Esa beca ya se encuentra asignada.");
                }

                decimal ImporteBeca = Convert.ToDecimal(textBImporteBeca.Text);
                //sumamos la posible suma ya becada a la que se intenta generar 
                decimal valorTotalBecas = alumnoSeleccionado.BecasEnAlumno.Sum(beca => beca.ImporteBeca) + ImporteBeca;
                decimal cuotaActual = Convert.ToDecimal(textBImpActual.Text);

                if (valorTotalBecas > cuotaActual) //si al comparar superan la cuota disparamos el evento  
                {                                  // con los argumentos personalizados cuotaActual y valorTotalBecas
                    BecaSuperaCuota?.Invoke(this, new BecaEventArgs(alumnoSeleccionado, cuotaActual, valorTotalBecas));
                    return;
                }
                //Asignamos fecha de otorgamiento a la beca asignada o nueva si es reasignada
                becaSeleccionada.FechaOtorgamiento = DateTime.Now.Date;
                alumnoSeleccionado.BecasEnAlumno.Add(becaSeleccionada); //y la agregamos al alumno

                ActualizaGBecasEnA(); //truncamos y repoblamos grillas
                ActualizaValorBecasEnA();
                ActualizaGCuotaPaga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBecaSuperaCuota(object sender, BecaEventArgs e) //definimos el mensajes personalizado de dispararse el evento
        {                                           //por intentar asignar una beca que implique una suma becada superior a la cuota
            MessageBox.Show($"Alumno: {e.Alumno.Nombre} {e.Alumno.Apellido}\n" +
                            $"Valor de Cuota: {e.Cuota}\n" +
                            $"Valor Total de Becas: {e.TotalBecas}",
                            "Importe de Becas Excedido",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void btnDesAsignar_Click(object sender, EventArgs e) //Desasignamos una beca
        {
            try
            {
                // Verificamos si hay al menos una fila seleccionada en la grilla de las becas asignadas
                if (dataGBecasEnAlum.SelectedRows.Count == 0)
                {
                    throw new Exception("Debe seleccionar una beca para desasignar.");
                }

                // Obtenemos el codigo de la beca seleccionada al evaluar el contenido de la columna Codigo de la fila
                string codigoBecaDesasignar = dataGBecasEnAlum.SelectedRows[0].Cells["Codigo"].Value.ToString();

                // Eliminamos la beca de la lista de becas asignadas al alumno 
                alumnoSeleccionado.BecasEnAlumno.RemoveAll(beca => beca.Codigo == codigoBecaDesasignar);

                // Actualizamos las grillas
                ActualizaGBecasEnA();
                ActualizaValorBecasEnA();
                ActualizaGBecasEnA();
                ActualizaGCuotaPaga();
                MessageBox.Show("Beca correctamente desvinculada.", "Desasignación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizaValorBecasEnA() //Calculamos el valor total de la suma becada y lo mostramos 
        {                                   
            if (alumnoSeleccionado != null)
            {
                // Calcular el valor total de las becas asignadas a la persona
                decimal valorTotalBecas = alumnoSeleccionado.BecasEnAlumno.Sum(beca => beca.ImporteBeca);

                // Actualizamos el texto del Label labValorBecasEnPers
                labValorBecasEnAlu.Text = "El alumno tiene becas por: $" + valorTotalBecas.ToString();
            }
            else
            {
                // Si no hay una persona seleccionada, dejamos el texto del Label vacío
                labValorBecasEnAlu.Text = string.Empty;
            }
        }
        #endregion

        #region"Generación de cuotas y pago"

        private void btnGeneraCuotas_Click(object sender, EventArgs e) //generamos las cuotas con el valor actual de cuota
        {
            try
            {
                DateTime periodoElegido = dateTimePicker1.Value;

                // Validamos que el texto del TextBox sea un número decimal mayor a cero
                if (!(decimal.TryParse(textBImpActual.Text, out decimal importeActual) && importeActual > 0))
                {
                    throw new Exception($"Debe seleccionar el valor de la cuota{Environment.NewLine}" +
                                        $"en correspondiente al periodo {periodoElegido.ToString("MM/yyyy")}");
                }
                if (importeActual < ultimaCuota) //Evitamos que nos ingresen una cuota inferior a la anterior
                {
                    throw new Exception($"La nueva cuota no puede ser inferior a la anterior {Environment.NewLine}" +
                                        $"que fue de  {ultimaCuota}");
                }
                foreach (var alumno in listaAlumnos.Alumnos) //recorremos la lista de alumnos y ante cada alumno
                {
                    // Verificamos si el alumno no tiene cuotas emitidas para el periodo elegido
                    if (!listaCuotas.CuotaYaEmitida(alumno, periodoElegido))
                    {   //ahora si instanciaremos el objeto cuota y lo agregaremos al alumno y a la lista cuotas
                        Cuota nuevaCuota = new Cuota(alumno.Legajo, periodoElegido, importeActual); 
                        alumno.CuotasEnAlumno.Add(nuevaCuota);
                        listaCuotas.Cuotas.Add(nuevaCuota);
                        ActualizaGCuotaImpaga();
                    } //Si tenia vamos al siguiente hasta recorrer toda la lista
                }
                ultimaCuota = importeActual; // pasamos la nueva cuota bruta como anterior para la próxima modificación de cuota
                MessageBox.Show("Cuotas generadas correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ObtenerCondicion() //obtendremos la condición a fin de consignarla en la propiedad del alumno y de calcular el beneficio
        {
            if (radioBIng.Checked)
            {
                return "Ingresante";
            }
            else if (radioBGrado.Checked)
            {
                return "Grado";
            }
            else
            {
                return "Postgrado";
            }
        }

        private void btnPagar_Click(object sender, EventArgs e) //Registraremos el pago de la cuota seleccionada
        {
            try
            {
                if (cuotaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar la cuota que desea pagar.");
                }

                cuotaSeleccionada.Paga = true; //con true pagamos
                cuotaSeleccionada.FechaDePago = DateTime.Now; // Asignamos la fecha de pago actual para pisar la previa estimada en 36 dias luego de emitida la cuota

                cuotaSeleccionada.ImporteBecas = (listaAlumnos.ObtenerAlumnoPorLegajo(cuotaSeleccionada.Legajo).BecasEnAlumno.Sum(beca => beca.ImporteBeca));
                //obtenemos el alumno relacionado con la cuota por el legajo en la cuota y dentro de la lista de becas en alumno sumamos el valor de las mismas 
                if (listaAlumnos.ObtenerAlumnoPorLegajo(cuotaSeleccionada.Legajo).Condicion == "Ingresante")
                {
                    cuotaSeleccionada.Beneficio = 10;
                }
                else if (listaAlumnos.ObtenerAlumnoPorLegajo(cuotaSeleccionada.Legajo).Condicion == "Grado")
                {
                    cuotaSeleccionada.Beneficio = 5;
                }
                else
                {
                    cuotaSeleccionada.Beneficio = 1;
                } //Calculamos el beneficio según su condición
                //restamos a la cuota las becas y luego calculamos el porcentaje del beneficio
                cuotaSeleccionada.APagar = (cuotaSeleccionada.ImporteCuota - cuotaSeleccionada.ImporteBecas) * ((100 - cuotaSeleccionada.Beneficio) / 100);
                // Actualizamos las grillas correspondientes
                ActualizaGCuotaImpaga();
                ActualizaGCuotaPaga();

                MessageBox.Show("Cuota pagada correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#endregion
    }
}
