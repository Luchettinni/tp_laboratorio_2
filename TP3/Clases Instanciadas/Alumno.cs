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
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region Constructores

        /// <summary>
        /// Constructor por defecto de alumno, inicializa el estado de la cuenta como "al dia" y la clase que toma sera "programacion"
        /// , el resto de los atributos heredados tambien se inicializaran con su constructor por defecto.
        /// </summary>
        public Alumno() : base()
        {
            this.estadoCuenta = EEstadoCuenta.AlDia;
            this.claseQueToma = Universidad.EClases.Programacion;
        }

        /// <summary>
        /// Constructor de alumno, los parametros inicializan todos los atributos de la clase (menos el estado de la cuenta)
        /// y los heredados tambien
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
        /// Convierte todos los datos del alumno en una cadena de caracteres
        /// </summary>
        /// <returns>retorna todos los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() +  "\nESTADO DE LA CUENTA: " + this.estadoCuenta + ParticiparEnClase();
        }

        /// <summary>
        /// Muestra que clase esta tomando esta persona
        /// </summary>
        /// <returns>retorna la clase en la que esta participando</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// retorna los datos del alumno
        /// </summary>
        /// <returns>retorna todos los atributos propios y heredados en formato string</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecarga de metodos

        /// <summary>
        /// verifica si el alumno esta tomando una clase especifica
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>true si este esta tomando esa clase y su estado no es deudor, false en caso contrario </returns>
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
        /// verifica si el alumno no esta tomando una clase especifica
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
