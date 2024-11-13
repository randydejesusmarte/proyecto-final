using Thot_Librery.Conexiones;

namespace Thot_Librery.Codigo_Factura
{
    public class Agregar_Factura
    {
        private readonly Conexion conexion = new();

        // Método para agregar una factura a la base de datos
        public void Agregar(int id, int idCliente, string nombreProducto, string precioStr, string cantidadStr, string montoStr, string precioTotal, int idEmpleado, string fechaDelRegistro)
        {
            try
            {
                _ = conexion.Open(); // Abrir la conexión a la base de datos

                // Crear y configurar el comando para ejecutar el procedimiento almacenado
                using SqlCommand command = new("sp_insertar_Factura", conexion.SqlConnectio)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Convertir las cadenas de entrada a enteros
                int precio = Convert.ToInt32(precioStr);
                int cantidad = Convert.ToInt32(cantidadStr);
                int monto = Convert.ToInt32(montoStr);

                // Añadir parámetros al comando
                _ = command.Parameters.AddWithValue("@idfactura", id);
                _ = command.Parameters.AddWithValue("@Id_cliente", idCliente);
                _ = command.Parameters.AddWithValue("@Nombre_producto", nombreProducto);
                _ = command.Parameters.AddWithValue("@Precio", precio);
                _ = command.Parameters.AddWithValue("@Cantidad", cantidad);
                _ = command.Parameters.AddWithValue("@Monto", monto);
                _ = command.Parameters.AddWithValue("@Precio_total", precioTotal);
                _ = command.Parameters.AddWithValue("@Empleado", idEmpleado);
                _ = command.Parameters.AddWithValue("@Fecha_del_Registro", fechaDelRegistro);

                // Ejecutar el comando
                _ = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message); // Mostrar mensaje de error en caso de excepción
            }
            finally
            {
                _ = conexion.Close(); // Asegurar que la conexión se cierra
            }
        }
    }
}
