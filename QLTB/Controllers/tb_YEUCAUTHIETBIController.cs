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
    public class tb_YEUCAUTHIETBIController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();


        // GET: tb_YEUCAUTHIETBI
        public ActionResult IssueBooks()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_YEUCAUTHIETBI = db.tb_YEUCAUTHIETBI.Include(t => t.tb_NGUOIDUNG).Include(t => t.tb_NHANVIEN).Include(t => t.tb_THIETBI).Where(b => b.TRANGTHAI == true && b.ReserveNoOfCopies == false);
            return View(tb_YEUCAUTHIETBI.ToList());
        }
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_YEUCAUTHIETBI = db.tb_YEUCAUTHIETBI.Include(t => t.tb_NGUOIDUNG).Include(t => t.tb_NHANVIEN).Include(t => t.tb_THIETBI).Where(b => b.TRANGTHAI == true && b.ReserveNoOfCopies == false);
            return View(tb_YEUCAUTHIETBI.ToList());
        }
        public ActionResult ReserveBooks()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var tb_YEUCAUTHIETBI = db.tb_YEUCAUTHIETBI.Include(t => t.tb_NGUOIDUNG).Include(t => t.tb_NHANVIEN).Include(t => t.tb_THIETBI).Where(b => b.TRANGTHAI == false && b.ReserveNoOfCopies == true && b.NGAYTRA > DateTime.Now);
            return View(tb_YEUCAUTHIETBI.ToList());
        }

        public ActionResult ReturnPendingBooks()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            List<tb_YEUCAUTHIETBI> list = new List<tb_YEUCAUTHIETBI>();
            var tb_YEUCAUTHIETBI = db.tb_YEUCAUTHIETBI.Where(b => b.TRANGTHAI == true || b.ReserveNoOfCopies == true).ToList();
            foreach (var item in tb_YEUCAUTHIETBI)
            {
                var returndate = item.NGAYTRA;
                int noofdays = (DateTime.Now - returndate).Days;
                if (noofdays <= 3)
                {
                    list.Add(new tb_YEUCAUTHIETBI
                    {
                        IDTHIETBI = item.IDTHIETBI,
                        GHICHU = item.GHICHU,
                        tb_THIETBI = item.tb_THIETBI,
                        IDNHANVIEN = item.IDNHANVIEN,
                        tb_NHANVIEN = item.tb_NHANVIEN,
                        IDYEUCAUTB = item.IDYEUCAUTB,
                        SOLUONG = item.SOLUONG,
                        NGAYYEUCAU = item.NGAYYEUCAU,
                        NGAYTRA = item.NGAYTRA,
                        ReserveNoOfCopies = item.ReserveNoOfCopies,
                        TRANGTHAI = item.TRANGTHAI,
                        IDNGUOIDUNG = item.IDNGUOIDUNG,
                        tb_NGUOIDUNG = item.tb_NGUOIDUNG
                    });
                }
            }

            return View(list.ToList());
        }


        // GET: tb_YEUCAUTHIETBI/Details/5
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
            tb_YEUCAUTHIETBI tb_YEUCAUTHIETBI = db.tb_YEUCAUTHIETBI.Find(id);
            if (tb_YEUCAUTHIETBI == null)
            {
                return HttpNotFound();
            }
            return View(tb_YEUCAUTHIETBI);
        }

        // GET: tb_YEUCAUTHIETBI/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", "0");
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", "0");
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI", "0");
            return View();
        }

        // POST: tb_YEUCAUTHIETBI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_YEUCAUTHIETBI tb_YEUCAUTHIETBI)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
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
                    ViewBag.Message = "Kho hàng rỗng";
                    return View(tb_YEUCAUTHIETBI);
                }

                db.tb_YEUCAUTHIETBI.Add(tb_YEUCAUTHIETBI);
                db.SaveChanges();
                ViewBag.Message = "Yêu cầu thành công";
                return RedirectToAction("Index");
            }

            ViewBag.IDNGUOIDUNG = new SelectList(db.tb_NGUOIDUNG, "IDNGUOIDUNG", "TENNGUOIDUNG", tb_YEUCAUTHIETBI.IDNGUOIDUNG);
            ViewBag.IDNHANVIEN = new SelectList(db.tb_NHANVIEN, "IDNHANVIEN", "HOVATEN", tb_YEUCAUTHIETBI.IDNHANVIEN);
            ViewBag.IDTHIETBI = new SelectList(db.tb_THIETBI, "IDTHIETBI", "TENTHIETBI", tb_YEUCAUTHIETBI.IDTHIETBI);
            return View(tb_YEUCAUTHIETBI);
        }


        public ActionResult ApproveRequest(int? id)
        {
            var request = db.tb_YEUCAUTHIETBI.Find(id);
            request.ReserveNoOfCopies = false;
            request.TRANGTHAI = true;
            request.GHICHU = "Đã duyệt";
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ReserveBooks");
        }


        public ActionResult ReturnBook(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["IDNGUOIDUNG"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["IDNGUOIDUNG"]));
            var book = db.tb_YEUCAUTHIETBI.Find(id);
            int fine = 0;
            var returndate = book.NGAYTRA;
            int noofdays = (DateTime.Now - returndate).Days;
            if (book.TRANGTHAI == true && book.ReserveNoOfCopies == false)
            {
                if (noofdays > 0)
                {
                    fine = 20 * noofdays;
                }
                var returnbook = new tb_TRATHIETBI()
                {
                    IDTHIETBI = book.IDTHIETBI,
                    NGAYHIENTAI = DateTime.Now,
                    IDNHANVIEN = book.IDNHANVIEN,
                    NGAYYEUCAU = book.NGAYYEUCAU,
                    NGAYTRA = book.NGAYTRA,
                    IDNGUOIDUNG = userid

                };
                db.tb_TRATHIETBI.Add(returnbook);
                db.SaveChanges();
            }
            book.TRANGTHAI = false;
            book.ReserveNoOfCopies = false;
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            if(fine > 0)
            {
                var addfine = new TB_NHANTHIETBI()
                {
                    IDTHIETBI = book.IDTHIETBI,
                    IDNHANVIEN = book.IDNHANVIEN,
                    FineAmount = fine,
                    NGAYTRA = DateTime.Now,
                    TONGNGAYDUNG = noofdays,
                    ReceiveAmount = 0,
                    IDNGUOIDUNG = userid,
                };
                db.TB_NHANTHIETBI.Add(addfine);
                db.SaveChanges();
            }

            return RedirectToAction("IssueBooks");
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
