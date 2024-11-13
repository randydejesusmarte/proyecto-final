using thot.Properties;
using Thot_Librery.Codigo_del_Login;

namespace thot
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private readonly Login_conect login = new();
        private readonly Id_Login id_Login = new();

        // Manejar el evento de clic en el botón Entrar
        private void bt_Entrar_Click(object sender, EventArgs e)
        {
            Enter();
        }

        // Manejar el evento de carga del formulario Login
        private void Login_Load(object sender, EventArgs e)
        {
            txt_Nombre.Text = Settings.Default.Uname;
            txt_Contraseña.Text = Settings.Default.Pass;
            checkit.Checked = Settings.Default.checkit;
        }

        // Guardar las credenciales del usuario en la configuración
        private void Save()
        {
            Settings.Default.Uname = txt_Nombre.Text;
            Settings.Default.checkit = checkit.Checked;
            Settings.Default.Pass = checkit.Checked ? txt_Contraseña.Text : "";
            Settings.Default.Save();
        }

        // Manejar el evento de cambio de estado del CheckBox
        private void Checkit_CheckedChanged(object sender, EventArgs e)
        {
            _ = txt_Contraseña.Focus();
        }

        // Manejar el evento de pulsación de tecla en el TextBox Nombre
        private void Txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Enter();
            }
        }

        // Método para manejar el proceso de entrada (login)
        private new void Enter()
        {
            int result = login.Logear(txt_Nombre.Text, txt_Contraseña.Text);

            if (result == 1)
            {
                Save();
                WindowsFormsApp1.Menu form = new()
                {
                    id = id_Login.get_id(txt_Nombre.Text, txt_Contraseña.Text),
                    Text = id_Login.get_name(txt_Nombre.Text, txt_Contraseña.Text).ToString(),
                    name_business = id_Login.get_name(txt_Nombre.Text, txt_Contraseña.Text).ToString()
                };
                form.Show();
                Hide();
            }
            else if (result == 0)
            {
                _ = MessageBox.Show("Contraseña o Usuario son incorrecto");
            }
        }
    }
}
