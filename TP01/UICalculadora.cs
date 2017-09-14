using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ejecuta el calculo y muestra el resultado 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);

            lblResultado.Text = (Calculadora.Operar(num1, num2, cmbOperacion.Text)).ToString();
        }
        
        /// <summary>
        /// Limpia todos los campos incluido el operador y el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperacion.SelectedItem = "";
            txtNumero1.Select();
        }

    }
}
