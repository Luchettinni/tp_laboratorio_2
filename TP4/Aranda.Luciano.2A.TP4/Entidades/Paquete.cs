using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    // FALTA IMPLEMENTACION DE ALGUNAS COSAS
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        /// <summary>
        /// obtiene o establece la direccion de entrega del paquete
        /// </summary>
        public string DireccionEntrega { get { return this.direccionEntrega; } set { this.direccionEntrega = value; } }
        /// <summary>
        /// obtiene o establece el estado del paquete
        /// </summary>
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        /// <summary>
        /// obtiene o establece el tracking ID del paquete
        /// </summary>
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del paquete</param>
        /// <param name="trackingID">ID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        #endregion

        #region Metodos

        public delegate void DelegadoEstado(object sender, EventArgs args);

        public event DelegadoEstado informaEstado;

        /// <summary>
        /// Simula el cambio de estado de un paquete y lo guarda en una base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            if ( this.informaEstado != null )
            {
                

                for (int i = 0; i < 3; i++)
                {
                    this.Estado = (EEstado) i;
                    this.informaEstado(this, EventArgs.Empty);
                    Thread.Sleep(4000);
                }

                PaqueteDAO.Insertar(this);
            }
            else
            {
                throw new Exception("El evento no tiene un manejador");
            }
        }

        /// <summary>
        /// muestra los datos del paquete
        /// </summary>
        /// <param name="elemento">Paquete contenedor de datos a mostrar</param>
        /// <returns>retorna el tracking ID y la direccion de entrega</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Muestra la informacion del paquete
        /// </summary>
        /// <returns>Retorna la informacion del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1">paquete a comparar</param>
        /// <param name="p2">paquete a comparar</param>
        /// <returns>True si su tracking ID es igual, false caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if ( p1.TrackingID == p2.TrackingID )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Dos paquetes seran distintos siempre y cuando su Tracking ID sea distinto
        /// </summary>
        /// <param name="p1">paquete a comparar</param>
        /// <param name="p2">paquete a comparar</param>
        /// <returns>True si su tracking ID es distinto, false caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

    }
}
