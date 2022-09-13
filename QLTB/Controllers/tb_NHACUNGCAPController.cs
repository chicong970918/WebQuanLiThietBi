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
    public class tb_NHACUNGCAPController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_NHACUNGCAP
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var tb_NHACUNGCAP = db.tb_NHACUNGCAP.Include(t => t.tb_NGUOIDUNG);
            return View(tb_NHACUNGCAP.ToList());
        }

        // GET: tb_NHACUNGCAP/Details/5
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
            tb_NHACUNGCAP tb_NHACUNGCAP = db.tb_NHACUNGCAP.Find(id);
            if (tb_NHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(tb_NHACUNGCAP);
        }

        // GET: tb_NHACUNGCAP/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        // POST: tb_NHACUNGCAP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_NHACUNGCAP tb_NHACUNGCAP)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NHACUNGCAP.IDNGUOIDUNG = userid;


            if (ModelState.IsValid)
            {
                var find = db.tb_NHACUNGCAP.Where(s => s.TENNHACUNGCAP == tb_NHACUNGCAP.TENNHACUNGCAP && s.SDT == tb_NHACUNGCAP.SDT).FirstOrDefault();
                if (find == null)
                {
                    db.tb_NHACUNGCAP.Add(tb_NHACUNGCAP);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Nhà cung cấp đã được thêm";
                }

            }

            return View(tb_NHACUNGCAP);
        }

        // GET: tb_NHACUNGCAP/Edit/5
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
            tb_NHACUNGCAP tb_NHACUNGCAP = db.tb_NHACUNGCAP.Find(id);
            if (tb_NHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_NHACUNGCAP.IDNGUOIDUNG);
            return View(tb_NHACUNGCAP);
        }

        // POST: tb_NHACUNGCAP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_NHACUNGCAP tb_NHACUNGCAP)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_NHACUNGCAP.IDNGUOIDUNG = userid;
            if (ModelState.IsValid)
            {
                db.Entry(tb_NHACUNGCAP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_NHACUNGCAP.IDNGUOIDUNG);
            return View(tb_NHACUNGCAP);
        }

        // GET: tb_NHACUNGCAP/Delete/5
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
            tb_NHACUNGCAP tb_NHACUNGCAP = db.tb_NHACUNGCAP.Find(id);
            if (tb_NHACUNGCAP == null)
            {
                return HttpNotFound();
            }
            return View(tb_NHACUNGCAP);
        }

        // POST: tb_NHACUNGCAP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            tb_NHACUNGCAP tb_NHACUNGCAP = db.tb_NHACUNGCAP.Find(id);
            db.tb_NHACUNGCAP.Remove(tb_NHACUNGCAP);
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
