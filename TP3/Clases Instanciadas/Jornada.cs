using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clases_Instanciadas
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

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

            retorno += "JORNADA: \nCLASE DE: " + this.clase + " POR " + this.instructor.ToString();
            retorno += "ALUMNOS: \n";

            foreach(Alumno alumno in this.alumnos)
            {
                retorno += alumno.ToString() + "\n";
            }

            return retorno;
        }

        public bool guardar(Jornada jornada)
        {
            try
            {
                StreamWriter guardado = new StreamWriter( Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Datos.txt" );
                guardado.Write(jornada.ToString());
                guardado.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Leer()
        {
            try
            {
                StreamReader Cargado = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Datos.txt");
                string retorno = Cargado.ReadToEnd();
                Cargado.Close();
                return retorno;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Jornada j, Alumno a)
        {
            if ( a == j.Clase )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if ( !j.alumnos.Contains(a) )
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        #endregion
    }
}
