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
    public class usuriosController : Controller
    {
        private bibliotecasEntities db = new bibliotecasEntities();

        // GET: usurios
        public ActionResult Index()
        {
            return View(db.usurio.ToList());
        }

        // GET: usurios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usurio usurio = db.usurio.Find(id);
            if (usurio == null)
            {
                return HttpNotFound();
            }
            return View(usurio);
        }

        // GET: usurios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usurios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,cedula,carnet,tipo_persona,Estado")] usurio usurio)
        {
            if (ModelState.IsValid)
            {
                db.usurio.Add(usurio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usurio);
        }

        // GET: usurios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usurio usurio = db.usurio.Find(id);
            if (usurio == null)
            {
                return HttpNotFound();
            }
            return View(usurio);
        }

        // POST: usurios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,cedula,carnet,tipo_persona,Estado")] usurio usurio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usurio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usurio);
        }

        // GET: usurios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usurio usurio = db.usurio.Find(id);
            if (usurio == null)
            {
                return HttpNotFound();
            }
            return View(usurio);
        }

        // POST: usurios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usurio usurio = db.usurio.Find(id);
            db.usurio.Remove(usurio);
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
