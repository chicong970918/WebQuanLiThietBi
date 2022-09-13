using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTB.Controllers
{
    public class ReserveThietBiController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();
        public string Message { get; set; }
        // GET: ReserveThietBi
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Message = Message;
            var thietbi = db.tb_THIETBI.ToList();
            return View(thietbi);
        }
        public ActionResult ReserveThietBi(int? id)
        {
            var tb = db.tb_THIETBI.Find(id);
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            int idnv = Convert.ToInt32(Convert.ToString(Session["IDNHANVIEN"]));

            var tb_YEUCAUTHIETBI = new tb_YEUCAUTHIETBI()
            {
                IDTHIETBI = tb.IDTHIETBI,
                GHICHU = "Reserve Request!",
                IDNHANVIEN = idnv,
                SOLUONG = 1,
                NGAYYEUCAU = DateTime.Now,
                NGAYTRA = DateTime.Now.AddDays(2),
                TRANGTHAI = false,
                ReserveNoOfCopies = true,
                IDNGUOIDUNG = userid
            };
            tb_YEUCAUTHIETBI.IDNGUOIDUNG = userid;

            if (ModelState.IsValid)
            {
                var find = db.tb_YEUCAUTHIETBI.Where(b => b.NGAYTRA >= DateTime.Now && b.IDTHIETBI == tb_YEUCAUTHIETBI.IDTHIETBI && (b.TRANGTHAI == true || b.ReserveNoOfCopies == true)).ToList();
                int issuebook = 0;
                foreach (var item in find)
                {
                    issuebook = issuebook + item.SOLUONG;
                }

                var stockbook = db.tb_THIETBI.Where(b => b.IDTHIETBI == tb_YEUCAUTHIETBI.IDTHIETBI).FirstOrDefault();

                if ((issuebook == stockbook.SOLUONG) || (issuebook + tb_YEUCAUTHIETBI.SOLUONG > stockbook.SOLUONG))
                {
                    Message = "Kho hàng rỗng";
                    return RedirectToAction("Index");
                }



                db.tb_YEUCAUTHIETBI.Add(tb_YEUCAUTHIETBI);
                db.SaveChanges();
                Message = "Yêu cầu thành công";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}