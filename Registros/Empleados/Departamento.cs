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
        public List<Departamento> ListarDepartamento()
        {
            var datos = from p in db.Departamento
                            select p;

            return datos.ToList();
        }
    }
}
