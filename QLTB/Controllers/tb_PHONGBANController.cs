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
    public class tb_PHONGBANController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_PHONGBAN
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_PHONGBAN = db.tb_PHONGBAN.Include(t => t.tb_NGUOIDUNG);
            return View(tb_PHONGBAN.ToList());
        }

        // GET: tb_PHONGBAN/Details/5
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
            tb_PHONGBAN tb_PHONGBAN = db.tb_PHONGBAN.Find(id);
            if (tb_PHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(tb_PHONGBAN);
        }

        // GET: tb_PHONGBAN/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG");
            return View();
        }

        // POST: tb_PHONGBAN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_PHONGBAN tb_PHONGBAN)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_PHONGBAN.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.tb_PHONGBAN.Add(tb_PHONGBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_PHONGBAN.IDNGUOIDUNG);
            return View(tb_PHONGBAN);
        }

        // GET: tb_PHONGBAN/Edit/5
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
            tb_PHONGBAN tb_PHONGBAN = db.tb_PHONGBAN.Find(id);
            if (tb_PHONGBAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_PHONGBAN.IDNGUOIDUNG);
            return View(tb_PHONGBAN);
        }

        // POST: tb_PHONGBAN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_PHONGBAN tb_PHONGBAN)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_PHONGBAN.IDNGUOIDUNG = userid;

            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Entry(tb_PHONGBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_PHONGBAN.IDNGUOIDUNG);
            return View(tb_PHONGBAN);
        }

        // GET: tb_PHONGBAN/Delete/5
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
            tb_PHONGBAN tb_PHONGBAN = db.tb_PHONGBAN.Find(id);
            if (tb_PHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(tb_PHONGBAN);
        }

        // POST: tb_PHONGBAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_PHONGBAN = db.tb_PHONGBAN.Find(id);
            db.tb_PHONGBAN.Remove(tb_PHONGBAN);
            db.SaveChanges();
            var xoa = db.tb_THIETBI.Where(m => m.IDPHONGBAN == id).ToList();
            db.tb_THIETBI.RemoveRange(xoa);
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
