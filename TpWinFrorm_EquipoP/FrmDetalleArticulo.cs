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
    public partial class FrmDetalleArticulo : Form
    {
        private Articulo articulo;
        private List<Imagen> imagenes;
        private int indice = 0;
        public FrmDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbImagen.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }

        private void FrmDetalleArticulo_Load(object sender, EventArgs e)
        {
            lblNombre.Text = articulo.Nombre;
            lblCodigo.Text = articulo.Codigo;
            lblPrecio.Text = articulo.Precio.ToString();
            lblDescripcion.Text = articulo.Descripcion;

            if (articulo.Marca != null)
                lblMarca.Text = articulo.Marca.ToString();
            else { lblMarca.Text = "Sin Marca"; }

            if (articulo.Categoria != null)
                lblCategoria.Text = articulo.Categoria.ToString();
            else { lblCategoria.Text = "Sin Categoria"; }

            ArticuloNegocio negocio = new ArticuloNegocio();
            imagenes = negocio.listarImagenes(articulo.Id);
            mostrarImagenActual();
        }
        private void mostrarImagenActual()
        {
            if(imagenes.Count > 0)
            {
                cargarImagen(imagenes[indice].ImagenUrl);
                lblContador.Text = (indice + 1) + " / " + imagenes.Count;

            }
            else
            {
                cargarImagen("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                lblContador.Text = "0 / 0";
            }

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (indice < imagenes.Count - 1)
            {
                indice++;
                mostrarImagenActual();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (indice > 0)
            {
                indice--;
                mostrarImagenActual();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
