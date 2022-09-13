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
    public class tb_CHUCVUController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_CHUCVU
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_CHUCVU = db.tb_CHUCVU.Include(t => t.tb_NGUOIDUNG);
            return View(tb_CHUCVU.ToList());
        }

        // GET: tb_CHUCVU/Details/5
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
            tb_CHUCVU tb_CHUCVU = db.tb_CHUCVU.Find(id);
            if (tb_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(tb_CHUCVU);
        }

        // GET: tb_CHUCVU/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG");
            return View();
        }

        // POST: tb_CHUCVU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_CHUCVU tb_CHUCVU)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_CHUCVU.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.tb_CHUCVU.Add(tb_CHUCVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_CHUCVU.IDNGUOIDUNG);
            return View(tb_CHUCVU);
        }

        // GET: tb_CHUCVU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_CHUCVU tb_CHUCVU = db.tb_CHUCVU.Find(id);
            if (tb_CHUCVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_CHUCVU.IDNGUOIDUNG);
            return View(tb_CHUCVU);
        }

        // POST: tb_CHUCVU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_CHUCVU tb_CHUCVU)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_CHUCVU.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.Entry(tb_CHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_CHUCVU.IDNGUOIDUNG);
            return View(tb_CHUCVU);
        }

        // GET: tb_CHUCVU/Delete/5
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
            tb_CHUCVU tb_CHUCVU = db.tb_CHUCVU.Find(id);
            if (tb_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(tb_CHUCVU);
        }

        // POST: tb_CHUCVU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_CHUCVU tb_CHUCVU = db.tb_CHUCVU.Find(id);
            db.tb_CHUCVU.Remove(tb_CHUCVU);
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
