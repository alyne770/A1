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
    [Authorize]
    public class EditorasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Editoras
        public ActionResult Index()
        {
            return View(db.Editoras.ToList());
        }

        // GET: Editoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editoras/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EditoraId,Nome,Cidade")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                db.Editoras.Add(editora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editora);
        }

        // GET: Editoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editora editora = db.Editoras.Find(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(editora);
        }

        // POST: Editoras/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EditoraId,Nome,Cidade")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        // GET: Editoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editora editora = db.Editoras.Find(id);
            if (editora == null)
            {
                return HttpNotFound();
            }
            return View(editora);
        }

        // POST: Editoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editora editora = db.Editoras.Find(id);
            db.Editoras.Remove(editora);
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
