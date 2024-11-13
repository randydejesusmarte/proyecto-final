using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_del_Login
{
    public class Id_Login : Attribute
    {
        private readonly Conexion conexion = new();

        // Método para obtener el ID de usuario
        public int get_id(string Nombre, string Contraceña)
        {
            try
            {
                // Abrir la conexión a la base de datos
                _ = conexion.Open();

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("sp_get_id", conexion.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };
                _ = command.Parameters.AddWithValue("@Nombre", Nombre);
                _ = command.Parameters.AddWithValue("@Clave", Contraceña);

                // Ejecutar el comando y leer los resultados
                using SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.Read())
                {
                    return DataReader.GetInt32(0); // Devolver el ID de usuario
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
            return -1; // Devolver -1 si algo falla
        }

        // Método para obtener el nombre de usuario
        public string get_name(string Nombre, string Contraceña)
        {
            try
            {
                // Abrir la conexión a la base de datos
                _ = conexion.Open();

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("sp_get_id", conexion.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };
                _ = command.Parameters.AddWithValue("@Nombre", Nombre);
                _ = command.Parameters.AddWithValue("@Clave", Contraceña);

                // Ejecutar el comando y leer los resultados
                using SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.Read())
                {
                    return DataReader.GetString(1); // Devolver el nombre de usuario
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
            return ""; // Devolver una cadena vacía si algo falla
        }
    }
}
