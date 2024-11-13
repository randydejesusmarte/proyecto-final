using System.Data;
using System.Drawing.Printing;
using Thot_Librery.Entrada;

namespace WindowsFormsApp1
{
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();
            Datatables();
        }

        internal int id_empleado;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (validar(this))
            {
                //si esta vacio
                _ = MessageBox.Show("Favor llenar todo", "Advertencia");
            }
            else
            {
                //si esta lleno
                agregar();
            }
        }

        private bool validar(Form formulario)
        {
            bool lleno = false; // Inicializamos lleno a false

            foreach (object? oControl in formulario.Controls)
            {
                if (oControl is TextBox textBox && textBox.Text == string.Empty)
                {
                    lleno = true;
                    break; // Detenemos el ciclo una vez encontramos un TextBox vacío
                }
            }
            return lleno;
        }

        private string CONDICION;
        public static DataTable Dt { get; } = new();
        private const string FamilyName = "Century Gothic";
        private static readonly Font font = new(FamilyName, 10, FontStyle.Regular);
        private const int space = 25;
        private static readonly Pen blackPen = new(Color.Black, 2);
        private static readonly Brush blackBrush = Brushes.Black;
        private static readonly Font titleFont = new(FamilyName, 14, FontStyle.Bold);

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 5;
            e.Graphics.DrawString(Settings.Default.Namesbusiness, titleFont, blackBrush, new Point(65, y += space));
            e.Graphics.DrawString("Llegando a la rotonda", font, blackBrush, new Point(40, y += space));
            e.Graphics.DrawString("Santiago, Rep Dom. Tel:849-216-1333", font, blackBrush, new Point(0, y += space));

            e.Graphics.DrawLine(blackPen, 500, y += 25, 0, y);
            e.Graphics.DrawString("Factura de contado", font, blackBrush, new Point(25, y += 5));
            e.Graphics.DrawString("FACTURA.: " + "B000000043", font, blackBrush, new Point(0, y += space));
            e.Graphics.DrawString("FECHA...: " + DateTime.Now.ToString(), font, blackBrush, new Point(0, y += space));
            e.Graphics.DrawString("ATENDIDO POR.: " + Settings.Default.Idusuario, font, blackBrush, new Point(0, y += space));
            e.Graphics.DrawString("Tecnico.: " + txtmecanico.Text, font, blackBrush, new Point(0, y += space));

            string condicion = radioButton1.Checked ? "Al Contado" : "A Credito";
            e.Graphics.DrawString("CONDICION.: " + condicion, font, blackBrush, new Point(0, y += space));
            e.Graphics.DrawString("CLIENTE.: " + TxtCliente.Text + "  #0005", font, blackBrush, new Point(0, y += space));
            e.Graphics.DrawLine(blackPen, 500, y += 25, 0, y);
            e.Graphics.DrawString("Servicio", font, blackBrush, new Point(0, y));
            e.Graphics.DrawLine(blackPen, 500, y += 25, 0, y);

            foreach (DataRow row in Dt.Rows)
            {
                e.Graphics.DrawString(row["Servicio"].ToString(), font, blackBrush, new Point(0, y += space));
            }

            e.Graphics.DrawString("Gracias por preferirnos", font, blackBrush, new Point(25, y += space));

            // No es necesario llamar a Dispose manualmente aquí
            // e.Graphics.Dispose();
            printPreviewDialog1.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;
            printPreviewDialog1.DesktopLocation = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void Datatables()
        {
            Dt.Reset();
            _ = Dt.Columns.Add("Servicio");
            dataGridView1.DataSource = Dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            _ = printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CONDICION = radioButton1.Checked ? "Al Contado" : "A Crédito";
            Ventrada entrada = new();
            foreach (DataRow row in Dt.Rows)
            {
                entrada.Insertar(
                    IDEnt.Text,
                    TxtCliente.Text,
                    Settings.Default.Idusuario.ToString(),
                    txtmecanico.Text,
                    CONDICION,
                    row
                );
            }
            entrada.Cant(IDEnt.Text);
        }

        private void agregar()
        {
            DataRow row = Dt.NewRow();
            row["Servicio"] = textBox3.Text;
            Dt.Rows.Add(row);
            textBox3.Clear(); // Uso de Clear() en lugar de asignación de cadena vacía
            dataGridView1.AutoResizeColumn(0);
        }

        private void Entrada_Load(object sender, EventArgs e)
        {
            IDEnt.Text = new Auto_increment().Cont().ToString();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregar();
            }
        }
    }
}
