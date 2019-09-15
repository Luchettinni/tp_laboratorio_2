using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region SetNumero
        
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Conversores


        /// <summary>
        /// Convierte un numero "binario" a "decimal", verificando que se el numero a trabajar sea obviamente "binario".
        /// </summary>
        /// <param name="binario">es el valor que sera verificado de ser binario y trabajado para su conversion decimal</param>
        /// <returns>si el numero es binario retorna su conversion a decimal, si no es binario retornara "Numero Invalido"</returns>
        public string BinarioDecimal(string binario)
        {

            int numeroOriginal = 0;
            int retornoDecimal = 0;
            string retorno = "Numero Invalido";
            int potencia = 0;

            bool EsBinario = true;
            // es necesario verificar que el numero sea ( o se parezca a ) un numero binario. 
            // de lo contrario los resultados de la conversion van a ser completamente erroneos y/o aleatorios
            for ( int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    // si el numero no es ni un cero ni un uno, no es un numero binario.
                    EsBinario = false;
                    break;
                }
            }
            
            if( EsBinario ) // si el numero resultó ser binario...
            {
                for (int indice = binario.Length - 1; indice >= 0; indice--)
                {
                    numeroOriginal = (int)char.GetNumericValue(binario[indice]);
                    if (numeroOriginal == 0 && potencia == 0)
                    {
                        // por alguna razon que no entiendo, CERO multiplicado por 2 elvado a la cero da UNO...
                        // este if arregla ese pequeño error.
                        retornoDecimal += 0; 
                    }
                    else
                    {
                        retornoDecimal += (int)Math.Pow((numeroOriginal * 2), potencia);
                    }
                    potencia++;
                }
                retorno = retornoDecimal.ToString();
            }

            return retorno;
        }
        

        /// <summary>
        /// Convierte un numero "decimal" a "binario", verificando que se el numero a trabajar sea positivo y entero.
        /// </summary>
        /// <param name="numero">es el valor que sera verificado de ser positivo y entero para ser trabajado en su conversion binaria</param>
        /// <returns>si es positivo y entero, retornara su conversion. en caso contrario retornara "Numero Invalido"</returns>
        public string DecimalBinario(string numero)
        {

            double numeroOriginalAux = -1;
            int numeroOriginal;
            string retornoEnBinario = "";


            // verifico que el numero no contenga letras, simbolos o sea un numero con coma.
            bool parseoExitoso = double.TryParse(numero, out numeroOriginalAux);
            numeroOriginalAux = Math.Round(numeroOriginalAux);

            numeroOriginal = (int) numeroOriginalAux;

            // y con esto tambien verifico que no sea negativo...
            if (!parseoExitoso || numeroOriginal < 0)
            {
                // si entro en este if, quiere decir que el numero no es valido para su conversion.
                retornoEnBinario = "Numero Invalido";
                numeroOriginal = -1;
            }

            if ( numeroOriginal != -1 ) // si es valido...
            {
                do
                {
                    // el resto del numero original es lo que me va a formar el numero binario.
                    retornoEnBinario = string.Concat(Convert.ToString(numeroOriginal % 2), retornoEnBinario);
                    // obviamente, para que exista un "resto" tiene que existir una "division".
                    numeroOriginal = numeroOriginal / 2;

                } while (numeroOriginal != 0); 

                // cuando el numero se dividio tantas veces que su ultimo resultado fue CERO,
                // entonces el numero fue satisfactoriamente convertido.
            }

            return retornoEnBinario;
        }


        /// <summary>
        /// Convierte un numero "decimal" a "binario", verificando que se el numero a trabajar sea positivo y entero.
        /// </summary>
        /// <param name="numero">es el valor que sera verificado de ser positivo y entero para ser trabajado en su conversion binaria</param>
        /// <returns>si es positivo y entero, retornara su conversion. en caso contrario retornara "Numero Invalido"</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase "Numero" que inicializa a su atributo "numero" en cero por default.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }


        /// <summary>
        /// Constructor de la clase "Numero" que inicializa a su atributo "numero" con el valor pasado por parametro.
        /// </summary>
        /// <param name="numero">es el valor que va a tomar el atributo de la clase "Numero"</param>
        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }


        /// <summary>
        /// Constructor de la clase "Numero" que inicializa a su atributo "numero" con el valor pasado por parametro.
        /// </summary>
        /// <param name="strNumero">es el valor que va a tomar el atributo de la clase "Numero"</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        #endregion

        #region Sobrecarga de operadores
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
            if ( n2.numero == 0 )
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        #endregion

        #region Validacion de numero
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            bool exito = double.TryParse(strNumero, out retorno);

            if (!exito)
            {
                retorno = 0f;
            }

            return retorno;
        }
        #endregion
    }
}
