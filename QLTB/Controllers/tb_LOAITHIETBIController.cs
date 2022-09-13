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
    public class tb_LOAITHIETBIController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: tb_LOAITHIETBI
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            return View(db.tb_LOAITHIETBI.ToList());
        }

        // GET: tb_LOAITHIETBI/Details/5
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
            tb_LOAITHIETBI tb_LOAITHIETBI = db.tb_LOAITHIETBI.Find(id);
            if (tb_LOAITHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAITHIETBI);
        }

        // GET: tb_LOAITHIETBI/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: tb_LOAITHIETBI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_LOAITHIETBI tb_LOAITHIETBI)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_LOAITHIETBI.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.tb_LOAITHIETBI.Add(tb_LOAITHIETBI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_LOAITHIETBI);
        }

        // GET: tb_LOAITHIETBI/Edit/5
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
            tb_LOAITHIETBI tb_LOAITHIETBI = db.tb_LOAITHIETBI.Find(id);
            if (tb_LOAITHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAITHIETBI);
        }

        // POST: tb_LOAITHIETBI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_LOAITHIETBI tb_LOAITHIETBI)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            tb_LOAITHIETBI.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                db.Entry(tb_LOAITHIETBI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_LOAITHIETBI);
        }

        // GET: tb_LOAITHIETBI/Delete/5
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
            tb_LOAITHIETBI tb_LOAITHIETBI = db.tb_LOAITHIETBI.Find(id);
            if (tb_LOAITHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_LOAITHIETBI);
        }

        // POST: tb_LOAITHIETBI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            tb_LOAITHIETBI tb_LOAITHIETBI = db.tb_LOAITHIETBI.Find(id);
            db.tb_LOAITHIETBI.Remove(tb_LOAITHIETBI);
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
