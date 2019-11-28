using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaDelCorreoInstanciada()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }

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
