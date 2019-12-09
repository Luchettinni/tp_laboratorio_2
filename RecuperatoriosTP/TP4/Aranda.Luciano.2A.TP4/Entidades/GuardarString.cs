using System;
using System.IO;

namespace Entidades
{
    public static class GuardarString 
    {
        #region Metodos

        /// <summary>
        /// Guarda en el escritorio un archivo de texto, si el archivo existe, agrega informacion en el.
        /// </summary>
        /// <param name="texto">Datos a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>True si logro guardar el archivo sin ningun problema</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";
                StreamWriter guardado = new StreamWriter(path + archivo, true);
                guardado.WriteLine(texto);
                guardado.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
