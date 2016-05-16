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
    [Authorize]
    public class FuncionariosController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.AspNetUsers).Include(f => f.Bancos).Include(f => f.Cargos).Include(f => f.Cidades).Include(f => f.UF);
            return View(funcionarios.ToList());
        }

        public ActionResult CEPAutoComplete(string term)
        {
            var ceps = GetCep(term).Select(a => new { value = a.cep });
            return Json(ceps, JsonRequestBehavior.AllowGet);
        }

        private List<ConsultaCEPBrasil> GetCep(string searchString)
        {
            return db.ConsultaCEPBrasil
            .Where(a => a.cep.Contains(searchString))
            .ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarBeneficio([Bind(Include = "id,id_funcionario,id_tipo_beneficio,observacao")] Beneficios beneficios)
        {
            if (ModelState.IsValid)
            {
                db.Beneficios.Add(beneficios);
                db.SaveChanges();

                //Reabrir conexão(Evitar problema de falta de associação de herança)
                Dispose(true);
                db = new databaseModel();

                //Preparar a Model e ViewBag
                var funcionarios = db.Funcionarios.Find(beneficios.id_funcionario);
                ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "UserName", funcionarios.id_user);
                ViewBag.id_banco = new SelectList(db.Bancos, "Id", "Codigo", funcionarios.id_banco);
                ViewBag.id_cargo = new SelectList(db.Cargos, "id", "descricao", funcionarios.id_cargo);
                ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", funcionarios.id_cidade);
                ViewBag.id_uf = new SelectList(db.UF, "id", "uf1", funcionarios.id_uf);
                ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", null);
                ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", null);
                //ViewBag.documento = new Documentos();
                return PartialView("_AbaBeneficios", funcionarios);
            }
            //O que fazer no caso de precisar validar?
            return RedirectToAction("Edit", "Funcionarios", new { id = beneficios.id_funcionario });
        }

        // POST: Funcionarios/CreateFromFuncionarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDocumento([Bind(Include = "id,id_funcionario,id_tipo_documento,data,descricao,documento")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                db.Documentos.Add(documentos);
                db.SaveChanges();
                return RedirectToAction("Edit", "Funcionarios", new { id = documentos.id_funcionario });
            }
            
            //O que fazer no caso de precisar validar?
            return RedirectToAction("Edit", "Funcionarios", new { id = documentos.id_funcionario });
        }

        //Metodo usado para o Cascade de cidades
        public JsonResult ObterCidades(int id)
        {
            var city = from c in db.Cidades
                       where c.id_uf == id
                       select c;
            var list = new SelectList(city.ToArray(), "id", "cidade");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "UserName");
            ViewBag.id_banco = new SelectList(db.Bancos, "Id", "Banco");
            ViewBag.id_cargo = new SelectList(db.Cargos, "id", "descricao");
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade");
            ViewBag.id_uf = new SelectList(db.UF, "id", "uf1");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_cargo,nome,email,cpf,rg,rg_data_emissao,rg_exp,data_nascimento,endereco,numero,complemento,bairro,id_cidade,cep,telefone1,telefone2,telefone3,status,id_banco,agencia,conta,data_admissao,salario,foto,id_user")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionarios);
                db.SaveChanges();
                return RedirectToAction("Edit", "Funcionarios", new { id = funcionarios.id });
            }

            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "UserName", funcionarios.id_user);
            ViewBag.id_banco = new SelectList(db.Bancos, "Id", "Codigo", funcionarios.id_banco);
            ViewBag.id_cargo = new SelectList(db.Cargos, "id", "descricao", funcionarios.id_cargo);
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", funcionarios.id_cidade);
            ViewBag.id_uf = new SelectList(db.UF, "id", "uf1", funcionarios.id_uf);
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "UserName", funcionarios.id_user);
            ViewBag.id_banco = new SelectList(db.Bancos, "Id", "Codigo", funcionarios.id_banco);
            ViewBag.id_cargo = new SelectList(db.Cargos, "id", "descricao", funcionarios.id_cargo);
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", funcionarios.id_cidade);
            ViewBag.id_uf = new SelectList(db.UF, "id", "uf1", funcionarios.id_uf);
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", null);
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", null);
            //ViewBag.documento = new Documentos();
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_cargo,nome,email,cpf,rg,rg_data_emissao,rg_exp,data_nascimento,endereco,numero,complemento,bairro,id_cidade,id_uf,cep,telefone1,telefone2,telefone3,status,id_banco,agencia,conta,data_admissao,salario,foto,id_user")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "UserName", funcionarios.id_user);
            ViewBag.id_banco = new SelectList(db.Bancos, "Id", "Codigo", funcionarios.id_banco);
            ViewBag.id_cargo = new SelectList(db.Cargos, "id", "descricao", funcionarios.id_cargo);
            ViewBag.id_cidade = new SelectList(db.Cidades, "id", "cidade", funcionarios.id_cidade);
            ViewBag.id_uf = new SelectList(db.UF, "id", "uf1", funcionarios.id_uf);
            ViewBag.id_tipo_documento = new SelectList(db.Tipo_Documento, "id", "tipo_documento1", null);
            ViewBag.id_tipo_beneficio = new SelectList(db.Tipo_Beneficio, "id", "descricao", null);
            //ViewBag.documento = new Documentos();
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Funcionarios funcionarios = db.Funcionarios.Find(id);

            AspNetUsers usuario = db.AspNetUsers.Find(funcionarios.id_user);
            if (usuario != null)
            {
                db.AspNetUsers.Remove(usuario);
                db.SaveChanges();
            }

            db.Funcionarios.Remove(funcionarios);
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
