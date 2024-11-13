namespace Thot_Librery.Menu
{
    public class Menus : Attribute
    {
        // Método para añadir un formulario heredado a un panel
        public void Form_Heredado(Form form, Panel panel)
        {
            Limpiar(panel); // Limpiar el panel antes de añadir el nuevo formulario
            form.TopLevel = false; // Establecer TopLevel a false para agregar el formulario al panel
            panel.Controls.Add(form); // Añadir el formulario al panel
            panel.Tag = form; // Establecer el formulario como etiqueta del panel
            form.Show(); // Mostrar el formulario
        }

        // Método para limpiar un panel
        public void Limpiar(Panel panel)
        {
            if (panel.Controls.Count > 0)
            {
                panel.Controls.Clear(); // Limpiar todos los controles del panel
            }
        }
    }
}
