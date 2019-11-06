using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciadas;
using Clases_Abstractas;
using System.Diagnostics;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PersonaTest()
        {
            Alumno A1 = new Alumno(1, "Luciano", "Aranda", "42.625.103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno A2 = new Alumno(2, "Kevin", "Ahumada", "42.626.106", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Profesor P1 = new Profesor(3, "juampi", "alonzo", "15.525.255", Persona.ENacionalidad.Argentino);

            Jornada programacion = new Jornada( Universidad.EClases.Programacion, P1);

            programacion += A1;
            programacion += A2;


            Assert.IsTrue(programacion.guardar(programacion));

            string lector = programacion.Leer();
            Assert.IsNotNull(lector);
        }
    }
}
