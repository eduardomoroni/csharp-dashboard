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
    public class BeneficiosController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: Beneficios
        public ActionResult Index()
        {
            var beneficios = db.Beneficios.Include(b => b.Funcionarios).Include(b => b.Tipo_Beneficio);
            return View(beneficios.ToList());
        }

        // GET: Beneficios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return HttpNotFound();
            }
            return View(beneficios);
        }

        // GET: Beneficios/Create
        public ActionResult Create()
        {
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome");
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao");
            return View();
        }

        // POST: Beneficios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_funcionario,id_tipo_beneficio,observacao")] Beneficios beneficios)
        {
            if (ModelState.IsValid)
            {
                db.Beneficios.Add(beneficios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", beneficios.id_funcionario);
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", beneficios.id_tipo_beneficio);
            return View(beneficios);
        }

        // GET: Beneficios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", beneficios.id_funcionario);
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", beneficios.id_tipo_beneficio);
            return View(beneficios);
        }

        // POST: Beneficios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_funcionario,id_tipo_beneficio,observacao")] Beneficios beneficios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beneficios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_funcionario = new SelectList(db.Funcionarios, "id", "nome", beneficios.id_funcionario);
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", beneficios.id_tipo_beneficio);
            return View(beneficios);
        }

        // GET: Beneficios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficios beneficios = db.Beneficios.Find(id);
            if (beneficios == null)
            {
                return HttpNotFound();
            }
            return View(beneficios);
        }

        // POST: Beneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Beneficios beneficios = db.Beneficios.Find(id);
            db.Beneficios.Remove(beneficios);
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
