using QLP_Gym.Models;
using QLP_Gym.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace QLP_Gym.Controllers
{
    public class CTBaoCaoController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();

        public ActionResult CTBaoCao()
        {
            var list = new MultipleData();

            // Lấy danh sách chi tiết đăng ký gói tập
            list.chiTietDK_goiTap = db.ChiTietDK_GoiTap.Include("GoiTap").Include("HoiVien").ToList();

            // Lấy danh sách báo cáo doanh thu
            list.baoCaoDoanhThus = db.BaoCaoDoanhThu.ToList();

            return View(list);
        }
        public ActionResult GetReportData(int id_BC, DateTime startDate, DateTime endDate)
        {
            var baoCaoDoanhThu = db.BaoCaoDoanhThu
                .Include(b => b.ChiTietBaoCao.Select(c => c.GoiTap))
                .Where(b => b.id_BC == id_BC && b.NgayBatDau >= startDate && b.NgayKetThuc <= endDate)
                .ToList();

            return PartialView("_TableDataPartial", baoCaoDoanhThu);
        }


    }
}
