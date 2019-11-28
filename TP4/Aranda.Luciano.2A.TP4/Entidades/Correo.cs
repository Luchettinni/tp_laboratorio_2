using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    // FALTA EL TRACKINGIDREPETIDOEXCEPTION
    public class Correo : IMostrar< List<Paquete> >
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece la lista de paquetes de este correo
        /// </summary>
        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        #endregion

        #region Constructor

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// muestra todos los datos de los paquetes.
        /// </summary>
        /// <param name="elementos">paquetes a mostrar</param>
        /// <returns>retorna cada uno de los paquetes con sus respectivos datos (ID, direccion de entrega y estado)</returns>
        public string MostrarDatos(IMostrar< List<Paquete> > elementos)
        {
            string retorno = "";

            foreach ( Paquete paquete in ((Correo) elementos).Paquetes)
            {
                 retorno += string.Format("{0} para {1} ({2})\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }

            return retorno;
        }

        /// <summary>
        /// Cierra todos los hilos de cada paquete del correo
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread entrega in this.mockPaquetes)
            {
                entrega.Abort();
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Agrega (si no estar repetido) un paquete al correo
        /// </summary>
        /// <param name="c">Correo al cual se le agregara el paquete</param>
        /// <param name="p">paquete a agregar</param>
        /// <returns>retorna el correo con el paquete agregado ( o no agregado, si ya existia dentro )</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if ( p == paquete )
                {
                    throw new Exception();
                }
            }

            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

        #endregion

    }
}
