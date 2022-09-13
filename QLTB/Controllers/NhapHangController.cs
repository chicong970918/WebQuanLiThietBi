using DataLayer;
using QLTB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLTB.Controllers
{
    public class NhapHangController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();
        // GET: NhapHang
        public ActionResult NewPurchase()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            double totalamount = 0;
            var temppur = db.PurTemDetailsTables.ToList();
            foreach (var item in temppur)
            {
                totalamount += (item.SOLUONG * item.DONGIA);
            }
            ViewBag.ToTalAmount = totalamount;

            return View(temppur);
        }
        public ActionResult AddItem(int BID, int Qty, float Price)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }


            var find = db.PurTemDetailsTables.Where(i => i.IDTHIETBI == BID).FirstOrDefault();
            if (find == null)
            {
                if (BID > 0 && Qty > 0 && Price > 0)
                {
                    var newitem = new PurTemDetailsTable()
                    {
                        IDTHIETBI = BID,
                        SOLUONG = Qty,
                        DONGIA = Price,

                    };
                    db.PurTemDetailsTables.Add(newitem);
                    db.SaveChanges();
                    ViewBag.Message = "Thêm thiết bị thành coong!";
                }
            }
            else
            {
                ViewBag.Message = "Đã tồn tại! Vui lòng kiểm tra";
            }
            return RedirectToAction("NewPurchase");
        }
        public ActionResult DeleteConfirm(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }


            var product = db.PurTemDetailsTables.Find(id);
            if (product != null)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                ViewBag.Message = "Xóa thành công!";
                return RedirectToAction("NewPurchase");
            }
            ViewBag.Message = "Lỗi!";
            return View("NewPurchase");
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }

            List<ProducMV> list = new List<ProducMV>();
            var productlist = db.tb_THIETBI.ToList();
            foreach (var item in productlist)
            {
                list.Add(new ProducMV { TENTHIETBI = item.TENTHIETBI, IDTHIETBI = item.IDTHIETBI });
            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CancelPurchase()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var list = db.PurTemDetailsTables.ToList();
            bool cancelstatus = false;
            foreach (var item in list)
                db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            int noofrecords = db.SaveChanges();
            if (cancelstatus == false)
            {
                if (noofrecords > 0)
                {
                    cancelstatus = true;
                }
            }
            if (cancelstatus == true)
            {
                ViewBag.Message = "Purchase is Canceled.";
                return RedirectToAction("NewPurchase");
            }
            ViewBag.Message = "Some Unexptected issue is occure,please contact to concern person!";
            return RedirectToAction("NewPurchase");
        }


        public ActionResult SelectSupplier()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var purchasedetails = db.PurTemDetailsTables.ToList();
            if (purchasedetails.Count == 0)
            {
                ViewBag.Message = "Giỏ hàng rỗng!";
                return RedirectToAction("NewPurchase");
            }
            var suppliers = db.tb_NHACUNGCAP.ToList();
            return View(suppliers);
        }
        [HttpPost]
        public ActionResult PurchaseConfirm(FormCollection collection)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            int supplierid = 0;
            string[] keys = collection.AllKeys;
            foreach (var name in keys)
            {
                if (name.Contains("name"))
                {
                    string idname = name;
                    string[] valueids = idname.Split(' ');
                    supplierid = Convert.ToInt32(valueids[1]);

                }
            }

            var purchasedetails = db.PurTemDetailsTables.ToList();


            double totalamount = 0;
            foreach (var item in purchasedetails)
            {
                totalamount = totalamount + (item.SOLUONG * item.DONGIA);
            }
            if (totalamount == 0)
            {
                ViewBag.Message = "Purchase Cart Empty!";
                return View("NewPurchase");
            }

            var purchaseheader = new tb_NHAPHANG();
            purchaseheader.IDNHACUNGCAP = supplierid;
            purchaseheader.NGAYNHAP = DateTime.Now;
            purchaseheader.GIA = totalamount;
            purchaseheader.IDNGUOIDUNG = userid;
            db.tb_NHAPHANG.Add(purchaseheader);
            db.SaveChanges();
            foreach (var item in purchasedetails)
            {
                var purdetials = new tb_CHITIETNHAPHANG()
                {
                    IDTHIETBI = item.IDTHIETBI,
                    IDNHAPHANG = purchaseheader.IDNHAPHANG,
                    SOLUONG = item.SOLUONG,
                    DONGIA = item.DONGIA
                };
                db.tb_CHITIETNHAPHANG.Add(purdetials);
                db.SaveChanges();

                var updatebookstock = db.tb_THIETBI.Find(item.IDTHIETBI);
                updatebookstock.SOLUONG = updatebookstock.SOLUONG + item.SOLUONG;
                updatebookstock.GIA = item.DONGIA;
                db.Entry(updatebookstock).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            db.PurTemDetailsTables.ToList().ForEach(x =>
            {
                db.Entry(x).State = System.Data.Entity.EntityState.Deleted;
            });
            db.SaveChanges();
            ViewBag.Message = "Nhập hàng thành công!";
            return RedirectToAction("AllPurchase");

        }
        public ActionResult AllPurchase()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var list = db.tb_NHAPHANG.ToList();
            return View(list);

        }
        public ActionResult PurchaseDetailsView(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = db.tb_CHITIETNHAPHANG.Where(b => b.IDNHAPHANG == id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
    }
}
