using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;

namespace Registros.Empleados
{
   public partial class registro
    {
        public List<Puesto> ListarPuesto()
        {
            var datos = from p in db.Puesto
                        select p;

            return datos.ToList();
        }
    }
}
