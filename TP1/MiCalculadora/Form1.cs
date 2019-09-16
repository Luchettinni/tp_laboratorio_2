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
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero numBin = new Numero(lblResultado.Text);
                lblResultado.Text = numBin.DecimalBinario(lblResultado.Text);
                btnConvertirADecimal.Enabled = true;
                btnConvertirABinario.Enabled = false;
            }
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero numDec = new Numero(lblResultado.Text);
                lblResultado.Text = numDec.BinarioDecimal(lblResultado.Text);
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = true;
        }

        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private static double Operar(string numero2, string numero1, string operador)
        {
            Numero num2 = new Numero(numero1);
            Numero num1 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
    }
}
