using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        private List<string> historialWebs;

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cuando se abre el formulario se muestran las paginas webs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            this.historialWebs = new List<string>();
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            if( archivos.Leer(out this.historialWebs) && !object.ReferenceEquals(this.historialWebs,null) )
            {
                foreach(string url in this.historialWebs)
                {
                    if (url!= null)
                      lstHistorial.Items.Add(url);
                }
            }
            else
            {
                lstHistorial.Text = "NO SE PUDO CARGAR LA LISTA DE PAGINAS WEBS ";
            }
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
