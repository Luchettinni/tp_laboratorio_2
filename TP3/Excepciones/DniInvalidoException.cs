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

        public DniInvalidoException() : base()
        {
            this.mensajeBase = base.Message;
        }

        public DniInvalidoException(Exception e) : base(e.Message, e)
        {

        }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }

    }
}
