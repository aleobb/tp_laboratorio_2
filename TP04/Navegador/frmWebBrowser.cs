using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        private Descargador descargador;
        //private Thread t;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Haciendo clic en la opcion se abre el formulario del historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial formularioHistorial = new frmHistorial();
            formularioHistorial.Show();
        }



        /// <summary>
        /// valida que el link ingresado sea el correcto y lo guarda en el archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                if( this.validarUrl() )
                { 
                    this.descargador = new Descargador(new Uri(this.txtUrl.Text));
                    this.descargador.EventoFinDescarga += this.FinDescarga;
                    this.descargador.EventoProgresoDescarga += this.ProgresoDescarga;

                    Thread t = new Thread(descargador.IniciarDescarga);
                    t.Start();
                    if (!archivos.Guardar(this.txtUrl.Text))
                        MessageBox.Show("No se pudo guardar la url en el archivo de historial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("La url es invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la pagina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida que se ingrese una url valida y si hace falta la completa
        /// </summary>
        /// <returns></returns>
        private bool validarUrl()
        {
            bool retorno = true;
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI))
                retorno = false;
            //else if (!(Regex.IsMatch(txtUrl.Text, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w\?=.-]*)*\/?$")))
            else if (!(Regex.IsMatch(txtUrl.Text, @"^(http:\/\/|https:\/\/)(.*)$")))
            {
                if (this.txtUrl.Text.Substring(0, 8).ToLower() != "https://")
                    txtUrl.Text = "http://" + txtUrl.Text;
            }
            return retorno;
        }
    }
}
