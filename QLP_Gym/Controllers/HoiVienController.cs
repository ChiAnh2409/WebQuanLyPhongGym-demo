using QLP_Gym.Models;
using QLP_Gym.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class HoiVienController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: User
        public ActionResult HoiVien()
        {
            var list = new MultipleData();
            list.hoiViens = db.HoiVien.Include("ThanhVien");
            list.hoiViens = db.HoiVien.Include("GoiTap");
            list.thanhViens = db.ThanhVien.ToList();
            list.goiTap = db.GoiTap.ToList();
            return View(list);
        }
        public ActionResult ThemHV()
        {
            var list = new MultipleData();
            list.hoiViens = db.HoiVien.Include("ThanhVien");
            list.hoiViens = db.HoiVien.Include("GoiTap");
            list.thanhViens = db.ThanhVien.ToList();
            list.goiTap = db.GoiTap.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult ThemHV(HoiVien hv)
        {
            db.HoiVien.Add(hv);
            hv.TinhTrang = true;
            DateTime now = DateTime.Now;
            hv.NgayGiaNhap = now;
            db.SaveChanges();
            return RedirectToAction("HoiVien");
        }

        public ActionResult SuaHV(int id)
        {
            var viewmodel = new MultipleData();
            viewmodel.hoiViens = db.HoiVien.Where(hv => hv.id_HV == id).ToList();
            viewmodel.thanhViens = db.ThanhVien.ToList();
            viewmodel.goiTap = db.GoiTap.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SuaHV(HoiVien hv)
        {
            HoiVien existingHoiVien = db.HoiVien.Find(hv.id_HV);

            if (existingHoiVien != null)
            {
                existingHoiVien.id_TV = hv.id_TV;
                existingHoiVien.TenHV = hv.TenHV;
                existingHoiVien.id_GT = hv.id_GT;
                existingHoiVien.TinhTrang = hv.TinhTrang;

                if (existingHoiVien.HanGiaNhap.HasValue) // Only update HanGiaNhap if it has a value
                {
                    existingHoiVien.HanGiaNhap = hv.HanGiaNhap;
                }

                db.Entry(existingHoiVien).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("HoiVien");
        }
        [HttpDelete]
        public ActionResult XoaHV(int id)
        {
            var HoiVien = db.HoiVien.Find(id);
            if (HoiVien != null)
            {
                db.HoiVien.Remove(HoiVien);
                db.SaveChanges();

            }
            return RedirectToAction("HoiVien");
        }
    }
}