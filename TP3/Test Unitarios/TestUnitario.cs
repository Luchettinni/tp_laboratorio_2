using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciadas;
using Clases_Abstractas;
using System.Diagnostics;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class TestUnitario
    {
        /// <summary>
        /// TEST: valida excepciones ( verifica si el dni tiene formato correcto )
        /// </summary>
        [TestMethod]
        [ExpectedException (typeof(Excepciones.DniInvalidoException))]
        public void DNITest()
        {
            // este no deberia lanzar error.
            try
            {
                Alumno A1 = new Alumno(1, "Luciano", "Aranda", "42625103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                throw e;
            }

            // este si.

            try
            {
                Alumno A2 = new Alumno(1, "Kevin", "Ahumada", "4266.5103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// TEST: valida excepciones ( verifica si la nacionalidad coincide con el DNI de la persona )
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Excepciones.NacionalidadInvalidaException))]
        public void NacionalidadTest()
        {
            try
            {
                Alumno A3 = new Alumno(1, "Kevin", "Ahumada", "42665103", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// TEST: valida excepciones ( verifica si el dni tiene la cantidad de numeros permitidos )
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Excepciones.DniInvalidoException))]
        public void DNIExcedidoTest()
        {
            try
            {
                Alumno A4 = new Alumno(1, "Kevin", "Ahumada", "426695103", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void DNICambiadoTest()
        {
            try
            {
                Alumno A5 = new Alumno(1, "Brenda", "Frias", "00000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                A5.DNI = 50;
                A5.StringToDNI = "50243656";
                Assert.AreEqual(50243656, A5.DNI);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void NombreEsNulo()
        {

            Alumno A7 = new Alumno(1, "Brenda ", "Frias", "00000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsNull(A7.Nombre); // deberia ser null
            Assert.IsNotNull(A7.Apellido); // no deberia ser null

            Alumno A8 = new Alumno(1, "Luciano", "Cortese!", "50000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Assert.IsNull(A8.Apellido); // deberia ser null
            Assert.IsNotNull(A8.Nombre); // no deberia ser null
        }

    }
}
