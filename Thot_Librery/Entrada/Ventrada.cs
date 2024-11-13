using Thot_Librery.Conexiones;

namespace Thot_Librery.Entrada
{
    public class Ventrada : Attribute
    {
        private readonly Conexion Conexiones = new();

        // Método para insertar una entrada en la base de datos
        public void Insertar(string num, string cliente, string atendido, string trabajado, string condicion, DataRow entrada)
        {
            try
            {
                _ = Conexiones.Open(); // Abrir la conexión a la base de datos

                using SqlCommand command = new("SP_Entradas", Conexiones.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Añadir parámetros al comando
                _ = command.Parameters.AddWithValue("@Num", num);
                _ = command.Parameters.AddWithValue("@Cliente", cliente);
                _ = command.Parameters.AddWithValue("@Atendido", atendido);
                _ = command.Parameters.AddWithValue("@Trabajado", trabajado);
                _ = command.Parameters.AddWithValue("@Condicion", condicion);
                _ = command.Parameters.AddWithValue("@Fecha", DateTime.Now.ToString());
                _ = command.Parameters.AddWithValue("@Servicio", entrada["Servicio"]);

                // Ejecutar el comando
                _ = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = Conexiones.Close(); // Asegurar que la conexión se cierra
            }
        }

        // Método para actualizar la cantidad de entradas
        public void Cant(string num)
        {
            try
            {
                _ = Conexiones.Open(); // Abrir la conexión a la base de datos

                using SqlCommand command = new("SP_CantEntradas", Conexiones.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Añadir el parámetro al comando
                _ = command.Parameters.AddWithValue("@Num", Convert.ToInt32(num));

                // Ejecutar el comando
                _ = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = Conexiones.Close(); // Asegurar que la conexión se cierra
            }
        }
    }
}
