﻿global using System.Data;
global using System.Data.SqlClient;

namespace Thot_Librery.Conexiones
{
    internal class Conexion : Attribute
    {
        internal SqlConnection SqlConnectio { get; private set; } = new();

        private readonly string cadena = Properties.Settings.Default.Conecctionstring;

        internal Conexion()
        {
            SqlConnectio.ConnectionString = cadena;
        }

        internal SqlConnection Open()
        {
            if (SqlConnectio.State == ConnectionState.Closed)
            {
                SqlConnectio.Open();
            }
            return SqlConnectio;
        }

        internal SqlConnection Close()
        {
            if (SqlConnectio.State == ConnectionState.Open)
            {
                SqlConnectio.Close();
            }
            return SqlConnectio;
        }
    }
}
