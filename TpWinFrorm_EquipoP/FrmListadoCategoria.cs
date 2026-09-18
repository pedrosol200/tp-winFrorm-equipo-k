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
    public partial class FrmListadoCategoria : Form
    {
        public FrmListadoCategoria()
        {
            InitializeComponent();
        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                dgvCategorias.DataSource = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaCategoria ventana = new FrmAltaCategoria();
            ventana.ShowDialog();
            cargarCategorias();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmListadoCategoria_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {

                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> articulos = articuloNegocio.listar();
                int cantidad = articulos.Count(a => a.Categoria != null && a.Categoria.Id == seleccionada.Id);

                string mensaje = "¿Estás seguro de que querés eliminar la categoría " + seleccionada.Descripcion + "?";
                if (cantidad > 0)
                {
                    mensaje += "\n\n⚠️ Atención: Hay " + cantidad + " artículo(s) que usan esta categoría. " +
                               "Si la eliminás, esos artículos van a quedar SIN categoría.";
                }

                DialogResult respuesta = MessageBox.Show(mensaje, "Eliminar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    try
                    {
                        negocio.eliminar(seleccionada.Id);
                        MessageBox.Show("Categoría eliminada correctamente.");
                        cargarCategorias();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná una categoría.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                FrmAltaCategoria ventana = new FrmAltaCategoria(seleccionada);
                ventana.ShowDialog();
                cargarCategorias();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoria.");
            }
        }
    }
}
