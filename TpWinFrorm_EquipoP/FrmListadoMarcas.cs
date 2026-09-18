using Dominio;
using Negocio;
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
    public partial class FrmListadoMarcas : Form
    {
        public FrmListadoMarcas()
        {
            InitializeComponent();
        }
        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                dgvMarcas.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las marcas: " + ex.Message);
            }
        }
        private void btAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaMarcas ventana = new FrmAltaMarcas();
            ventana.ShowDialog();
            cargarMarcas();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                FrmAltaMarcas ventana = new FrmAltaMarcas(seleccionada);
                ventana.ShowDialog();
                cargarMarcas();
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná una marca.");
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés eliminar la marca " + seleccionada.Descripcion + "?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    try
                    {
                        negocio.eliminar(seleccionada.Id);
                        MessageBox.Show("Marca eliminada correctamente.");
                        cargarMarcas();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("No se puede eliminar la marca porque tiene artículos asociados. " +
                    "Primero cambiá la marca de esos artículos o eliminalos.");
                    }

                }

            }
            else
            {
                MessageBox.Show("Por favor, seleccioná una marca.");
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListadoMarcas_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }
    }
}
