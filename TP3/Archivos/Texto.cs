using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        #region Metodos

        /// <summary>
        /// Guardado de datos en un archivo de texto
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>true si logro guardar el archivo sin ningun problema, false caso contrario</returns>
        bool IArchivo<string>.Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Cargado de datos de un archivo de texto
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Variable en la cual se almacenaran los datos cargados del archivo</param>
        /// <returns>true si logro leer los datos sin ningun problema, false caso contrario</returns>
        bool IArchivo<string>.Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
                return true;
            }
            catch (Exception)
            {
                datos = null;
                return false;
            }
        }

        #endregion

    }
}
