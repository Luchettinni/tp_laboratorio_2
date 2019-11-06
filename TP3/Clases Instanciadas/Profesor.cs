using System;
using System.Collections.Generic;
using Clases_Abstractas;

namespace Clases_Instanciadas
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> claseDelDia;
        static Random random;

        #region Constructores

        public Profesor () : base()
        {
            claseDelDia = new Queue< Universidad.EClases >();
            _randomClases();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            string retorno = "CLASES DEL DIA: \n";

            foreach(Universidad.EClases clase in this.claseDelDia)
            {
                retorno += clase + "\n";
            }

            retorno += "\n";

            return retorno ;
        }

        private void _randomClases()
        {
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            this.claseDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecarga de metodos

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases claseDelProfesor in i.claseDelDia)
            {
                if ( claseDelProfesor == clase )
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
