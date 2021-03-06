//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conexion
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBNOMINA2022Entities : DbContext
    {
        public DBNOMINA2022Entities()
            : base("name=DBNOMINA2022Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
    
        public virtual int spInsertEmpleado(string nombre, string apellidos, string direccion, string telefono, string rFC, string correo, Nullable<int> idDepartamento, Nullable<int> dias_asistidos, Nullable<int> idPuesto)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidosParameter = apellidos != null ?
                new ObjectParameter("Apellidos", apellidos) :
                new ObjectParameter("Apellidos", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            var dias_asistidosParameter = dias_asistidos.HasValue ?
                new ObjectParameter("Dias_asistidos", dias_asistidos) :
                new ObjectParameter("Dias_asistidos", typeof(int));
    
            var idPuestoParameter = idPuesto.HasValue ?
                new ObjectParameter("idPuesto", idPuesto) :
                new ObjectParameter("idPuesto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertEmpleado", nombreParameter, apellidosParameter, direccionParameter, telefonoParameter, rFCParameter, correoParameter, idDepartamentoParameter, dias_asistidosParameter, idPuestoParameter);
        }
    }
}
