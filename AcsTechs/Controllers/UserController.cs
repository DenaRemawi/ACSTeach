using AcsTechs.Models;
using AcsTechs.Servises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcsTechs.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public ActionResult ListUser()
        {
            userService = new UserService();
               var model = userService.GetUserList();
            return View(model);
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserModels models)

        {
            userService = new UserService();

            userService.AddUser(models);
            return RedirectToAction("ListUser");
        }
    }
}