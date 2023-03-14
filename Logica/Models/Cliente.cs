using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente : ICrudBase
    {
        public Cliente() 
        {
            MiCategoria = new Categoria_Cliente();
        }

        // Atributos
        public int ID_Cliente { get;set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono_1 { get; set; }
        public string Telefono_2 { get; set; }
        public double Balance { get; set; } = 0;
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public Categoria_Cliente MiCategoria { get; set; }



        // Funciones del CRUD
        public bool Agregar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula", Cedula));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", Nombre));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Apellido", Apellido));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", Direccion));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono1", Telefono_1));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono2", Telefono_2));
           
            // Debemos enviar el valor del IDCategoria por medio de la composición
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", MiCategoria.ID_Categoria_Cliente));

            // Se ejecuta el procedimiento almacenado
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPClienteAgregar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
        }

        public Cliente ConsultarPorID()
        {
            Cliente R = new Cliente();
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Cliente));

            DataTable retorno = MiCnn.DMLSelect("SPClienteConsultar");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                DataRow Fila = retorno.Rows[0];

                R.ID_Cliente = Convert.ToInt32(Fila["ID"]); ;
                R.Cedula = Convert.ToString(Fila["Cedula"]);
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Apellido = Convert.ToString(Fila["Apellido"]);
                R.Direccion = Convert.ToString(Fila["Direccion"]);
                
                R.Telefono_1 = Convert.ToString(Fila["Telefono_1"]);
                R.Telefono_2 = Convert.ToString(Fila["Telefono_2"]);

                R.Balance = Convert.ToDouble(Fila["Balance"]);

                R.Fecha_Creacion = DateTime.Parse(Convert.ToString(Fila["Fecha_Creacion"]));
                R.Estado = Convert.ToInt32(Fila["Estado"]) > 0;
                R.MiCategoria.ID_Categoria_Cliente = Convert.ToInt32(Fila["IDCategoria"]);
            }
            return R;
        }

        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Cliente));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPClienteEliminar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }

        public bool Modificar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Cliente));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula", Cedula));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", Nombre));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Apellido", Apellido));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", Direccion));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono1", Telefono_1));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono2", Telefono_2));
            
            // Debemos enviar el valor del IDRol por medio de la composición
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDCategoria", MiCategoria.ID_Categoria_Cliente));
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPClienteEditar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }

        public Cliente Consultar()
        {
            throw new System.Exception("Not implemented");
        }
        public Cliente ConsultarPorNombre()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool VerActivo = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivo));
            R = MiCnn.DMLSelect("SPClientesListar");
            return R;
        }
        public bool ConsultarBalanceCliente()
        {
            throw new System.Exception("Not implemented");
        }

        // Esto es para evitar que se ingrese mas de un usuario con la misma cedula
        public bool ConsultarPorCedula()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            //Asigna el valor de la cedula para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cedula", Cedula));

            DataTable retorno = MiCnn.DMLSelect("SPClienteConsultarPorCedula");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Cliente));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPClienteActivar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }

        private Cliente_Metodo_Pago[] cliente_Metodo_Pago;
        private Factura[] factura;

        
    }
}
