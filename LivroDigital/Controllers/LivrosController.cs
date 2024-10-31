using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LivroDigital.Models;

namespace LivroDigital.Controllers
{
    [Authorize]
    public class LivrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Livros
        [AllowAnonymous]
        public ActionResult Index()
        {
            var livros = db.Livros.Include(l => l.Editora);
            return View(livros.ToList());
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.Editoras = db.Editoras.ToList();
            ViewBag.Categorias = db.Categorias.ToList();
            ViewBag.Autores = db.Autores.ToList();
            return View();
        }

        // POST: Livros/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivroId,Titulo,AnoPublicacao,ISBN,EditoraId")] Livro livro, int[] SelectedCategorias, int[] SelectedAutores)
        {
            if (ModelState.IsValid)
            {
                // Adicionar categorias selecionados ao evento
                livro.Categorias = new List<Categoria>();
                if (SelectedCategorias != null)
                {
                    foreach (var categoriaId in SelectedCategorias)
                    {
                        var categoria = db.Categorias.Find(categoriaId);
                        if (categoria != null)
                        {
                            livro.Categorias.Add(categoria);
                        }
                    }
                }
                // Adicionar autores selecionados ao evento
                livro.Autores = new List<Autor>();
                if (SelectedAutores != null)
                {
                    foreach (var autorId in SelectedAutores)
                    {
                        var autor = db.Autores.Find(autorId);
                        if (autor != null)
                        {
                            livro.Autores.Add(autor);
                        }
                    }
                }

                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Editoras = db.Editoras.ToList();
            ViewBag.Categorias = db.Categorias.ToList();
            ViewBag.Autores = db.Autores.ToList();
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Editoras = db.Editoras.ToList();
            return View(livro);
        }

        // POST: Livros/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivroId,Titulo,AnoPublicacao,ISBN,EditoraId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Editoras = db.Editoras.ToList();
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
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
