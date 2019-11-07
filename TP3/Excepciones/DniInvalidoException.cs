using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        string mensajeBase;

        public DniInvalidoException() : base("DNI invalido: caracteres invalidos, excedio el rango o no lo pudo superar")
        {
            
        }

        public DniInvalidoException(Exception e) : base("DNI invalido: caracteres invalidos, excedio el rango o no lo pudo superar", e)
        {
            mensajeBase = e.Message;
        }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {
            mensajeBase = e.Message;
        }

    }
}
