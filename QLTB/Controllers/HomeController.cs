using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTB.Controllers
{
    public class HomeController : Controller
    {
        private QuanLyThietBiCongTyEntities db = new QuanLyThietBiCongTyEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(string username, string password)
        {
            try
            {
                if (username != null && password != null)
                {
                    var finduser = db.tb_NGUOIDUNG.Where(u => u.TENNGUOIDUNG == username && u.PASSWORD == password && u.TINHTRANGHOATDONG == true).ToList();
                    if (finduser.Count() == 1)
                    {
                        Session["IDNGUOIDUNG"] = finduser[0].IDNGUOIDUNG;
                        Session["IDLOAINGUOIDUNG"] = finduser[0].IDLOAINGUOIDUNG;
                        Session["TENNGUOIDUNG"] = finduser[0].TENNGUOIDUNG;
                        Session["PASSWORD"] = finduser[0].PASSWORD;
                        Session["IDNHANVIEN"] = finduser[0].IDNHANVIEN;

                        string url = string.Empty;
                        if (finduser[0].IDLOAINGUOIDUNG == 2)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].IDLOAINGUOIDUNG == 3)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].IDLOAINGUOIDUNG == 4)
                        {
                            return RedirectToAction("About");
                        }
                        else if (finduser[0].IDLOAINGUOIDUNG == 1)
                        {
                            url = "About";
                        }
                        return RedirectToAction(url);
                    }
                    else
                    {
                        Session["IDNGUOIDUNG"] = string.Empty;
                        Session["IDLOAINGUOIDUNG"] = string.Empty;
                        Session["TENNGUOIDUNG"] = string.Empty;
                        Session["PASSWORD"] = string.Empty;
                        Session["IDNHANVIEN"] = string.Empty;
                        ViewBag.message = "Tên người dùng hoặc mật khẩu không chính xác!";
                    }
                }
                else
                {
                    Session["IDNGUOIDUNG"] = string.Empty;
                    Session["IDLOAINGUOIDUNG"] = string.Empty;
                    Session["TENNGUOIDUNG"] = string.Empty;
                    Session["PASSWORD"] = string.Empty;
                    Session["IDNHANVIEN"] = string.Empty;
                    ViewBag.message = "Lỗi!";
                }
            }
            catch (Exception ex)
            {
                Session["IDNGUOIDUNG"] = string.Empty;
                Session["IDLOAINGUOIDUNG"] = string.Empty;
                Session["TENNGUOIDUNG"] = string.Empty;
                Session["PASSWORD"] = string.Empty;
                Session["IDNHANVIEN"] = string.Empty;
                ViewBag.message = "Lỗi!";
            }
            return View("Login");

        }

     

        public ActionResult About()
        {

            return View();
        }
        public ActionResult Logout()
        {
            Session["IDNGUOIDUNG"] = string.Empty;
            Session["IDLOAINGUOIDUNG"] = string.Empty;
            Session["TENNGUOIDUNG"] = string.Empty;
            Session["PASSWORD"] = string.Empty;
            Session["IDNHANVIEN"] = string.Empty;
            return RedirectToAction("Login");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}