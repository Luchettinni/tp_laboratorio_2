using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region constructores
        /// <summary>
        /// Constructor de la clase snacks
        /// </summary>
        /// <param name="marca">Es la marca del producto</param>
        /// <param name="codigo">Es el codigo del producto</param>
        /// <param name="color">Es el color del producto</param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color) { }
        #endregion

        #region propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra la marca, el codigo, el color y las calorias del producto.
        /// </summary>
        /// <returns>retorna una cadena conformada por todo los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.Append(base.Mostrar());

            return sb.ToString();
        }
        #endregion
    }
}
