using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinFrorm_EquipoP
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btArticulos_Click(object sender, EventArgs e)
        {
            FrmListadoArticulos ventana = new FrmListadoArticulos();
            ventana.ShowDialog();
        }

        private void btMarcas_Click(object sender, EventArgs e)
        {
            FrmListadoMarcas ventana = new FrmListadoMarcas();
            ventana.ShowDialog();
        }

        private void btCategorias_Click(object sender, EventArgs e)
        {
            FrmListadoCategoria ventana = new FrmListadoCategoria();
            ventana.ShowDialog();
        }
    }
}
