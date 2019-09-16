using System;
using System.Diagnostics;

namespace Entidades
{
    public static class Calculadora
    {

        #region Validar Operador

        /// <summary>
        /// Valida que el valor pasado por parametro coincida con alguno de los elementos de un listado de "operadores"
        /// </summary>
        /// <param name="operador">es el elemento a ser validado</param>
        /// <returns>en caso que el parametro sea un "operador" valido, retornara el mismo. en caso contrario se retornara el operador "+"</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno;
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }

            return retorno;
        }

        #endregion

        #region Operar

        /// <summary>
        /// Realiza la operacion especificada a travez del tercer parametro entre dos numeros 
        /// </summary>
        /// <param name="num1">es un objeto que contiene uno de los numeros correspondientes a la operacion a realizar</param>
        /// <param name="num2">es un objeto que contiene uno de los numeros correspondientes a la operacion a realizar</param>
        /// <param name="operador">es ( y valga la redundancia ) el operador a ser validado y utilizado para la operacion entre los numeros</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno;

            operador = ValidarOperador(operador);

            switch ( operador )
            {
                case "-":
                {
                    retorno = num1 - num2;
                    break;
                }

                case "*":
                {
                    retorno = num1 * num2;
                    break;
                }

                case "/":
                {
                    retorno = num1 / num2;
                    break;
                }

                default:
                {
                    retorno = num1 + num2;
                    break;
                }
            }

            return retorno;
        }

        #endregion
    }
}
