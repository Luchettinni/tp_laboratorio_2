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

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = new Paquete(txtDireccion.Text , mtxtTrackingID.Text);
                paquete.informaEstado += this.paq_InformaEstado;
                PaqueteDAO.informarExcepcion += this.paq_Exception;
                this.correo += paquete;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e} );
            }
            else
            {
                ActualizarEstados();

            }
        }

        private void paq_Exception(string mensaje)
        {
             MessageBox.Show(mensaje);
        }

        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach(Paquete paquete in correo.Paquetes)
            {
                switch(paquete.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>( (IMostrar<List<Paquete>>)correo );
        }

        private void MostrarToolStripMenu_Click(object sender, EventArgs e)
        {
            if ( lstEstadoEntregado.SelectedIndex >-1)
            this.MostrarInformacion<Paquete>( (IMostrar<Paquete>)lstEstadoEntregado.SelectedItem );
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if ( elemento != null )
            {
                this.rtbMostrar.Clear();
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    this.rtbMostrar.Text.Guardar("Salida.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
