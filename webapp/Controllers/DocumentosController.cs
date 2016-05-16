using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VixEng.Entities;

namespace VixEng.Controllers
{
    public class DocumentosController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: Documentos
        public ActionResult Index()
        {
            var documentos = db.Documentos.Include(d => d.Funcionarios).Include(d => d.Tipo_Documento);
            return View(documentos.ToList());
        }

        // GET: Documentos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // GET: Documentos/Create
        public ActionResult Create()
        {
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome");
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1");
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_funcionario,id_tipo_documento,data,descricao,documento")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(documentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", documentos.id_funcionario);
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", documentos.id_tipo_documento);
            return View(documentos);
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromFuncionarios([Bind(Include = "id,id_funcionario,id_tipo_documento,data,descricao,documento")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(documentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", "Funcionarios", new { id = documentos.id_funcionario });
        }

        // GET: Documentos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", documentos.id_funcionario);
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", documentos.id_tipo_documento);
            return View(documentos);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_funcionario,id_tipo_documento,data,descricao,documento")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", documentos.id_funcionario);
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", documentos.id_tipo_documento);
            return View(documentos);
        }

        // GET: Documentos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Documentos documentos = db.Documentos.Find(id);
            db.Documentos.Remove(documentos);
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
