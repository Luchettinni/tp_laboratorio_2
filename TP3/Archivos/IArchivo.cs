using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {

        #region Metodos

        /// <summary>
        /// Guardado de datos en un archivo
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>bool</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Cargado de datos de un archivo
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Variable en la cual se almacenaran los datos cargados del archivo</param>
        /// <returns>bool</returns>
        bool Leer(string archivo, out T datos);

        #endregion

    }
}
