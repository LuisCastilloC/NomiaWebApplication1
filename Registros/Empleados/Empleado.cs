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
        DBNOMINA2022Entities db = new DBNOMINA2022Entities();

        public List<Conexion.Empleados> Listar()
        {
            var datos = from q in db.Empleados
                        orderby q.idNumEmpleado
                        select q;

            return datos.ToList();
        }



        public bool Insertar(Conexion.Empleados c)
        {
            db.spInsertEmpleado(c.Nombre, c.Apellidos, c.Direccion, c.Telefono, c.RFC, c.Correo, c.idDepartamento, c.Dias_asistidos, c.idPuesto);
            return false;
        }
    }
}
