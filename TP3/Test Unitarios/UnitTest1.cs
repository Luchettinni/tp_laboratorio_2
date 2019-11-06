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
            Alumno A1 = new Alumno(1, "Luciano", "Aranda", "42625103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno A2 = new Alumno(1, "Kevin", "Ahumada", "42665103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            A2.DNI = 50000000;
        }
    }
}
