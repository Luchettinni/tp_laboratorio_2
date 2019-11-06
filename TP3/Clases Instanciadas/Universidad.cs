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

            foreach(Jornada jornada in this.Jornadas)
            {
                retorno += jornada.ToString();
                retorno += "\n" + "<-------------------------------------------------->" + "\n" ;
            }

            return retorno;
        }

        #endregion

        #region Sobrecargas

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            if ( g.Instructores.Contains(i) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada nuevaJornada = new Jornada(clase, (g == clase));
                g.jornada.Add(nuevaJornada);

                foreach ( Alumno alumno in g.Alumnos )
                {
                    if ( alumno == nuevaJornada.Clase )
                    {
                        nuevaJornada.Alumnos.Add(alumno);
                    }
                }

                return g;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if ( !(u == a) )
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u == i))
            {
                u.Instructores.Add(i);
            }

            return u;
        }


        #endregion
    }
}
