using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {

        #region Metodos

        /// <summary>
        /// Guardado de datos en un archivo xml
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>true si logro guardar el archivo sin ningun problema, false caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer ser = new XmlSerializer( typeof(T) );
                ser.Serialize(writer, datos);
                writer.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        /// <summary>
        /// Cargado de datos de un archivo xml
        /// </summary>
        /// <param name="archivo">Ubicacion del archivo</param>
        /// <param name="datos">Variable en la cual se almacenaran los datos cargados del archivo</param>
        /// <returns>true si logro leer los datos sin ningun problema, false caso contrario</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T) ser.Deserialize(reader);
                reader.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = default;
                throw e;
            }
        }

        #endregion

    }
}
