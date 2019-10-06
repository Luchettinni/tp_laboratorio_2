using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        
        public enum ETipo { Entera, Descremada }
        ETipo tipo;

        #region constructores
        /// <summary>
        /// Constructor de la clase Leche
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Es la merca del producto</param>
        /// <param name="codigo">Es el codigo del producto</param>
        /// <param name="color">Es el color del producto</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
            tipo = ETipo.Entera;
        }
        /// <summary>
        /// Constructor de la clase Leche, con el tipo de leche especificado.
        /// </summary>
        /// <param name="marca">Es la merca del producto</param>
        /// <param name="codigo">Es el codigo del producto</param>
        /// <param name="color">Es el color del producto</param>
        /// <param name="tipoD">Es el tipo de leche del producto</param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipoD) : base(codigo, marca, color)
        {
            tipo = tipoD;
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra la marca, el codigo, el color, las calorias y el tipo de leche del producto.
        /// </summary>
        /// <returns>retorna una cadena conformada por todo los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.Append(base.Mostrar());

            return sb.ToString();
        }
        #endregion
    }
}
