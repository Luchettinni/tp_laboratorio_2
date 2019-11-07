using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciadas
{
    public sealed class Alumno : Universitario
    {

        #region Enumerado

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Atributos

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de alumno, inicializa el estado de la cuenta como "al dia" y la clase que toma sera "programacion"
        /// , el resto de los atributos heredados tambien se inicializaran con su constructor por defecto.
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor de alumno, los parametros inicializan todos los atributos de la clase y los heredados tambien. 
        /// (el estado de la cuenta sera por defecto " al dia ")
        /// </summary>
        /// <param name="id">Legajo/Id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = EEstadoCuenta.AlDia;
        }
        /// <summary>
        /// Constructor de alumno, los parametros inicializan todos los atributos de la clase y los heredados tambien
        /// </summary>
        /// <param name="id">Legajo/Id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) :
            this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos completos del alumno
        /// </summary>
        /// <returns>Retorna Apellido, Nombre, Nacionalidad, Legajo, Estado de la cuenta y la Clase que toma</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() +  "\nESTADO DE LA CUENTA: " + this.estadoCuenta + ParticiparEnClase();
        }

        /// <summary>
        /// Muestra que clase esta tomando esta persona
        /// </summary>
        /// <returns>Retorna la clase que esta tomando</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// Retorna los datos del alumno.
        /// </summary>
        /// <returns>Retorna Apellido, Nombre, Nacionalidad, Legajo, Estado de la cuenta y la Clase que toma</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si el alumno esta tomando una clase especifica
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>true si este esta tomando esa clase y su estado no es deudor, false en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if ( a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si el alumno no esta tomando una clase especifica
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>true si no este esta tomando esa clase y su estado es deudor, false en caso contrario </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
