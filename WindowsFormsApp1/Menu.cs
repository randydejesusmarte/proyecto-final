global using WindowsFormsApp1.Properties;
using Thot_Librery.Menu;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            fecha.Start(); // Iniciar el temporizador al cargar el formulario
        }

        public int id; // Identificador del usuario
        public string name_business; // Nombre del negocio

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Salir de la aplicación al cerrar el formulario
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Ejecutar una tarea en segundo plano para mostrar un mensaje con el ID de usuario y el nombre del negocio
            new Task(static () => MessageBox.Show(Settings.Default.Idusuario.ToString(), Settings.Default.Namesbusiness.ToString())).Start();
        }

        private void BtFactura_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de facturación dentro del panel del contenedor dividido
            Facturar form = new()
            {
                id_empleado = id // Asignar el ID del empleado al formulario de facturación
            };
            new Menus().Form_Heredado(form, splitContainer1.Panel2);
        }

        private void fecha_Tick(object sender, EventArgs e)
        {
            // Actualizar la etiqueta de fecha con la hora actual
            L_Fecha.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Limpiar el panel y mostrar el formulario de entrada dentro del panel
            MostrarFormularioEnPanel(new Entrada { id_empleado = id });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Limpiar el panel
            new Menus().Limpiar(splitContainer1.Panel2);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Guardar el ID de usuario y el nombre del negocio en la configuración
            Settings.Default.Idusuario = id;
            Settings.Default.Namesbusiness = name_business;
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de control de gastos dentro del panel
            MostrarFormularioEnPanel(new controdegastos());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Mostrar el formulario de control de servicios dentro del panel
            MostrarFormularioEnPanel(new ctlservicios());
        }

        private void MostrarFormularioEnPanel(Form form)
        {
            // Limpiar el panel y mostrar el formulario heredado dentro del panel
            new Menus().Limpiar(splitContainer1.Panel2);
            new Menus().Form_Heredado(form, splitContainer1.Panel2);
        }
    }
}