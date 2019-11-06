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
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        string nombre;
        string apellido;
        ENacionalidad nacionalidad;
        int dni;

        #region propiedades

        /// <summary>
        /// Devuelve o establece el nombre de esta persona. si lo establece se validara que el mismo tenga caracteres validos,
        /// en caso de no tenerlos devolvera null
        /// </summary>
        public string Nombre { get { return this.nombre; } set { this.nombre = ValidarNombreApellido(value); } }

        /// <summary>
        /// Devuelve o establece el apellido de esta persona. si lo establece se validara que el mismo tenga caracteres validos,
        /// en caso de no tenerlos devolvera null
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
                    switch (ValidarDni(this.nacionalidad, value))
                    {
                        case 0:
                            this.dni = value;
                            break;

                        case 1:
                            throw new DniInvalidoException("DNI presenta error de formato: El dni contiene mas ( o menos ) de los caracteres de los permitidos");
                            

                        case 2:
                            throw new NacionalidadInvalidaException("La nacionalidad debe ser extranjera");

                        case 3:
                            throw new NacionalidadInvalidaException("La nacionalidad debe ser argentina");

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Convierte una cadena de caracteres a dni de la persona. validara que contenga solo numeros y (opcional) puntos
        /// </summary>
        public string StringToDNI
        {
            set
            {
                string finalNumber = "";
                try
                {
                    

                    for (int i = 0; i < value.Length; i++)
                    {
                        if ( value[i] != 46 )
                        {
                            finalNumber += value[i].ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DniInvalidoException("DNI presenta error de formato : contiene letras o simbolos especiales (exceptuando los puntos y numeros)", e);
                }
                finally
                {
                    this.DNI = int.Parse(finalNumber);
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor default de persona. nombre y apellido estaran vacios, la nacionalidad sera por defecto "extranjero" y dni sera 99999999
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de persona, los parametros inicializan algunos de sus atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre= nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de persona, los parametros inicializan sus atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni ,ENacionalidad nacionalidad) : this(nombre,apellido, dni.ToString() ,nacionalidad)
        {
            
        }

        /// <summary>
        /// Constructor de persona, los parametros inicializan sus atributos
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona( string nombre, string apellido, string dni, ENacionalidad nacionalidad ) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni.ToString();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna los datos de la persona.
        /// </summary>
        /// <returns>retorna cada uno de los atributos de esta persona</returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + this.Apellido  + ", " + this.Nombre + "\nNACIONALIDAD: " + this.Nacionalidad;
        }

        /// <summary>
        /// Valida que el dni ingresado corresponda a la nacionalidad de la persona, asi como que su formato este correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>retorna 0 si la verificacion no tuvo problemas, 1 si el dato excede o no alcanza la cantidad de caracteres
        /// maximos, 2 si la nacionalidad deberia ser extranjera y 3 si la nacionalidad deberia ser argentina </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;

            if ( !(dato >= 1 && dato <= 99999999) )
            {
                retorno = 1;
            }

            if (nacionalidad == ENacionalidad.Argentino && !(dato >= 1 && dato <= 89999999))
            {
                retorno = 2;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && !(dato >= 90000000 && dato <= 99999999))
            {
                retorno = 3;
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el dni ingresado corresponda a la nacionalidad de la persona, asi como que su formato este correcto.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>retorna 0 si la verificacion no tuvo problemas, 1 si el dato excede o no alcanza la cantidad de caracteres
        /// maximos, 2 si la nacionalidad deberia ser extranjera y 3 si la nacionalidad deberia ser argentina </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Valida que los nombres o apellidos sean cadenas con caracteres válidos para los mencionados. caso contrario devuelve null
        /// </summary>
        /// <param name="dato">El nombre o apellido a validar</param>
        /// <returns>retorna NULL si el "dato" no se considera valido, retorna el dato si se considera valido</returns>
        private string ValidarNombreApellido(string dato)
        {
            string datoAux = dato;

            datoAux = datoAux.ToLower();

            for (int i = 0; i < datoAux.Length; i++)
            {
                if ( !(datoAux[i] >= 97 && datoAux[i] <= 122) )
                {
                    return null;
                }
            }

            return dato;
        }

        #endregion
    }
}
