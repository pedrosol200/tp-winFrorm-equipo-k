using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TpWinFrorm_EquipoP
{
    public partial class FrmAltaMarcas : Form
    {
        private Marca marca = null;

        public FrmAltaMarcas()
        {
            InitializeComponent();
        }
        public FrmAltaMarcas(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
            this.Text = "Modificar Marca";
        }

        private void FrmAltaMarcas_Load(object sender, EventArgs e)
        {
            if (marca != null)
            {
                txtDescripcion.Text = marca.Descripcion;
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                if (marca == null)
                    marca = new Marca();

                marca.Descripcion = txtDescripcion.Text;

                if (marca.Id == 0)
                {
                    negocio.agregar(marca);
                    MessageBox.Show("Marca agregada correctamente.");
                }
                else
                {
                    negocio.modificar(marca);
                    MessageBox.Show("Marca modificada correctamente.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
