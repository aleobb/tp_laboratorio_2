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
        private string archivo;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter str = new StreamWriter(this.archivo,true))
                {
                    str.WriteLine(datos);
                }
                return true;
            }
            catch
            {
                return retorno;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(out List<string> datos)
        {
            datos = new List<string>();
            bool retorno = false;
            string aux;

            try
            {
                using (StreamReader str = new StreamReader(this.archivo))
                {
                    while( ( aux=str.ReadLine() ) != null)
                    {
                        datos.Add(aux);
                    }
                }
                return true;
            }
            catch
            {
                return retorno;
            }
        }
    }
}
