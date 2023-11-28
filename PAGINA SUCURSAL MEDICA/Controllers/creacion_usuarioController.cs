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
    public class creacion_usuarioController : Controller
    {
        private sucursualEntities db = new sucursualEntities();

        // GET: creacion_usuario
        public ActionResult Index()
        {
            return View(db.creacion_usuario.ToList());
        }

        // GET: creacion_usuario/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creacion_usuario creacion_usuario = db.creacion_usuario.Find(id);
            if (creacion_usuario == null)
            {
                return HttpNotFound();
            }
            return View(creacion_usuario);
        }

        // GET: creacion_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: creacion_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nickNameParaIngresar,cedula,nombreCompleto,correElectronico,direccion,lugarDeResidencia,sedeDondeSePrestaraLaAtencion,lugarDeNacimiento,sedeDeAtencion,contrasenia,fechaExppCedu,fechaDeNaciemiento,numeroDeContacto")] creacion_usuario creacion_usuario)
        {
            if (ModelState.IsValid)
            {
                db.creacion_usuario.Add(creacion_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creacion_usuario);
        }

        // GET: creacion_usuario/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creacion_usuario creacion_usuario = db.creacion_usuario.Find(id);
            if (creacion_usuario == null)
            {
                return HttpNotFound();
            }
            return View(creacion_usuario);
        }

        // POST: creacion_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nickNameParaIngresar,cedula,nombreCompleto,correElectronico,direccion,lugarDeResidencia,sedeDondeSePrestaraLaAtencion,lugarDeNacimiento,sedeDeAtencion,contrasenia,fechaExppCedu,fechaDeNaciemiento,numeroDeContacto")] creacion_usuario creacion_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creacion_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creacion_usuario);
        }

        // GET: creacion_usuario/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            creacion_usuario creacion_usuario = db.creacion_usuario.Find(id);
            if (creacion_usuario == null)
            {
                return HttpNotFound();
            }
            return View(creacion_usuario);
        }

        // POST: creacion_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            creacion_usuario creacion_usuario = db.creacion_usuario.Find(id);
            db.creacion_usuario.Remove(creacion_usuario);
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
