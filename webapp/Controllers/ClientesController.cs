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
    public class ClientesController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            var clientes = db.Clientes.Include(c => c.Cidades);
            return View(await clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,status,data_cadastro,tipo_pessoa,cnpj_cpf,nome,fantasia,contato,inscricao_estadual,inscricao_municipal,data_nascimento,rg,telefone1,telefone2,telefone3,endereco,numero,complemento,bairro,id_cidade,id_uf,cep,ponto_referencia,site,email,login,senha,data_inclusao")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", clientes.id_cidade);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", clientes.id_cidade);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,status,data_cadastro,tipo_pessoa,cnpj_cpf,nome,fantasia,contato,inscricao_estadual,inscricao_municipal,data_nascimento,rg,telefone1,telefone2,telefone3,endereco,numero,complemento,bairro,id_cidade,id_uf,cep,ponto_referencia,site,email,login,senha,data_inclusao")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", clientes.id_cidade);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = await db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Clientes clientes = await db.Clientes.FindAsync(id);
            db.Clientes.Remove(clientes);
            await db.SaveChangesAsync();
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
