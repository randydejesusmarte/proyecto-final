using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_Factura
{
    public class Auto_increment : Attribute
    {
        private readonly Conexion Conexiones = new();

        // Método para obtener el próximo valor de incremento automático
        public int Cont()
        {
            try
            {
                // Abrir la conexión a la base de datos
                _ = Conexiones.Open();

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("SP_auto_increment_FacId", Conexiones.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Ejecutar el comando y leer los resultados
                using SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.Read())
                {
                    return DataReader.GetInt32(0); // Devolver el valor leído
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = Conexiones.Close(); // Asegurar que la conexión se cierra
            }
            return -1; // Devolver -1 si algo falla
        }
    }
}
