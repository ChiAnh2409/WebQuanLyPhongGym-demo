using QLP_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class GoiTapController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: GoiTap
        public ActionResult Goitap()
        {
            List<GoiTap> list =new List<GoiTap>();
            list = db.GoiTap.ToList();
            return View(list);
        }

        public ActionResult ThemGT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemGT(GoiTap gt)
        {
            db.GoiTap.Add(gt);
            db.SaveChanges();
            return RedirectToAction("Goitap");
        }

        public ActionResult SuaGT(int id)
        {
            GoiTap gt = db.GoiTap.Find(id);
            return View(gt);
        }

        [HttpPost]
        public ActionResult SuaGT(GoiTap gt)
        {
            db.Entry(gt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Goitap");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var GoiTap = db.GoiTap.Find(id);
        //    if (GoiTap != null)
        //    {
        //        db.GoiTap.Remove(GoiTap);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Goitap");
        //}

        [HttpDelete]
        public ActionResult XoaGT(int id)
        {
            var GoiTap = db.GoiTap.Find(id);
            if (GoiTap != null)
            {
                db.GoiTap.Remove(GoiTap);
                db.SaveChanges();

            }
            return RedirectToAction("Goitap");
        }
    }
}