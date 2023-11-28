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
    public class historial_clinicoController : Controller
    {
        private sucursualEntities db = new sucursualEntities();

        // GET: historial_clinico
        public ActionResult Index()
        {
            return View(db.historial_clinico.ToList());
        }

        // GET: historial_clinico/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial_clinico historial_clinico = db.historial_clinico.Find(id);
            if (historial_clinico == null)
            {
                return HttpNotFound();
            }
            return View(historial_clinico);
        }

        // GET: historial_clinico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: historial_clinico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero_cita,citas_anteriores,medico_del_paciente")] historial_clinico historial_clinico)
        {
            if (ModelState.IsValid)
            {
                db.historial_clinico.Add(historial_clinico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historial_clinico);
        }

        // GET: historial_clinico/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial_clinico historial_clinico = db.historial_clinico.Find(id);
            if (historial_clinico == null)
            {
                return HttpNotFound();
            }
            return View(historial_clinico);
        }

        // POST: historial_clinico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero_cita,citas_anteriores,medico_del_paciente")] historial_clinico historial_clinico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historial_clinico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historial_clinico);
        }

        // GET: historial_clinico/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historial_clinico historial_clinico = db.historial_clinico.Find(id);
            if (historial_clinico == null)
            {
                return HttpNotFound();
            }
            return View(historial_clinico);
        }

        // POST: historial_clinico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            historial_clinico historial_clinico = db.historial_clinico.Find(id);
            db.historial_clinico.Remove(historial_clinico);
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
