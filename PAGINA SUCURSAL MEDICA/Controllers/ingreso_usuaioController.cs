using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PAGINA_SUCURSAL_MEDICA.Models;

namespace PAGINA_SUCURSAL_MEDICA.Controllers
{
    public class ingreso_usuaioController : Controller
    {
        private sucursualEntities db = new sucursualEntities();

        // GET: ingreso_usuaio
        public ActionResult Index()
        {
            return View(db.ingreso_usuaio.ToList());
        }

        // GET: ingreso_usuaio/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_usuaio ingreso_usuaio = db.ingreso_usuaio.Find(id);
            if (ingreso_usuaio == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_usuaio);
        } 

        // GET: ingreso_usuaio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ingreso_usuaio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nick_name_ingresar,contrasenia_usuario")] ingreso_usuaio ingreso_usuaio)
        {
            if (ModelState.IsValid)
            {
                db.ingreso_usuaio.Add(ingreso_usuaio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingreso_usuaio);
        }

        // GET: ingreso_usuaio/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_usuaio ingreso_usuaio = db.ingreso_usuaio.Find(id);
            if (ingreso_usuaio == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_usuaio);
        }

        // POST: ingreso_usuaio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nick_name_ingresar,contrasenia_usuario")] ingreso_usuaio ingreso_usuaio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingreso_usuaio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingreso_usuaio);
        }

        // GET: ingreso_usuaio/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_usuaio ingreso_usuaio = db.ingreso_usuaio.Find(id);
            if (ingreso_usuaio == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_usuaio);
        }

        // POST: ingreso_usuaio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ingreso_usuaio ingreso_usuaio = db.ingreso_usuaio.Find(id);
            db.ingreso_usuaio.Remove(ingreso_usuaio);
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
