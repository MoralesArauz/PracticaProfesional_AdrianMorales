using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    interface ICrudBase
    {
        // Tiene los mantenimientos básicos de la base de datos.
        bool Agregar();
        bool Modificar();
        bool Eliminar();
        DataTable Listar();
    }
}
