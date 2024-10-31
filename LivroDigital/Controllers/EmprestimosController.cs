using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LivroDigital.Models;

namespace LivroDigital.Controllers
{
    [RequireHttps]
    [Authorize]
    public class EmprestimosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Emprestimos
        [AllowAnonymous]
        public ActionResult Index()
        {
            var emprestimos = db.Emprestimos.Include(e => e.Livro).Include(e => e.Usuario);
            return View(emprestimos.ToList());
        }

        // GET: Emprestimos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public ActionResult Create()
        {
            ViewBag.Livros = db.Livros.ToList();
            ViewBag.Usuarios = db.Usuarios.ToList();
            return View();
        }

        // POST: Emprestimos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmprestimoId,LivroId,UsuarioId,DataEmprestimo,DataDevolucao")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Livros = db.Livros.ToList();
            ViewBag.Usuarios = db.Usuarios.ToList();
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Livros = db.Livros.ToList();
            ViewBag.Usuarios = db.Usuarios.ToList();
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmprestimoId,LivroId,UsuarioId,DataEmprestimo,DataDevolucao")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Livros = db.Livros.ToList();
            ViewBag.Usuarios = db.Usuarios.ToList();
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            db.Emprestimos.Remove(emprestimo);
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
