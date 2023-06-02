using QLP_Gym.Models;
using QLP_Gym.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLP_Gym.Controllers
{
    public class UserController : Controller
    {
        private QLPGEntities3 db = new QLPGEntities3();
        //tạo biến database để lấy dữ liệu
        // GET: User
        
        public ActionResult User()
        {
            var list = new MultipleData();
            list.Account = db.Account.Include("Roles");
            list.Roles = db.Roles.ToList();
            return View(list);
        }
        public ActionResult ThemND()
        {
            var list = new MultipleData();
            list.Account = db.Account.Include("Roles");
            list.Roles = db.Roles.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult ThemND(Account nd)
        {
            db.Account.Add(nd);
            db.SaveChanges();
            return RedirectToAction("User");
        }
        public ActionResult SuaND(int id)
        {
            var viewmodel = new MultipleData();
            viewmodel.Account = db.Account.Where(nd => nd.id == id).ToList();
            viewmodel.Roles = db.Roles.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SuaND(Account nd)
        {
            db.Entry(nd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpDelete]
        public ActionResult DeleteAjax(int id)
        {
            var Account = db.Account.Find(id);
            if (Account != null)
            {
                db.Account.Remove(Account);
                db.SaveChanges();

            }
            return RedirectToAction("User");
        }
    }
}