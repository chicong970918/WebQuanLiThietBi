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
    public class tb_THIETBIController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_THIETBI
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_THIETBI = db.tb_THIETBI.Include(t => t.tb_LOAITHIETBI).Include(t => t.tb_NGUOIDUNG).Include(t => t.tb_PHONGBAN);
            return View(tb_THIETBI.ToList());
        }

        // GET: tb_THIETBI/Details/5
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
            tb_THIETBI tb_THIETBI = db.tb_THIETBI.Find(id);
            if (tb_THIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_THIETBI);
        }

        // GET: tb_THIETBI/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDLOAITHIETBI = new SelectList(db.tb_LOAITHIETBI, "IDLOAITHIETBI", "TENLOAITHIETBI", "0");
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", "0");
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", "0");
            return View();
        }

        // POST: tb_THIETBI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_THIETBI tb_THIETBI)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_THIETBI.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.tb_THIETBI.Add(tb_THIETBI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLOAITHIETBI = new SelectList(db.tb_LOAITHIETBI, "IDLOAITHIETBI", "TENLOAITHIETBI", tb_THIETBI.IDLOAITHIETBI);
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_THIETBI.IDNGUOIDUNG);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_THIETBI.IDPHONGBAN);
            return View(tb_THIETBI);
        }

        // GET: tb_THIETBI/Edit/5
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
            tb_THIETBI tb_THIETBI = db.tb_THIETBI.Find(id);
            if (tb_THIETBI == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLOAITHIETBI = new SelectList(db.tb_LOAITHIETBI, "IDLOAITHIETBI", "TENLOAITHIETBI", tb_THIETBI.IDLOAITHIETBI);
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_THIETBI.IDNGUOIDUNG);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_THIETBI.IDPHONGBAN);
            return View(tb_THIETBI);
        }

        // POST: tb_THIETBI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_THIETBI tb_THIETBI)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_THIETBI.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.Entry(tb_THIETBI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLOAITHIETBI = new SelectList(db.tb_LOAITHIETBI, "IDLOAITHIETBI", "TENLOAITHIETBI", tb_THIETBI.IDLOAITHIETBI);
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_THIETBI.IDNGUOIDUNG);
            ViewBag.IDPHONGBAN = new SelectList(db.tb_PHONGBAN, "IDPHONGBAN", "TENPHONGBAN", tb_THIETBI.IDPHONGBAN);
            return View(tb_THIETBI);
        }

        // GET: tb_THIETBI/Delete/5
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
            tb_THIETBI tb_THIETBI = db.tb_THIETBI.Find(id);
            if (tb_THIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_THIETBI);
        }

        // POST: tb_THIETBI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_THIETBI tb_THIETBI = db.tb_THIETBI.Find(id);
            db.tb_THIETBI.Remove(tb_THIETBI);
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
