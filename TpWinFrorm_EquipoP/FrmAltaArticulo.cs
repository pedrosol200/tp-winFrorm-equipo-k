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
        private Articulo articulo = null;
        private List<Imagen> imagenes = new List<Imagen>();
        private int indice = 0;
        public FrmAltaArticulo()
        {
            InitializeComponent();
        }
        public FrmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.Text = "Modificar Artículo";
        }

        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            if (articulo == null || articulo.Id == 0)
            {
                btnAgregarImagen.Visible = false;
                btnEliminarImagen.Visible = false;
                btnSiguiente.Visible = false;
                btnAtras.Visible = false;
                lblContador.Visible = false;
            }

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

                if(articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    if (articulo.Marca != null)
                    {
                        cbMarca.SelectedValue = articulo.Marca.Id;
                    }
                    if (articulo.Categoria != null)
                    {
                        cbCategoria.SelectedValue = articulo.Categoria.Id;
                    }

                    ArticuloNegocio negocio = new ArticuloNegocio();
                    imagenes = negocio.listarImagenes(articulo.Id);
                    mostrarImagenActual();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void mostrarImagenActual()
        {
            if (imagenes.Count > 0)
            {
                cargarImagen(imagenes[indice].ImagenUrl);
                txtUrlImagen.Text = imagenes[indice].ImagenUrl;
                lblContador.Text = (indice + 1) + " / " + imagenes.Count;
            }
            else
            {
                cargarImagen("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                txtUrlImagen.Text = "";
                lblContador.Text = "0 / 0";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese un codigo para el articulo.", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el articulo.", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripcion para el articulo.", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Por favor, ingrese un precio valido (solo numeros).", "Precio invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Marca = (Marca)cbMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbCategoria.SelectedItem;

                if (txtUrlImagen.Text != "")
                {
                    Imagen img = new Imagen();
                    img.ImagenUrl = txtUrlImagen.Text;

                    if (articulo.Id == 0)
                    {
                        articulo.Imagenes.Add(img);
                    }
                }

                if (articulo.Id == 0)
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Artículo agregado correctamente");
                }
                else
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Artículo modificado correctamente.");
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

        private void btnAtras_Click(object sender, EventArgs e)
        {

            if (indice > 0)
            {
                indice--;
                mostrarImagenActual();
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (articulo == null || articulo.Id == 0)
            {
                MessageBox.Show("Primero guarde el artículo antes de agregar imagenes.");
                return;
            }
            if (txtUrlImagen.Text == "")
            {
                MessageBox.Show("Por favor, escriba una URL antes de agregar.");
                return;
            }
            try
            {
                pbImagen.Load(txtUrlImagen.Text);
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.agregarImagen(articulo.Id, txtUrlImagen.Text);

                Imagen nueva = new Imagen();
                nueva.IdArticulo = articulo.Id;
                nueva.ImagenUrl = txtUrlImagen.Text;
                imagenes.Add(nueva);

                indice = imagenes.Count - 1;
                mostrarImagenActual();

                MessageBox.Show("Imagen agregada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("La URL parece no ser valida, revise antes de volver a cargar...");
            }
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (imagenes.Count == 0)
            {
                MessageBox.Show("No hay imagenes para eliminar.");
                return;
            }
            DialogResult respuesta = MessageBox.Show("Esta seguro de Eliiminar la Imagen?", "Eliminar Imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(respuesta == DialogResult.Yes)
            {
                try
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarImagen(imagenes[indice].Id);

                    imagenes.RemoveAt(indice);

                    if(indice >= imagenes.Count)
                    {
                        indice = imagenes.Count - 1;
                    }
                    if (imagenes.Count == 0)
                    {
                        indice = 0;
                        cargarImagen("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
                        txtUrlImagen.Text = "";
                        lblContador.Text = "0 / 0";
                    }
                    else
                    {
                        mostrarImagenActual();
                    }
                    MessageBox.Show("Imagen eliminada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
    
}
