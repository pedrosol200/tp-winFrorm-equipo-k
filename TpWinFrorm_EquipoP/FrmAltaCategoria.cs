using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TpWinFrorm_EquipoP
{
    public partial class FrmAltaCategoria : Form
    {
        private Categoria categoria = null;

        public FrmAltaCategoria()
        {
            InitializeComponent();
        }
        public FrmAltaCategoria(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
            this.Text = "Modificar Categoria";
        }
        private void FrmAltaCategoria_Load(object sender, EventArgs e)
        {
            if (categoria != null)
            {
                txtDescripcion.Text = categoria.Descripcion;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                if (categoria == null)
                    categoria = new Categoria();

                categoria.Descripcion = txtDescripcion.Text;

                if (categoria.Id == 0)
                {
                    negocio.agregar(categoria);
                    MessageBox.Show("Categoria agregada correctamente.");
                }
                else
                {
                    negocio.modificar(categoria);
                    MessageBox.Show("Categoria modificada correctamente.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
