using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>

    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        EMarca marca;

        #region constructores
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region propiedades
        /// <summary> 
        /// ReadOnly: Retornará la cantidad de calorias
        /// </summary>
        protected virtual short CantidadCalorias { get { return 0; } }
        #endregion

        #region metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>retorna una cadena conformada por todo los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string) this;
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// sobrecarga del operador string, muestra todos los datos del producto
        /// </summary>
        /// <param name="p">es el producto del cual se extraeran sus caracteristicas para mostrarlas</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendFormat("CALORIAS : {0}\n", p.CantidadCalorias);
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">producto a comparar</param>
        /// <param name="v2">producto a comparar</param>
        /// <returns>true si son iguales, false si no son iguales</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return ( Object.Equals( v1.codigoDeBarras, v2.codigoDeBarras) );
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">producto a comparar</param>
        /// <param name="v2">producto a comparar</param>
        /// <returns>true no son iguales, false si son iguales</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }
        #endregion
    }
}
