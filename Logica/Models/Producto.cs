using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto : ICrudBase
    {
        public int ID_Producto { get; set; }
        public string Cod_Producto { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Utilidad { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public double Cantidad { get; set; } = 0;
        public string Descripcion { get; set; }

        public bool Estado { get; set; }    

        public Categoria_Producto MiCategoria { get; set; }

        private Producto_Ingreso[] producto_Ingresos;
        private Producto_Factura[] producto_Factura;

        public Producto() 
        {
            MiCategoria = new Categoria_Producto();
        }

        public bool Agregar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Codigo", Cod_Producto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", Descripcion));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Costo", Costo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", Precio));
            // Debemos enviar el valor del IDCategoria por medio de la composición
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", MiCategoria.ID_Categoria_Producto));

            // Se ejecuta el procedimiento almacenado
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPProductoAgregar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }
        public bool Modificar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Producto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descripcion", Descripcion));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", MiCategoria.ID_Categoria_Producto));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoEditar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Producto));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoEliminar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }
        public Producto ConsultarPorID()
        {
            Producto R = new Producto();
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Producto));

            DataTable retorno = MiCnn.DMLSelect("SPProductoConsultarPorID");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                DataRow Fila = retorno.Rows[0];

                R.ID_Producto = Convert.ToInt32(Fila["ID_Producto"]); 
                R.Cod_Producto = Convert.ToString(Fila["Cod_Producto"]);
                R.Descripcion = Convert.ToString(Fila["Descripcion"]);
                R.Costo = Convert.ToDouble(Fila["Costo"]);
                R.Precio = Convert.ToDouble(Fila["Precio"]);
                // Se hace un redondeo porque al realizar la conversion esta agregando mas decimales de los que se obtienen
                // de la base de datos
                R.Utilidad = Math.Round( Convert.ToDouble(Fila["Utilidad"]),4);
                //R.Imagen = Convert.ToString(Fila["Imagen"]);
                R.Fecha_Creacion = DateTime.Parse(Convert.ToString(Fila["Fecha_Creacion"]));
                R.MiCategoria.ID_Categoria_Producto = Convert.ToInt32(Fila["ID_Categoria_Producto"]);
                R.Cantidad = Convert.ToDouble(Fila["Cantidad"]);
                R.Estado = Convert.ToInt32(Fila["Estado"]) > 0;
            }
            return R;
        }
        public Producto ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }

        // Retorna la lista de productos definida en una vista en la base de datos
        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivos));
            R = MiCnn.DMLSelect("SPProductosListar");
            return R;
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Codigo: {0}\nCosto: {1}\nPrecio: {2}\nCategoria: {3}\nDescripcion: {4}",
                Cod_Producto, Costo, Precio, MiCategoria.ID_Categoria_Producto, Descripcion);
        }

        // Recibe un parametro en caso que seguida de esta consulta se quiera obtener los valores del producto por medio del metodo
        // ConsultarPorID()
        public bool ConsultarPorCodigo(bool retornarProducto = false)
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Codigo", Cod_Producto));

            DataTable retorno = MiCnn.DMLSelect("SPProductoConsultarPorCodigo");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                // Esto es por si se quieren traer todos los datos de este producto, una vez se ha confirmado que existe
                if (retornarProducto)
                {
                    DataRow Fila = retorno.Rows[0];
                    ID_Producto = Convert.ToInt32(Fila["ID_Producto"]);
                }
                
                R = true;
            }
            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Producto));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoActivar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }

        public bool ActualizarPrecioCostoUtilidad()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Producto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Costo", Costo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", Precio));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Utilidad", Utilidad));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoActualizarCostoPrecioUtilidad");

            if (retorno == 1)
            {
                R = true;
            }


            return R;
        }

    }
}
