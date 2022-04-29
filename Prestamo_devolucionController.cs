using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BIBLIOTECA;

namespace BIBLIOTECA.Controllers
{
    public class Prestamo_devolucionController : Controller
    {
        private bibliotecasEntities db = new bibliotecasEntities();

        // GET: Prestamo_devolucion
        public ActionResult Index()
        {
            return View(db.Prestamo_devolucion.ToList());
        }

        // GET: Prestamo_devolucion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo_devolucion prestamo_devolucion = db.Prestamo_devolucion.Find(id);
            if (prestamo_devolucion == null)
            {
                return HttpNotFound();
            }
            return View(prestamo_devolucion);
        }

        // GET: Prestamo_devolucion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestamo_devolucion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,prestamo,Empleado,Libro,usuario,Fecha_prestamo,Fecha_evolucion,Monto,cantidad_dia,comentario,Estado")] Prestamo_devolucion prestamo_devolucion)
        {
            if (ModelState.IsValid)
            {
                db.Prestamo_devolucion.Add(prestamo_devolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prestamo_devolucion);
        }

        // GET: Prestamo_devolucion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo_devolucion prestamo_devolucion = db.Prestamo_devolucion.Find(id);
            if (prestamo_devolucion == null)
            {
                return HttpNotFound();
            }
            return View(prestamo_devolucion);
        }

        // POST: Prestamo_devolucion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,prestamo,Empleado,Libro,usuario,Fecha_prestamo,Fecha_evolucion,Monto,cantidad_dia,comentario,Estado")] Prestamo_devolucion prestamo_devolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo_devolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prestamo_devolucion);
        }

        // GET: Prestamo_devolucion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo_devolucion prestamo_devolucion = db.Prestamo_devolucion.Find(id);
            if (prestamo_devolucion == null)
            {
                return HttpNotFound();
            }
            return View(prestamo_devolucion);
        }

        // POST: Prestamo_devolucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo_devolucion prestamo_devolucion = db.Prestamo_devolucion.Find(id);
            db.Prestamo_devolucion.Remove(prestamo_devolucion);
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
