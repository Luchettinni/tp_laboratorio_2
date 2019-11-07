using System;
using System.Collections.Generic;
using Clases_Abstractas;

namespace Clases_Instanciadas
{
    public sealed class Profesor : Universitario
    {

        #region Atributos

        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor default de profesor. este inicializara la cola y asignara 2 clases random al profesor
        /// </summary>
        public Profesor () : base()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Constructor estatico de profesor. este inicializara al atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de profesor. Este inicializara todos los atributos heredados y la cola. asi como tambien asignara 
        /// dos clases random al profesor
        /// </summary>
        /// <param name="id">ID o legajo del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">DNI del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos completos del profesor
        /// </summary>
        /// <returns>Retorna Apellido, Nombre, Nacionalidad, Legajo y las Clases que toma</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        /// <summary>
        /// Muestra que clases del dia que toma esta profesor
        /// </summary>
        /// <returns>Retorna la clases que esta tomando</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "CLASES DEL DIA: \n";

            foreach(Universidad.EClases clase in this.clasesDelDia)
            {
                retorno += clase + "\n";
            }

            retorno += "\n";

            return retorno ;
        }

        /// <summary>
        /// Asignará dos clases al azar al Profesor Las dos clases pueden o no ser la mismas.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// Retorna los datos del profesor.
        /// </summary>
        /// <returns>Retorna Apellido, Nombre, Nacionalidad, Legajo y las Clases que toma</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Verifica si es profesor de una clase especifica
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>true si este profesor da esa clase, false en caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases claseDelProfesor in i.clasesDelDia)
            {
                if ( claseDelProfesor == clase )
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si no es profesor de una clase especifica
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>true si este profesor no da esa clase, false en caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
