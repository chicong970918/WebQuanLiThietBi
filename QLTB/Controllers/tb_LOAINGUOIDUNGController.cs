using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace QLTB.Controllers
{
    public class tb_LOAINGUOIDUNGController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_LOAINGUOIDUNG
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.tb_LOAINGUOIDUNG.ToList());
        }

        // GET: tb_LOAINGUOIDUNG/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG = db.tb_LOAINGUOIDUNG.Find(id);
            if (tb_LOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAINGUOIDUNG);
        }

        // GET: tb_LOAINGUOIDUNG/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: tb_LOAINGUOIDUNG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.tb_LOAINGUOIDUNG.Add(tb_LOAINGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_LOAINGUOIDUNG);
        }

        // GET: tb_LOAINGUOIDUNG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG = db.tb_LOAINGUOIDUNG.Find(id);
            if (tb_LOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAINGUOIDUNG);
        }

        // POST: tb_LOAINGUOIDUNG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(tb_LOAINGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_LOAINGUOIDUNG);
        }

        // GET: tb_LOAINGUOIDUNG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG = db.tb_LOAINGUOIDUNG.Find(id);
            if (tb_LOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAINGUOIDUNG);
        }

        // POST: tb_LOAINGUOIDUNG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_LOAINGUOIDUNG tb_LOAINGUOIDUNG = db.tb_LOAINGUOIDUNG.Find(id);
            db.tb_LOAINGUOIDUNG.Remove(tb_LOAINGUOIDUNG);
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
