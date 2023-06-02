using QLP_Gym.Models;
using QLP_Gym.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class DK_GoiTapController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: User
        public ActionResult DK_GoiTap()
        {
            var list = new MultipleData();
            list.chiTietDK_goiTap = db.ChiTietDK_GoiTap.Include("GoiTap");
            list.chiTietDK_goiTap = db.ChiTietDK_GoiTap.Include("HoiVien");
            list.goiTap = db.GoiTap.ToList();
            list.hoiViens = db.HoiVien.ToList();
            return View(list);
        }
        public ActionResult ThemChiTiet_DKGT()
        {
            var list = new MultipleData();
            list.chiTietDK_goiTap = db.ChiTietDK_GoiTap.Include("GoiTap");
            list.chiTietDK_goiTap = db.ChiTietDK_GoiTap.Include("HoiVien");
            list.goiTap = db.GoiTap.ToList();
            list.hoiViens = db.HoiVien.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult ThemChiTiet_DKGT(ChiTietDK_GoiTap dkgt)
        {
            // Lấy thông tin gói tập từ cơ sở dữ liệu
            var goiTap = db.GoiTap.FirstOrDefault(g => g.id_GT == dkgt.id_GT);
            if (goiTap != null)
            {
                // Gán giá trị cho thuộc tính "ThanhTien" dựa trên chi phí của gói tập
                dkgt.ThanhTien = goiTap.ChiPhi;
            }

            db.ChiTietDK_GoiTap.Add(dkgt);
            db.SaveChanges();
            return RedirectToAction("DK_GoiTap");
        }

        public ActionResult SuaChiTiet_DKGT(int id)
        {
            var viewmodel = new MultipleData();
            viewmodel.chiTietDK_goiTap= db.ChiTietDK_GoiTap.Where(dkgt => dkgt.id_CTDKGoiTap == id).ToList();
            viewmodel.goiTap = db.GoiTap.ToList();
            viewmodel.hoiViens = db.HoiVien.ToList();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult SuaChiTiet_DKGT(ChiTietDK_GoiTap dkgt)
        {
            var existingDKGT = db.ChiTietDK_GoiTap.FirstOrDefault(item => item.id_CTDKGoiTap == dkgt.id_CTDKGoiTap);
            if (existingDKGT != null)
            {
                existingDKGT.id_GT = dkgt.id_GT;
                existingDKGT.id_HV = dkgt.id_HV;
                existingDKGT.ThanhTien = dkgt.ThanhTien;

                db.SaveChanges();
            }

            return RedirectToAction("DK_GoiTap");
        }

        [HttpDelete]
        public ActionResult XoaChiTiet_DKGT(int id)
        {
            var ChiTietDK_GoiTap = db.ChiTietDK_GoiTap.Find(id);
            if (ChiTietDK_GoiTap != null)
            {
                db.ChiTietDK_GoiTap.Remove(ChiTietDK_GoiTap);
                db.SaveChanges();

            }
            return RedirectToAction("DK_GoiTap");
        }
    }
}