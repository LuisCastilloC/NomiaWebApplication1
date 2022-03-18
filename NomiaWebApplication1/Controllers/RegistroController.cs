using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Conexion;
using NomiaWebApplication1.helpers;

namespace NomiaWebApplication1.Controllers
{
    public class RegistroController : Controller
    {
        private DBNOMINA2022Entities db = new DBNOMINA2022Entities();
        // GET: Registro
        public ActionResult Index()
        {
            var empleado = db.Empleados.Include(a => a.Departamento).Include(a => a.Puesto);
            return View(empleado.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.idDepartamento = new SelectList(db.Departamento, "id", "NombreDepartamento");
            ViewBag.idPuesto = new SelectList(db.Puesto, "id", "Nombre");
            return View();
        }

        [HttpPost]

        public ActionResult Create([Bind(Include = "idNumEmpleado,Nombre,Apellido,Direccion,telefono,RFC,Correo,idDepartamento,Dias_asistidos,idPuesto")] Empleados item)
        {
            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string Error = null;
            
            var nombre = item.Nombre;
            var apellidos = item.Apellidos;
            var Direccion = item.Direccion;
            var Telefono = item.Telefono;
            var RFC = item.RFC;
            var Correo = item.Correo;
            /*var idDepartamento*/
            var Dias_asistidos = item.Dias_asistidos;
            //idPuesto
#pragma warning disable CS0472 // El resultado de la expresión siempre es el mismo ya que un valor de este tipo siempre es igual a "null"
            if (/*ModelState.IsValid*/ nombre !=null &&apellidos != null && Direccion !=null && Telefono != null && RFC != null && Correo != null && Dias_asistidos != null)
#pragma warning restore CS0472 // El resultado de la expresión siempre es el mismo ya que un valor de este tipo siempre es igual a "null"
            {

                if (!Regex.IsMatch(nombre.ToUpper(), @"^[\p{L} \.\-]+$") && nombre.Length < 51)
                {
                    Error += "Solo usar letras en el nombre <br/>";
                }

                if (!Regex.IsMatch(apellidos.ToUpper(), @"^[\p{L} \.\-]+$") && apellidos.Length < 101)
                {
                    Error += "Solo usar letras en el apellido <br/>";
                }

                if (!Regex.IsMatch(RFC.ToUpper(), @"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$") && RFC.Length < 14)
                {
                    Error += "Verificar si el RFC es correcto <br/>";
                }

                if (!Regex.IsMatch(Correo, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$") && Correo.Length < 51)
                {
                    Error += "Correo Invalido <br/>";
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                Error += "Uno o varios campos vacios";
            }

            ViewData["Resultado"] = Error == null ? "El proceso finalizo correctamente" : Error;

            ViewBag.idDepartamento = new SelectList(db.Departamento, "id", "NombreDepartamento", item.idDepartamento);
            ViewBag.idPuesto = new SelectList(db.Puesto, "id", "Nombre", item.idPuesto);
            
            var respuesta = Constructor.Instance.empleado.Insertar(item);
            return View(item);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "id", "NombreDepartamento", empleados.idDepartamento);
            ViewBag.idPuesto = new SelectList(db.Puesto, "id", "Nombre", empleados.idPuesto);

            return View(empleados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNumEmpleado,Nombre,Apellido,Direccion,telefono,RFC,Correo,idDepartamento,Dias_asistidos,idPuesto")] Empleados item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento = new SelectList(db.Departamento, "id", "NombreDepartamento", item.idDepartamento);
            ViewBag.idPuesto = new SelectList(db.Puesto, "id", "Nombre", item.idPuesto);
            return View(item);
        }


        // GET: Alumnoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}