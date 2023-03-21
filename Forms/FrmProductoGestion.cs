using Esperanza.Controls;
using Esperanza.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmProductoGestion : Form
    {
        private CtrlProductos padre { get; set; }
        private Logica.Models.Producto MiProducto { get; set; }

        private bool CargaInicial = true; 

        private const string rutaImagenDefault = "\\Resources\\imagenes\\default.png";
        public FrmProductoGestion()
        {
            InitializeComponent();
        }

        public FrmProductoGestion(CtrlProductos parent, Logica.Models.Producto producto)
        {
            InitializeComponent();
            MiProducto = producto;
            padre = parent;
          
        }

        private void LlenarFormulario() 
        {
            TxtCodigo.Text = MiProducto.Cod_Producto;
            TxtDescripcion.Text = MiProducto.Descripcion;
            CboxCategoria.SelectedValue = Convert.ToString(MiProducto.MiCategoria.ID_Categoria_Producto);
            TxtCosto.Text = Convert.ToString(MiProducto.Costo);
            TxtPrecio.Text = Convert.ToString(MiProducto.Precio);
            TxtUtilidad.Text = Convert.ToString(MiProducto.Utilidad);
            TxtFecha.Text = Convert.ToString(MiProducto.Fecha_Creacion);
            CboxActivo.Checked = MiProducto.Estado;
            TxtExistencias.Text = Convert.ToString(MiProducto.Cantidad);
        }

        private void FrmProductoGestion_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            if (MiProducto.Imagen is null)
            {
                CargarImagen();
            }
            LlenarFormulario();
            CargaInicial = false;
        }

        private void CargarImagen()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var imagenPath = outPutDirectory + rutaImagenDefault;//Path.Combine(outPutDirectory, rutaImagenDefault);
            Console.WriteLine("Image Path es igual a "+ outPutDirectory);
            string imagen_path = new Uri(imagenPath).LocalPath;

            PicBoxImagen.ImageLocation = imagen_path;
            PicBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Console.WriteLine("la ruta de la imagen es: "+PicBoxImagen.ImageLocation.ToString());
        }
        private void CargarCategorias()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable CategoriasProducto = MiProducto.MiCategoria.Listar();

            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Descripcion";

            // Se asigna el origen los datos que mostrará el ComboBox
            CboxCategoria.DataSource = CategoriasProducto;
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (!CargaInicial)
            {
                btnDatos.Enabled = true;
            }
            
        }

        private void CboxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CargaInicial)
            {
                btnDatos.Enabled = true;
            }
            
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                if (!TxtDescripcion.Text.Trim().Equals(MiProducto.Descripcion, StringComparison.OrdinalIgnoreCase))
                {
                    MiProducto.Descripcion = TxtDescripcion.Text.Trim().ToUpper();
                }
            }
            else
            {
                MessageBox.Show("El campo descripcion no puede quedar vacio", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtDescripcion.Focus();
            }
        }

        private void CboxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboxCategoria.SelectedIndex >= 0)
            {
                MiProducto.MiCategoria.ID_Categoria_Producto = Convert.ToInt32(CboxCategoria.SelectedValue);
            }
        }

        private void CboxActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (!CargaInicial)
            {
                if (CboxActivo.CheckState == CheckState.Checked)
                {
                    CambiarEstadoProducto(true);
                }
                else
                {
                    CambiarEstadoProducto(false);
                }
            }
        }

        private void CambiarEstadoProducto(bool activo)
        {
            if (activo)
            {
                DialogResult resultado =
                    MessageBox.Show(string.Format("Está seguro que desea activar al Producto: {0}?",
                                    MiProducto.Descripcion), "Activando",
                                    MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (MiProducto.Activar())
                    {
                        MessageBox.Show(string.Format("El producto {0} {1} se ha activado correctamente",
                            MiProducto.Cod_Producto, MiProducto.Descripcion), "Activado", MessageBoxButtons.OK);
                        // Como el usuario se activo, vuelve a cargar la lista de usuarios activos
                        padre.LlenarListaProductos(true);
                        padre.CboxVerActivos.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y no se pudo activar el producto", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // El check box se selecciono pero no se quiso activar al clienet, por lo que se vuelve a seleccionar
                    // los cambios en la variable carga inicial son para que no se ejecute el evento sobre el CBoxActivo
                    CargaInicial = true;
                    CboxActivo.Checked = false;
                    CargaInicial = false;
                }
            }
            else
            {
                // Verifica que el producto no tenga existencias de inventario
                if (MiProducto.Cantidad == 0) 
                {
                    DialogResult resultado =
                    MessageBox.Show(string.Format("Está seguro que desea inactivar el producto: {0}?",
                                    MiProducto.Descripcion), "Inactivando",
                                    MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        if (MiProducto.Eliminar())
                        {
                            MessageBox.Show(string.Format("El producto {0} {1} se ha inactivado correctamente",
                                MiProducto.Cod_Producto, MiProducto.Descripcion), "Inactivado", MessageBoxButtons.OK);
                            // Como el usuario se inactivo, vuelve a cargar la lista de usuarios inactivos
                            padre.LlenarListaProductos(false);
                            padre.CboxVerActivos.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se pudo inactivar el cliente", "Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        // El check box se deselecciono pero no se quiso inactivar al cliente, por lo que se vuelve a seleccionar
                        // los cambios en la variable carga inicial son para que no se ejecute el evento sobre el CBoxActivo
                        CargaInicial = true;
                        CboxActivo.Checked = true;
                        CargaInicial = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se puede inactivar el producto " 
                        + MiProducto.Descripcion 
                        + " puesto que tiene " 
                        + MiProducto.Cantidad 
                        + " en existencias");
                    // El check box se deselecciono pero no se quiso inactivar al cliente, por lo que se vuelve a seleccionar
                    // los cambios en la variable carga inicial son para que no se ejecute el evento sobre el CBoxActivo
                    CargaInicial = true;
                    CboxActivo.Checked = true;
                    CargaInicial = false;
                }
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MiProducto.Descripcion) && MiProducto.MiCategoria.ID_Categoria_Producto >= 0)
            {
                if (MiProducto.Modificar())
                {
                    MessageBox.Show("El producto "+MiProducto.Descripcion+" se ha modificado",
                        "Modificado", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Una vez modificado el producto vuelve a llenar la lista
                    padre.LlenarListaProductos(MiProducto.Estado);
                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el producto","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRecalcularCPU_Click(object sender, EventArgs e)
        {
            try
            {
                MiProducto.Costo = Math.Round(Convert.ToDouble(TxtCosto.Text.Trim()),4);
                MiProducto.Precio = Math.Round(Convert.ToDouble(TxtPrecio.Text.Trim()),4);
                MiProducto.Utilidad = Math.Round(Convert.ToDouble(TxtUtilidad.Text.Trim()),4);
                if (MiProducto.ActualizarPrecioCostoUtilidad())
                {
                    MessageBox.Show("El costo, precio y utilidad del producto se han actualizado"
                        ,"Actualizado"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation);
                    btnRecalcularCPU.Enabled = false;

                }
                else
                {
                    MessageBox.Show("No se pudieron actualizar los datos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error de conversion: " + fe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetaerCostoPrecioUtilidad();
            }
        }

        // Reinicia los controles en caso de que se quiera editar precio, costo o utilidad
        private void button1_Click(object sender, EventArgs e)
        {
            ResetaerCostoPrecioUtilidad();
        }

        private void ResetaerCostoPrecioUtilidad()
        {
            TxtCosto.Text = Convert.ToString(MiProducto.Costo);
            TxtCodigo.Enabled = true;
            TxtPrecio.Text = Convert.ToString(MiProducto.Precio);
            TxtPrecio.Enabled = true;
            TxtUtilidad.Text = Convert.ToString(MiProducto.Utilidad);
            TxtUtilidad.Enabled = true;
            btnRecalcularCPU.Enabled = false;
        }
        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            if (!btnRecalcularCPU.Enabled)
            {
                btnRecalcularCPU.Enabled = true;
            }
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!btnRecalcularCPU.Enabled)
            {
                btnRecalcularCPU.Enabled = true;
            }
        }

        // Evita que se escriban caracteres que no son numericos
        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        // Evita que se escriban caracteres que no son numericos
        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        private double CalcularPrecio()
        {
            double precio = 0;
            try
            {
                double utilidad = Convert.ToDouble(TxtUtilidad.Text.Trim()) / 100;
                double costo = Convert.ToDouble(TxtCosto.Text.Trim());
                precio = Math.Round((-1 * costo) / (utilidad - 1), 4);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Error de conversion: "+ e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ResetaerCostoPrecioUtilidad();
                precio = MiProducto.Precio;
            }
            
            return precio;
        }

        private double CalcularUtilidad() 
        {
            double utilidad = 0;
            try
            {
                double precio = Convert.ToDouble(TxtPrecio.Text.Trim());
                double costo = Convert.ToDouble(TxtCosto.Text.Trim());
                if (precio >= costo) 
                {
                    utilidad = Math.Round(100 * ((precio - costo) / precio), 4);
                }
                else
                {
                    MessageBox.Show("El precio no puede ser menor que el costo","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    utilidad = MiProducto.Utilidad;
                    TxtPrecio.Focus();
                }
                
            }
            catch (FormatException e)
            {
                MessageBox.Show("Error de conversion: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetaerCostoPrecioUtilidad();
                utilidad = MiProducto.Utilidad;
            }

            return utilidad;
        }

        private void TxtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        private void TxtCosto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCosto.Text.Trim()))
            {
                TxtPrecio.Text = Convert.ToString(CalcularPrecio());
            }
            else
            {
                MessageBox.Show("El costo no puede estar vacio","Error",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtCosto.Focus();
                TxtCosto.SelectAll();
            }
        }

        private void TxtPrecio_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                TxtUtilidad.Text = Convert.ToString(CalcularUtilidad());
            }
            else
            {
                MessageBox.Show("El precio no puede estar vacio", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtPrecio.Focus();
                TxtPrecio.SelectAll();  
            }
        }

        private void TxtUtilidad_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUtilidad.Text.Trim()))
            {
                if (Convert.ToDouble(TxtUtilidad.Text.Trim()) < 100)
                {
                    TxtPrecio.Text = Convert.ToString(CalcularPrecio());
                }
                else
                {
                    MessageBox.Show("La utilidad no puede ser mayor o igual a 100%", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    TxtUtilidad.Focus();
                    TxtUtilidad.SelectAll();
                }
                
            }
            else
            {
                MessageBox.Show("La utilidad no puede estar vacia", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                TxtUtilidad.Focus();
                TxtUtilidad.SelectAll();    
            }
        }

        private void TxtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnRecalcularCPU.Focus();
        }

        private void TxtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnRecalcularCPU.Focus();
        }

        private void TxtUtilidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                btnRecalcularCPU.Focus();
        }

        private void TxtUtilidad_TextChanged(object sender, EventArgs e)
        {
            if (!btnRecalcularCPU.Enabled)
            {
                btnRecalcularCPU.Enabled = true;
            }
        }
    }
}
