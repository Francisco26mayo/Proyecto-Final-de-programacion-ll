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
    public class BibliogafiasController : Controller
    {
        private bibliotecasEntities db = new bibliotecasEntities();

        // GET: Bibliogafias
        public ActionResult Index()
        {
            return View(db.Bibliogafia.ToList());
        }

        // GET: Bibliogafias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliogafia bibliogafia = db.Bibliogafia.Find(id);
            if (bibliogafia == null)
            {
                return HttpNotFound();
            }
            return View(bibliogafia);
        }

        // GET: Bibliogafias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bibliogafias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Estado")] Bibliogafia bibliogafia)
        {
            if (ModelState.IsValid)
            {
                db.Bibliogafia.Add(bibliogafia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibliogafia);
        }

        // GET: Bibliogafias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliogafia bibliogafia = db.Bibliogafia.Find(id);
            if (bibliogafia == null)
            {
                return HttpNotFound();
            }
            return View(bibliogafia);
        }

        // POST: Bibliogafias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Estado")] Bibliogafia bibliogafia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibliogafia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibliogafia);
        }

        // GET: Bibliogafias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliogafia bibliogafia = db.Bibliogafia.Find(id);
            if (bibliogafia == null)
            {
                return HttpNotFound();
            }
            return View(bibliogafia);
        }

        // POST: Bibliogafias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliogafia bibliogafia = db.Bibliogafia.Find(id);
            db.Bibliogafia.Remove(bibliogafia);
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
