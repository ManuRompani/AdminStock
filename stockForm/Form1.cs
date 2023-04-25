using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dominio;
using negocio;

namespace stockForm
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulos;
        private string rutaImagen;
        private string rutaImagenAux;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarStock();
            cargarComboBoxCampo();
        }

        private void cargarStock()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                listaArticulos = articuloNegocio.listar();
                dgvStcok.DataSource = listaArticulos;
                dgvStcok.Columns["Precio"].DefaultCellStyle.Format = "0.00";
                this.dgvStcok.Columns["UrlImagen"].Visible = false;
                this.dgvStcok.Columns["Id"].Visible = false;
                this.dgvStcok.Columns["Descripcion"].Visible = false;
                this.dgvStcok.Columns["Categoria"].Visible = false;
                cargarImagen(listaArticulos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                picboxStock.Load(imagen);
            }
            catch(Exception ex)
            {
                picboxStock.Load("https://www.cjoint.com/doc/20_12/JLFrj6Sanqu_image-not-found.png");
            }
        }



        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvStcok.CurrentRow == null)
            {
                MessageBox.Show("No hay articulo seleccionado");
            }
            else
            {
                Articulo articulo;
                articulo = (Articulo)dgvStcok.CurrentRow.DataBoundItem;
                rutaImagen = articulo.UrlImagen;
                ventanaDetalle detalle = new ventanaDetalle(articulo);
                detalle.ShowDialog();
                cargarStock();
                rutaImagenAux = articulo.UrlImagen;
                if (rutaImagen != rutaImagenAux && rutaImagen != "" && rutaImagen != null)
                    File.Delete(rutaImagen);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ventanaDetalle detalle = new ventanaDetalle();
            detalle.ShowDialog();
            cargarStock();
        }



        private void dgvStcok_SelectionChanged(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo)dgvStcok.CurrentRow.DataBoundItem;
            cargarImagen(articulo.UrlImagen);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvStcok.CurrentRow == null)
            {
                MessageBox.Show("No hay articulo seleccionado");
            }
            else
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo articulo = (Articulo)dgvStcok.CurrentRow.DataBoundItem;
                try
                {
                    DialogResult respuesta = MessageBox.Show("El articulo " + articulo.Nombre + " se eliminara permanentemente", "Eliminando", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.OK)
                    {
                        negocio.eliminar(articulo.Id);
                        cargarStock();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cargarComboBoxCampo()
        {
            cboxCampo.Items.Add("Codigo");
            cboxCampo.Items.Add("Nombre");
            cboxCampo.Items.Add("Precio");
            cboxCampo.Items.Add("Marca");
        }

        private void cboxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tboxAuxiliar.Text = null;
            tboxFiltro.AutoCompleteCustomSource = null;
            tboxAuxiliar.AutoCompleteCustomSource = null;
            lblAyuda.Visible = false;
            lblAuxiliar.Visible = false;
            tboxAuxiliar.Enabled = false;
            string opcion = cboxCampo.SelectedItem.ToString();

            if (opcion == "Codigo" || opcion == "Nombre")
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Comienza con");
                cboxCriterio.Items.Add("Contiene");
                cboxCriterio.Items.Add("Termina con");
            }
            else if(opcion == "Precio")
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Menor a");
                cboxCriterio.Items.Add("Entre");
                cboxCriterio.Items.Add("Mayor a");
            }
            else
            {
                cboxCriterio.Items.Clear();
                cboxCriterio.Items.Add("Categoria");
                cboxCriterio.Items.Add("Todos");
                autocompletar();
            }
        }

        private void cboxCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criterio = cboxCriterio.SelectedItem.ToString();

            if (criterio == "Entre")
            {
                tboxAuxiliar.Enabled = true;
                lblAyuda.Visible = true;
                lblAuxiliar.Visible = true;
                lblAyuda.Text = "Minimo";
                lblAuxiliar.Text = "Maximo";
            }
            else if (criterio == "Categoria")
            {
                tboxAuxiliar.Enabled = true;
                lblAyuda.Visible = true;
                lblAuxiliar.Visible = true;
                lblAyuda.Text = "Marca";
                lblAuxiliar.Text = "Categoria";
            }
            else
            {
                lblAyuda.Visible = false;
                lblAuxiliar.Visible = false;
                tboxAuxiliar.Enabled = false;
                tboxAuxiliar.Text = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboxCampo.SelectedItem != null && cboxCriterio.SelectedItem != null)
            {
                string campo = cboxCampo.SelectedItem.ToString();
                string criterio = cboxCriterio.SelectedItem.ToString();
                if (validarParametros(campo, criterio) == true)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    try
                    {
                        if (criterio == "Entre" || criterio == "Categoria")
                        {
                            string parametroA = tboxFiltro.Text;
                            string parametroB = tboxAuxiliar.Text;
                            dgvStcok.DataSource = negocio.filtro(campo, criterio, parametroA, parametroB);
                        }
                        else
                        {
                            string parametro = tboxFiltro.Text;
                            dgvStcok.DataSource = negocio.filtro(campo, criterio, parametro, "");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("El parametro de busqueda es incorrecto");
                }
      
            }
            else
            {
                MessageBox.Show("Hay campos vacios");
            }
        }

        public bool validarParametros(string campo, string criterio)
        {
            string cadena = tboxFiltro.Text; 
            if (campo == "Precio" || campo == "Marca")
            {
                if (string.IsNullOrEmpty(cadena))
                    return false;

                switch (criterio)
                {
                    case "Categoria":
                    case "Entre":
                        if(string.IsNullOrEmpty(tboxAuxiliar.Text))
                            return false;
                        if (campo == "Precio")
                        {
                            bool numerosValidos = validarNumeros(cadena) && validarNumeros(tboxAuxiliar.Text);
                            return numerosValidos;
                        }
                        return true;

                    default:
                        if (campo == "Precio")
                        {
                            bool numerosValidos = validarNumeros(cadena);
                            return numerosValidos;
                        }

                        return true;
                }
            }
            else
            {
                return true;
            }

        }

        public bool validarNumeros(string numero)
        {
                if (int.TryParse(numero, out int num))
                    return true;
                else
                    return false;
        }

        public void autocompletar()
        {
            AutoCompleteStringCollection listaColeccion;
            try
            {
                for(int i = 0; i < 2; i++)
                {
                    listaColeccion = new AutoCompleteStringCollection();
                    if(i== 0)
                    {
                        CategoriasNegocio negocioC = new CategoriasNegocio();
                        List<Categorias> listaC = negocioC.listarCategorias();
                        for (int j = 0; j < listaC.Count; j++)
                        {
                            listaColeccion.Add(listaC[j].Descripcion);
                        }
                        tboxAuxiliar.AutoCompleteCustomSource = listaColeccion;
                    }
                    else
                    {
                        MarcasNegocio negocioM = new MarcasNegocio();
                        List<Marcas> listaM = negocioM.listarMarcas();
                        for (int j = 0; j < listaM.Count; j++)
                        {
                            listaColeccion.Add(listaM[j].Descripcion);
                        }
                        tboxFiltro.AutoCompleteCustomSource = listaColeccion;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
