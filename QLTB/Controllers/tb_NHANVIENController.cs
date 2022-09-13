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
    public class tb_NHANVIENController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_NHANVIEN = db.tb_NHANVIEN.Include(e => e.tb_PHONGBAN).Include(e => e.tb_CHUCVU);
            return View(tb_NHANVIEN.ToList());
        }

        // GET: tb_NHANVIEN/Details/5
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
            tb_NHANVIEN tb_NHANVIEN = db.tb_NHANVIEN.Find(id);
            if (tb_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tb_NHANVIEN);
        }

        // GET: tb_NHANVIEN/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDCHUCVU = new SelectList(db.tb_CHUCVU, "IDCHUCVU", "TENCHUCVU");
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN");
            return View();
        }

        // POST: tb_NHANVIEN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_NHANVIEN tb_NHANVIEN)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NHANVIEN.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.tb_NHANVIEN.Add(tb_NHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCHUCVU = new SelectList(db.tb_CHUCVU, "IDCHUCVU", "TENCHUCVU", tb_NHANVIEN.IDCHUCVU);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_NHANVIEN.IDPHONGBAN);
            return View(tb_NHANVIEN);
        }

        // GET: tb_NHANVIEN/Edit/5
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
            tb_NHANVIEN tb_NHANVIEN = db.tb_NHANVIEN.Find(id);
            if (tb_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCHUCVU = new SelectList(db.tb_CHUCVU, "IDCHUCVU", "TENCHUCVU", tb_NHANVIEN.IDCHUCVU);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_NHANVIEN.IDPHONGBAN);
            return View(tb_NHANVIEN);
        }

        // POST: tb_NHANVIEN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_NHANVIEN tb_NHANVIEN)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NHANVIEN.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.Entry(tb_NHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCHUCVU = new SelectList(db.tb_CHUCVU, "IDCHUCVU", "TENCHUCVU", tb_NHANVIEN.IDCHUCVU);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_NHANVIEN.IDPHONGBAN);
            return View(tb_NHANVIEN);
        }

        // GET: tb_NHANVIEN/Delete/5
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
            tb_NHANVIEN tb_NHANVIEN = db.tb_NHANVIEN.Find(id);
            if (tb_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tb_NHANVIEN);
        }

        // POST: tb_NHANVIEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_NHANVIEN tb_NHANVIEN = db.tb_NHANVIEN.Find(id);
            db.tb_NHANVIEN.Remove(tb_NHANVIEN);
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
