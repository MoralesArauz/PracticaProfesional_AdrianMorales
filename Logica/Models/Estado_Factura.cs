using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Estado_Factura : ICrudBase
    {
        //Atributos
        public int ID_Estado_Factura { get; set; }
        public String Descripcion { get; set; }
        public bool Estado { get; set; }

        private Factura[] factura { get; set; }
        public Estado_Factura() { }

        public Estado_Factura(int iD_Estado_Factura, string descripcion, bool estado)
        {
            ID_Estado_Factura = iD_Estado_Factura;
            Descripcion = descripcion;
            Estado = estado;
        }

        public bool Agregar()
        {
            throw new NotImplementedException();
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }
        public Estado_Factura ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Estado_Factura ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool VerActivo = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            R = MiCnn.DMLSelect("SPEstadoFacturaListarComboBox");
            return R;
        }

    }
}
