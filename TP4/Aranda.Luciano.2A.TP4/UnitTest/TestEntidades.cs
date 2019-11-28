using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class TestEntidades
    {
        /// <summary>
        /// realiza una prueba la cual consiste en verificar que la lista de paquetes en correo este instanciada.
        /// </summary>
        [TestMethod]
        public void ListaDelCorreoInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// verifica si se puede añadir dos paquetes con mismo ID a un correo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException), "Tracking id repetido")]
        public void IgualTrackingID()
        {
            Correo correo = new Correo();
            Paquete a = new Paquete("A5551", "0000000001");
            Paquete b = new Paquete("A5552", "0000000001");
            
            correo += a;
            correo += b;

            //Paquete c = new Paquete("A5551", "0000000001"); 
            //correo += c;
        }
    }
}
