using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTB.Controllers
{
    public class NhanThietBiController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();

        // GET: NhanThietBi
        public ActionResult PendingFine()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pendingfine = db.TB_NHANTHIETBI.Where(f => f.ReceiveAmount == 0);
            return View(pendingfine.ToList());
        }
        public ActionResult FineHistory()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var pending = db.TB_NHANTHIETBI.Where(f => f.ReceiveAmount> 0);
            return View(pending.ToList());
        }
        public ActionResult SubmitFine(int? id)
        {
            var fine = db.TB_NHANTHIETBI.Find(id);
            fine.ReceiveAmount = fine.FineAmount;
            fine.NGAYTRA = DateTime.Now;
            db.Entry(fine).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PendingFine");
        }
    }
}