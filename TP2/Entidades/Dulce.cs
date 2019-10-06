using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region constructores
        /// <summary>
        /// Constructor de la clase dulce
        /// </summary>
        /// <param name="marca">Es la merca del producto</param>
        /// <param name="codigo">Es el codigo del producto</param>
        /// <param name="color">Es el color del producto</param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo,marca,color)
        {
            
        }
        #endregion

        #region propiedades
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra la marca, el codigo, el color, las calorias del producto.
        /// </summary>
        /// <returns>retorna una cadena conformada por todo los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.Append(base.Mostrar());

            return sb.ToString();
        }
        #endregion
    }
}
