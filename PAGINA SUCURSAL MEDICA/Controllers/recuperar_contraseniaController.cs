using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAGINA_SUCURSAL_MEDICA.Models;

namespace PAGINA_SUCURSAL_MEDICA.Controllers
{
    public class recuperar_contraseniaController : Controller
    {
        private sucursualEntities db = new sucursualEntities();

        // GET: recuperar_contrasenia
        public ActionResult Index()
        {
            return View(db.recuperar_contrasenia.ToList());
        }

        // GET: recuperar_contrasenia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recuperar_contrasenia recuperar_contrasenia = db.recuperar_contrasenia.Find(id);
            if (recuperar_contrasenia == null)
            {
                return HttpNotFound();
            }
            return View(recuperar_contrasenia);
        }

        // GET: recuperar_contrasenia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: recuperar_contrasenia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "correo_electronica")] recuperar_contrasenia recuperar_contrasenia)
        {
            if (ModelState.IsValid)
            {
                db.recuperar_contrasenia.Add(recuperar_contrasenia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recuperar_contrasenia);
        }

        // GET: recuperar_contrasenia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recuperar_contrasenia recuperar_contrasenia = db.recuperar_contrasenia.Find(id);
            if (recuperar_contrasenia == null)
            {
                return HttpNotFound();
            }
            return View(recuperar_contrasenia);
        }

        // POST: recuperar_contrasenia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correo_electronica")] recuperar_contrasenia recuperar_contrasenia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recuperar_contrasenia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recuperar_contrasenia);
        }

        // GET: recuperar_contrasenia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recuperar_contrasenia recuperar_contrasenia = db.recuperar_contrasenia.Find(id);
            if (recuperar_contrasenia == null)
            {
                return HttpNotFound();
            }
            return View(recuperar_contrasenia);
        }

        // POST: recuperar_contrasenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            recuperar_contrasenia recuperar_contrasenia = db.recuperar_contrasenia.Find(id);
            db.recuperar_contrasenia.Remove(recuperar_contrasenia);
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
