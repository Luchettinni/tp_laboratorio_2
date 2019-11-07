using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region Enumerado

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Atributos

        string nombre;
        string apellido;
        ENacionalidad nacionalidad;
        int dni;

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve o establece el nombre de esta persona. si lo establece se validara que el mismo tenga caracteres validos,
        /// en caso de no tenerlos devolvera una excepcion.
        /// </summary>
        public string Nombre { get { return this.nombre; } set { this.nombre = ValidarNombreApellido(value); } }

        /// <summary>
        /// Devuelve o establece el apellido de esta persona. si lo establece se validara que el mismo tenga caracteres validos,
        /// en caso de no tenerlos devolvera una excepcion.
        /// </summary>
        public string Apellido { get { return this.apellido; } set { this.apellido = ValidarNombreApellido(value); } }

        /// <summary>
        /// Devuelve o establece la nacionalidad de esta persona.
        /// </summary>
        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }

        /// <summary>
        /// Devuelve o establece el DNI de esta persona.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.nacionalidad, value);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Convierte una cadena de caracteres a dni de la persona. validara que contenga solo numeros
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.nacionalidad, value);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor default de persona.
        /// </summary>
        public Persona()
        {
            this.nombre = "SIN NOMBRE";
            this.apellido = "SIN APELLIDO";
            this.nacionalidad = ENacionalidad.Argentino;
            this.dni = 0;
        }

        /// <summary>
        /// Constructor de persona, los parametros inicializan algunos de sus atributos.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre= nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de persona, los parametros inicializan todos sus atributos.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni.ToString();
        }

        /// <summary>
        /// Constructor de persona, los parametros inicializan todos sus atributos.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni ,ENacionalidad nacionalidad) : this(nombre,apellido, dni.ToString() ,nacionalidad)
        {
            
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos de la persona.
        /// </summary>
        /// <returns>Retorna apellido, nombre y nacionalidad</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido  + ", " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad;
        }

        /// <summary>
        /// Valida que el dni ingresado corresponda a la nacionalidad de la persona, asi como que su formato este correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Si todo salio bien, retorna el DNI de la persona.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoInt = 0;

            try
            {
               datoInt = int.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException("DNI presenta error de formato : El DNI no debe contener letras y/o simbolos especiales");
            }

            if ( !(datoInt >= 1 && datoInt <= 99999999) )
            {
                throw new DniInvalidoException("DNI presenta error de formato : El DNI Exede el maximo o no supera el minimo de numeros permitidos");
            }

            if ( nacionalidad == ENacionalidad.Argentino && !( datoInt >= 1 && datoInt <= 89999999 ) )
            {
                throw new NacionalidadInvalidaException("La nacionalidad debe ser extranjera");
            }

            else if ( nacionalidad == ENacionalidad.Extranjero && !( datoInt >= 90000000 && datoInt <= 99999999 ) )
            {
                throw new NacionalidadInvalidaException("La nacionalidad debe ser argentina");
            }

            return datoInt;
        }

        /// <summary>
        /// Valida que el dni ingresado corresponda a la nacionalidad de la persona, asi como que su formato este correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Si todo salio bien, retorna el DNI de la persona.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida que los nombres o apellidos sean cadenas con caracteres válidos para los mencionados. caso contrario no se cargara.
        /// </summary>
        /// <param name="dato">El nombre o apellido a validar</param>
        /// <returns>retorna NULL si el "dato" no se considera valido, retorna el dato si se considera valido</returns>
        private string ValidarNombreApellido(string dato)
        {

            foreach (char character in dato)
            {
                if ( !char.IsLetter(character) || char.IsWhiteSpace(character) )
                {
                    throw new FormatException("Los caracteres ingresados para el Nombre/Apellido de esta persona son invalidos");
                }
            }

            return dato;
        }

        #endregion
    }
}
