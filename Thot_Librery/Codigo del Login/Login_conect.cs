using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_del_Login
{
    public class Login_conect : Attribute
    {
        private readonly Conexion conexion = new();

        // Método para realizar el login de usuario
        public int Logear(string Nombre, string Contraceña)
        {
            try
            {
                // Abrir la conexión a la base de datos
                _ = conexion.Open();

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("sp_Login", conexion.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };
                _ = command.Parameters.AddWithValue("@Nombre", Nombre);
                _ = command.Parameters.AddWithValue("@Clave", Contraceña);

                // Ejecutar el comando y leer los resultados
                using SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    return dataReader.GetInt32(0); // Devolver el ID de usuario
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
    }
}
