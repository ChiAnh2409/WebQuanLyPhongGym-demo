using QLP_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class BaoCaoController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: BaoCao
        public ActionResult BaoCao()
        {
            List<BaoCaoDoanhThu> list = new List<BaoCaoDoanhThu>();
            list = db.BaoCaoDoanhThu.ToList();
            return View(list);
        }
        public ActionResult ThemBC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemBC(BaoCaoDoanhThu bc)
        {
            db.BaoCaoDoanhThu.Add(bc);
            db.SaveChanges();
            return RedirectToAction("BaoCao");
        }

        public ActionResult SuaBC(int id)
        {
            BaoCaoDoanhThu bc = db.BaoCaoDoanhThu.Find(id);
            return View(bc);
        }

        [HttpPost]
        public ActionResult SuaBC(BaoCaoDoanhThu bc)
        {
            db.Entry(bc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("BaoCao");
        }

        [HttpDelete]
        public ActionResult XoaBC(int id)
        {
            var BaoCaoDoanhThu = db.BaoCaoDoanhThu.Find(id);
            if (BaoCaoDoanhThu != null)
            {
                db.BaoCaoDoanhThu.Remove(BaoCaoDoanhThu);
                db.SaveChanges();

            }
            return RedirectToAction("BaoCao");
        }
    }
}