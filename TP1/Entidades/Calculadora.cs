using System;
using System.Diagnostics;

namespace Entidades
{
    public static class Calculadora
    {
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
    }
}
