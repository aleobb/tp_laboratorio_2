using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void delegadoProgresoDescarga(int num);
        public event delegadoProgresoDescarga EventoProgresoDescarga;

        public delegate void delegadoFinDescarga(string str);
        public event delegadoFinDescarga EventoFinDescarga;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.EventoProgresoDescarga.Invoke(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                // this.html = e.Result;
                this.EventoFinDescarga.Invoke(e.Result);
            }
            else
                this.EventoFinDescarga.Invoke("LA DESCARGA NO SE COMPLETO");
        }
    }
}
