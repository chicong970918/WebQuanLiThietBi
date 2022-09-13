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
    public class tb_NGUOIDUNGController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_NGUOIDUNG
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_NGUOIDUNG = db.tb_NGUOIDUNG.Include(t => t.tb_LOAINGUOIDUNG).Include(t => t.tb_NHANVIEN);
            return View(tb_NGUOIDUNG.ToList());
        }

        // GET: tb_NGUOIDUNG/Details/5
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
            tb_NGUOIDUNG tb_NGUOIDUNG = db.tb_NGUOIDUNG.Find(id);
            if (tb_NGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(tb_NGUOIDUNG);
        }

        // GET: tb_NGUOIDUNG/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDLOAINGUOIDUNG = new SelectList(db.tb_LOAINGUOIDUNG, "IDLOAINGUOIDUNG", "LOAINGUOIDUNG");
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN");
            return View();
        }

        // POST: tb_NGUOIDUNG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_NGUOIDUNG tb_NGUOIDUNG)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NGUOIDUNG.IDNGUOIDUNG = userid;
            if (ModelState.IsValid)
            {
                db.tb_NGUOIDUNG.Add(tb_NGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLOAINGUOIDUNG = new SelectList(db.tb_LOAINGUOIDUNG, "IDLOAINGUOIDUNG", "LOAINGUOIDUNG", tb_NGUOIDUNG.IDLOAINGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_NGUOIDUNG.IDNHANVIEN);
            return View(tb_NGUOIDUNG);
        }

        // GET: tb_NGUOIDUNG/Edit/5
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
            tb_NGUOIDUNG tb_NGUOIDUNG = db.tb_NGUOIDUNG.Find(id);
            if (tb_NGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLOAINGUOIDUNG = new SelectList(db.tb_LOAINGUOIDUNG, "IDLOAINGUOIDUNG", "LOAINGUOIDUNG", tb_NGUOIDUNG.IDLOAINGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_NGUOIDUNG.IDNHANVIEN);
            return View(tb_NGUOIDUNG);
        }

        // POST: tb_NGUOIDUNG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_NGUOIDUNG tb_NGUOIDUNG)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NGUOIDUNG.IDNGUOIDUNG = userid;
            if (ModelState.IsValid)
            {
                db.Entry(tb_NGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLOAINGUOIDUNG = new SelectList(db.tb_LOAINGUOIDUNG, "IDLOAINGUOIDUNG", "LOAINGUOIDUNG", tb_NGUOIDUNG.IDLOAINGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_NGUOIDUNG.IDNHANVIEN);
            return View(tb_NGUOIDUNG);
        }

        // GET: tb_NGUOIDUNG/Delete/5
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
            tb_NGUOIDUNG tb_NGUOIDUNG = db.tb_NGUOIDUNG.Find(id);
            if (tb_NGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(tb_NGUOIDUNG);
        }

        // POST: tb_NGUOIDUNG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_NGUOIDUNG tb_NGUOIDUNG = db.tb_NGUOIDUNG.Find(id);
            db.tb_NGUOIDUNG.Remove(tb_NGUOIDUNG);
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
