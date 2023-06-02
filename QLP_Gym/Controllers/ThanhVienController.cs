using QLP_Gym.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class ThanhVienController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: ThanhVien
        public ActionResult Thanhvien()
        {
            List<ThanhVien> list = new List<ThanhVien>();
            list = db.ThanhVien.ToList();
            return View(list);
        }

        public ActionResult ThemTV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemTV(ThanhVien tv)
        {
            String HinhAnh = "";
            
            HttpPostedFileBase file = Request.Files["HinhAnh"];
            if (file != null && file.FileName != "")
            {
                String serverPath = HttpContext.Server.MapPath("~/assets/img/team");
                String filePath = serverPath + "/" + file.FileName;
                file.SaveAs(filePath);
                HinhAnh = file.FileName; 
            }
            tv.HinhAnh = HinhAnh;
            DateTime now = DateTime.Now;
            tv.NgayTao = now;
            db.ThanhVien.Add(tv);
            db.SaveChanges();
            return RedirectToAction("Thanhvien");
        }

        public ActionResult SuaTV(int id)
        {
            ThanhVien tv = db.ThanhVien.Find(id);
            return View(tv);
        }

        [HttpPost]
        public ActionResult SuaTV(ThanhVien tv)
        {
            String HinhAnh = "";

            HttpPostedFileBase file = Request.Files["HinhAnh"];
            if (file != null && file.FileName != "")
            {
                String serverPath = HttpContext.Server.MapPath("~/assets/img/team");
                String filePath = serverPath + "/" + file.FileName;
                file.SaveAs(filePath);
                HinhAnh = file.FileName;
            }
            tv.HinhAnh = HinhAnh;
            //DateTime now = DateTime.Now;
            db.Entry(tv).State = System.Data.Entity.EntityState.Modified;
            //tv.NgayTao = now;
            db.SaveChanges();
            return RedirectToAction("Thanhvien");
        }
        [HttpDelete]
        public ActionResult XoaTV(int id)
        {
            var ThanhVien = db.ThanhVien.Find(id);
            if (ThanhVien != null)
            {
                db.ThanhVien.Remove(ThanhVien);
                db.SaveChanges();

            }
            return RedirectToAction("Thanhvien");
        }

    }
}