using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_Factura
{
    public class FillData
    {
        private readonly Conexion conexiones = new();

        // Método para obtener los datos de una factura
        public DataTable Datos(string Id_Factura)
        {
            DataTable datos = new();

            try
            {
                int idfactura = Convert.ToInt32(Id_Factura);

                using SqlConnection connection = conexiones.Open();
                using SqlCommand command = new("sp_Fill_Data_Factura", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                _ = command.Parameters.AddWithValue("@Idfactura", idfactura);

                using SqlDataReader reader = command.ExecuteReader();
                datos.Load(reader);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = conexiones.Close(); // Asegurar que la conexión se cierra
            }

            return datos; // Devolver los datos cargados
        }
    }
}
