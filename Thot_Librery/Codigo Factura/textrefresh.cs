using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_Factura
{
    public class textrefresh : Attribute
    {
        private readonly Conexion conexion = new();

        // Método para refrescar el texto del TextBox con auto-completar
        public void Textrefresh(TextBox text)
        {
            AutoCompleteStringCollection collection = [];

            try
            {
                _ = conexion.Open(); // Abrir la conexión a la base de datos

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("sp_textrefresh", conexion.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Ejecutar el comando y leer los resultados
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _ = collection.Add(reader["Nom_cli"].ToString());
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = conexion.Close(); // Asegurar que la conexión se cierra
            }

            // Asignar la colección de auto-completar al TextBox
            text.AutoCompleteCustomSource = collection;
        }
    }
}
