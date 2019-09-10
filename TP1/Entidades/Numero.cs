using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public string BinarioDecimal(string numero)
        {

            int numeroAConvertir;
            bool parseoExitoso = int.TryParse ( numero, out numeroAConvertir ); // convierto el "numero" para poder trabajar ya que es un string y es necesario realizar operaciones con numeros y no con el anterior mencionado.
            string binario = ""; // es el retorno. basicamente esta variable hace un "stack" de los resultados de las operaciones formando el numero binario deseado

            if ( !parseoExitoso )
            {
                numeroAConvertir = 0;
            }

            do
            {
                binario = string.Concat(Convert.ToString(numeroAConvertir % 2), binario);
                numeroAConvertir = numeroAConvertir / 2;

            } while (numeroAConvertir != 0);

             return binario;
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno;
            bool exito = double.TryParse(strNumero, out retorno);

            if ( !exito )
            {
                retorno = 0f;
            }

            return retorno;
        }
        
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if ( n1.numero == 0 || n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
