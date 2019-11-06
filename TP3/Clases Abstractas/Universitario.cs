using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region Constructores

        /// <summary>
        /// Constructor default de universitario, inicializara su atributo legajo en cero y los atributos heredados se inicializaran tambien con valores de su constructor por default de la clase persona
        /// </summary>
        public Universitario () : base()
        {
            this.legajo = 0;
        }

        /// <summary>
        /// Constructor de universitario, los parametros inicializaran tanto su atributo legajo como los heredados de la clase persona
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
        /// muestra los datos del universitario
        /// </summary>
        /// <returns>retorna todos los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\n\nLEGAJO NUMERO: " + this.legajo + "\n";
        }

        /// <summary>
        /// Muestra que clase esta tomando esta persona
        /// </summary>
        /// <returns>retorna la clase en la que esta participando</returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>true si son del mismo tipo y su legajo o DNI son iguales, false caso contrario </returns>
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
        /// verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1">Universitario a comparar</param>
        /// <param name="pg2">Universitario a comparar</param>
        /// <returns>true si son del mismo tipo y su legajo o DNI son iguales, false caso contrario </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
