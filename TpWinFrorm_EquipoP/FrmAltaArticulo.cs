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
    public partial class FrmAltaArticulo : Form
    {
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }

        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cbMarca.DataSource = marcaNegocio.listar();
                cbMarca.DisplayMember = "Descripcion";
                cbMarca.ValueMember = "Id";

                cbCategoria.DataSource = categoriaNegocio.listar();
                cbCategoria.DisplayMember = "Descripcion";
                cbCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Marca = (Marca)cbMarca.SelectedItem;
                nuevo.Categoria = (Categoria)cbCategoria.SelectedItem;
                if (txtUrlImagen.Text != "")
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = txtUrlImagen.Text;
                    nuevo.Imagenes.Add(img);
                }

                negocio.agregar(nuevo);
                MessageBox.Show("Artículo agregado correctamente.");
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

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            if(txtUrlImagen.Text != "")
            {
                cargarImagen(txtUrlImagen.Text);
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
    }
    
}
