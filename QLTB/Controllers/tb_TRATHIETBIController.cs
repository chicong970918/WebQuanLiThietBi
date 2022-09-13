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
    public class tb_TRATHIETBIController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_TRATHIETBI
        public ActionResult Index()
        {
            var tb_TRATHIETBI = db.tb_TRATHIETBI.Include(t => t.tb_NGUOIDUNG).Include(t => t.tb_NHANVIEN).Include(t => t.tb_THIETBI);
            return View(tb_TRATHIETBI.ToList());
        }

        // GET: tb_TRATHIETBI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TRATHIETBI tb_TRATHIETBI = db.tb_TRATHIETBI.Find(id);
            if (tb_TRATHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_TRATHIETBI);
        }

        // GET: tb_TRATHIETBI/Create
        public ActionResult Create()
        {
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG");
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN");
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI");
            return View();
        }

        // POST: tb_TRATHIETBI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TBReturnID,IDTHIETBI,IDNHANVIEN,NGAYYEUCAU,NGAYTRA,NGAYHIENTAI,IDNGUOIDUNG")] tb_TRATHIETBI tb_TRATHIETBI)
        {
            if (ModelState.IsValid)
            {
                db.tb_TRATHIETBI.Add(tb_TRATHIETBI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_TRATHIETBI.IDNGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_TRATHIETBI.IDNHANVIEN);
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI", tb_TRATHIETBI.IDTHIETBI);
            return View(tb_TRATHIETBI);
        }

        // GET: tb_TRATHIETBI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TRATHIETBI tb_TRATHIETBI = db.tb_TRATHIETBI.Find(id);
            if (tb_TRATHIETBI == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_TRATHIETBI.IDNGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_TRATHIETBI.IDNHANVIEN);
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI", tb_TRATHIETBI.IDTHIETBI);
            return View(tb_TRATHIETBI);
        }

        // POST: tb_TRATHIETBI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TBReturnID,IDTHIETBI,IDNHANVIEN,NGAYYEUCAU,NGAYTRA,NGAYHIENTAI,IDNGUOIDUNG")] tb_TRATHIETBI tb_TRATHIETBI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_TRATHIETBI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_TRATHIETBI.IDNGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_TRATHIETBI.IDNHANVIEN);
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI", tb_TRATHIETBI.IDTHIETBI);
            return View(tb_TRATHIETBI);
        }

        // GET: tb_TRATHIETBI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TRATHIETBI tb_TRATHIETBI = db.tb_TRATHIETBI.Find(id);
            if (tb_TRATHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_TRATHIETBI);
        }

        // POST: tb_TRATHIETBI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_TRATHIETBI tb_TRATHIETBI = db.tb_TRATHIETBI.Find(id);
            db.tb_TRATHIETBI.Remove(tb_TRATHIETBI);
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
