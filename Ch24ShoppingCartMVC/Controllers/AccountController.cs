using Ch24ShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        AccountRepo accountRepo = new AccountRepo();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account acc)
        {
            Account verfAccount = accountRepo.Accounts.Where(x => x.Uname.Equals(acc.Uname)).FirstOrDefault();
            if (verfAccount != null)
            {
                if (acc.Password == verfAccount.Password)
                {
                    Session["LoggedIn"] = 1;
                    return RedirectToAction("Index","Order");
                }
            }
            Session["LoggedIn"] = 0;
            return RedirectToAction("Index");
        }
    }
}
