using System;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        public delegate void DelegadoExcepcion(string message);
        public static event DelegadoExcepcion informarExcepcion;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de clase de paqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Inserta en la base de datos un paquete
        /// </summary>
        /// <param name="p">Paquete a insertar</param>
        /// <returns>True si logra insertarlo</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion.Open();
                string insertar = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)" + " VALUES ('{0}','{1}','Luciano Aranda')", p.DireccionEntrega, p.TrackingID);
                comando.CommandText = insertar;
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception e)
            {
                informarExcepcion(e.Message);
                return false;
            }
        }

        #endregion

    }
}
