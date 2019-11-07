using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace Clases_Instanciadas
{
    public class Jornada
    {

        #region Atributos

        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        /// Devuelve o establece la lista de alumnos de esta jornada
        /// </summary>
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        /// <summary>
        /// Devuelve o establece la clase de la jornada
        /// </summary>
        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }

        /// <summary>
        /// Devuelve o establece al instructor de la jornada
        /// </summary>
        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }

        #endregion

        #region constructores

        /// <summary>
        /// Constructor default de jornada, inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de jornada, los parametros otorgan valores a la clase e instructor de la jornada.
        /// </summary>
        /// <param name="clase">Es la clase de la jornada</param>
        /// <param name="instructor">El profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        public override string ToString()
        {
            string retorno = "";

            retorno += "CLASE DE: " + this.clase + " POR " + this.instructor.ToString();
            if (this.Alumnos.Count != 0)
            {
                retorno += "ALUMNOS: \n";

                foreach (Alumno alumno in this.alumnos)
                {
                    retorno += alumno.ToString() + "\n";
                }
            }
            else
            {
                retorno += "- NO HAY ALUMNOS PARA ESTA JORNADA... -\n";
            }
            

            return retorno;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto writer = new Texto();

            return ((IArchivo<string>)writer).Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto reader = new Texto();
            string retorno;
            bool completado = ((IArchivo<string>)reader).Leer("Jornada.txt", out retorno);

            if (!completado)
            {
                throw new Exception();
            }
            else
            {
                return retorno;
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si el alumno en cuestion participa en la clase de la jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>true si el alumno participa en la clase, false en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if ( j.alumnos.Contains(a) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si el alumno en cuestion no participa en la clase de la jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>true si el alumno no participa en la clase, false en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if ( j != a && a != j.Instructor )
            {
                j.Alumnos.Add(a);
            }

            return j;
        }

        #endregion
    }
}
