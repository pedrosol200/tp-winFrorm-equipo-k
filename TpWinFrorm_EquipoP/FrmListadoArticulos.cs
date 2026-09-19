using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinFrorm_EquipoP
{
    public partial class FrmListadoArticulos : Form
    {
        private List<Articulo> listaArticulos;
        public FrmListadoArticulos()
        {
            InitializeComponent();
        }

        private void FrmListadoArticulos_Load(object sender, EventArgs e)
        {
            cargarArticulos();
            cargarFiltros();
        }

        private void cargarFiltros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.ValueMember = "Id";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                //dgvArticulos.Columns["Imagenes"].Visible = false;

                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Imagen> imagenes = negocio.listarImagenes(seleccionado.Id);

                if(imagenes.Count > 0)
                {
                    cargarImagen(imagenes[0].ImagenUrl);
                }
                else
                {
                    pbImagen.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                }
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbImagen.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow.DataBoundItem != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés eliminar el artículo " + seleccionado.Nombre + "?", "Eliminar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    try
                    {
                        negocio.eliminar(seleccionado.Id);
                        MessageBox.Show("Articulo eliminado correctamente.");
                        cargarArticulos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un articulo de la lista.");
            }
        }

  
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (listaArticulos == null) return;
            List<Articulo> listaFiltrada;
            string filtro = txtBuscar.Text;

            if (filtro != "")
            {
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Codigo.ToLower().Contains(filtro.ToLower()));
            }
            else
            {
                listaFiltrada = listaArticulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo ventana = new FrmAltaArticulo();
            ventana.ShowDialog();

            cargarArticulos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                ArticuloNegocio negocio = new ArticuloNegocio();
                seleccionado.Imagenes = negocio.listarImagenes(seleccionado.Id);

                FrmAltaArticulo ventana = new FrmAltaArticulo(seleccionado);
                ventana.ShowDialog();
                cargarArticulos();

            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un artículo.");
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                ArticuloNegocio negocio = new ArticuloNegocio();
                seleccionado.Imagenes = negocio.listarImagenes(seleccionado.Id);
                FrmDetalleArticulo ventana = new FrmDetalleArticulo(seleccionado);
                ventana.ShowDialog();
                cargarArticulos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un artículo.");
            }
        }
    }
}
