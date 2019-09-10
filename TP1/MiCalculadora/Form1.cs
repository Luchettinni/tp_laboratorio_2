using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        string result;
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero num2 = new Numero(txtNumero2.Text);
            Numero num1 = new Numero(txtNumero1.Text);

            result = Calculadora.Operar(num1, num2, cmbOperador.Text).ToString();
            lblResultado.Text = result;
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numBin = new Numero(lblResultado.Text);

            lblResultado.Text = numBin.BinarioDecimal(lblResultado.Text);
        }
    }
}
