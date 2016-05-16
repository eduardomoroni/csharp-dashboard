using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VixEng.Entities;

namespace VixEng.Controllers
{
    public class ConsultaCEPBrasilsController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: ConsultaCEPBrasils/ObterCep/29135508
        public JsonResult ObterCep(int id)
        {
            string id_string = id.ToString();

            try
            {
                var end = (from c in db.ConsultaCEPBrasil
                           where c.cep == id_string
                           select c).First<ConsultaCEPBrasil>();

                var retorno = new
                {

                    CEP = end.cep,
                    ID_UF = end.id_uf,
                    ID_CIDADE = end.id_cidade,
                    ENDERECO = end.endereco,
                    BAIRRO = end.bairro

                };

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (InvalidOperationException)
            {
                return Json(new
                {

                    CEP = "",
                    ID_UF = "",
                    ID_CIDADE = "",
                    ENDERECO = "",
                    BAIRRO = ""

                }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ConsultaCEPBrasils/ObterCep/1203431
        public JsonResult ObterCepId(int id)
        {
            var end = from c in db.ConsultaCEPBrasil
                      where c.id == id
                      select c;

            var list = new SelectList(end.ToArray(), "id", "cep");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: ConsultaCEPBrasils
        public async Task<ActionResult> Index()
        {
            return View(await db.ConsultaCEPBrasil.ToListAsync());
        }

        // GET: ConsultaCEPBrasils/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaCEPBrasil consultaCEPBrasil = await db.ConsultaCEPBrasil.FindAsync(id);
            if (consultaCEPBrasil == null)
            {
                return HttpNotFound();
            }
            return View(consultaCEPBrasil);
        }

        // GET: ConsultaCEPBrasils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConsultaCEPBrasils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,cep,id_uf,id_cidade,endereco,bairro")] ConsultaCEPBrasil consultaCEPBrasil)
        {
            if (ModelState.IsValid)
            {
                db.ConsultaCEPBrasil.Add(consultaCEPBrasil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(consultaCEPBrasil);
        }

        // GET: ConsultaCEPBrasils/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaCEPBrasil consultaCEPBrasil = await db.ConsultaCEPBrasil.FindAsync(id);
            if (consultaCEPBrasil == null)
            {
                return HttpNotFound();
            }
            return View(consultaCEPBrasil);
        }

        // POST: ConsultaCEPBrasils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,cep,id_uf,id_cidade,endereco,bairro")] ConsultaCEPBrasil consultaCEPBrasil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultaCEPBrasil).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consultaCEPBrasil);
        }

        // GET: ConsultaCEPBrasils/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaCEPBrasil consultaCEPBrasil = await db.ConsultaCEPBrasil.FindAsync(id);
            if (consultaCEPBrasil == null)
            {
                return HttpNotFound();
            }
            return View(consultaCEPBrasil);
        }

        //// POST: ConsultaCEPBrasils/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    ConsultaCEPBrasil consultaCEPBrasil = await db.ConsultaCEPBrasil.FindAsync(id);
        //    db.ConsultaCEPBrasil.Remove(consultaCEPBrasil);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
