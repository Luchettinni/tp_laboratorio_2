using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {

        #region Atributo

        int legajo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor default de universitario, inicializara su atributo legajo en cero.
        /// </summary>
        public Universitario () : base()
        {

        }

        /// <summary>
        /// Constructor de universitario, los parametros inicializaran tanto su atributo legajo como los atributos heredados de la clase persona
        /// </summary>
        /// <param name="legajo">Legajo o ID del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">DNI del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario ( int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad ) : base (nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos 

        /// <summary>
        /// Muestra los datos del universitario 
        /// </summary>
        /// <returns>Retorna Apellido, Nombre, Nacionalidad y Legajo</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\n\nLEGAJO NUMERO: " + this.legajo + "\n";
        }

        /// <summary>
        /// Muestra que clase esta tomando esta persona
        /// </summary>
        /// <returns>Retorna la clase que esta tomando</returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si dos universitarios son iguales.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>true si son del mismo tipo y su legajo o DNI son iguales, false caso contrario.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ( (pg1.GetType()) == (pg2.GetType()) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si dos universitarios son distintos.
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>true si no son del mismo tipo y su legajo o DNI no son iguales, false caso contrario </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
