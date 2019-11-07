using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciadas
{
    public class Universidad
    {
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }

        #region Propiedades/Indexadores

        /// <summary>
        /// Devuelve o establece la lista de alumnos de la universidad
        /// </summary>
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value ; } }

        /// <summary>
        /// Devuelve o establece la lista de profesores de la universidad
        /// </summary>
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }

        /// <summary>
        /// Devuelve o establece la lista de jornadas de la universidad
        /// </summary>
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

        /// <summary>
        /// Devuelve o establece una jornada de la lista de jornadas de la universidad mediante un indice
        /// </summary>
        public Jornada this[int i] { get { return this.jornada[i]; } set { this.jornada[i] = value; } }

        #endregion

        #region Constructores

        public Universidad()
        {
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
            this.alumnos = new List<Alumno>();
        }

        #endregion

        #region Metodos

        static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "JORNADA: \n";
            foreach (Jornada jornada in this.Jornadas)
            {
                retorno += jornada.ToString();
                retorno += "<-------------------------------------------------->" + "\n" ;
            }

            return retorno;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si el alumno ya esta cargado en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno ya esta cargado, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach( Alumno alu in g.alumnos )
            {
                if (alu == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el alumno no esta cargado en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno no esta cargado, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si el profesor esta dando clases en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si el profesor esta dando clases en la universidad, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si el profesor no esta dando clases en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si el profesor no esta dando clases en la universidad, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Encuentra al primer profesor capaz de dar esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>retornara al primer profesor capaz de dar esa clase, caso contrario retornara una excepcion</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach( Profesor profesor in u.Instructores )
            {
                if ( profesor == clase )
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Encuentra al primer profesor no capaz de dar esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>retornara al primer profesor no capaz de dar esa clase, caso contrario retornara una excepcion</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Genera una nueva jornada en la universidad con los alumnos que tomen la misma y el prfoseor que tambien lo haga
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada nuevaJornada = new Jornada(clase, (g == clase));
                
                foreach ( Alumno alumno in g.Alumnos )
                {
                    if ( alumno == nuevaJornada.Clase && nuevaJornada.Instructor.DNI != alumno.DNI )
                    {
                        nuevaJornada += alumno;
                    }
                }

                g.jornada.Add(nuevaJornada);

                return g;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Agrega un alumno a la universidad siempre y cuando no exista dentro de ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>retornara la universidad con el alumno cargado, caso contrario retornara una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if ( u != a )
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad siempre y cuando no exista dentro de ella
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>retornara la universidad con el profesor cargado, caso contrario retornara una excepcion</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }
        #endregion
    }
}
