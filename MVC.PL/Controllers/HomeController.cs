using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;

namespace MVC.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Home
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}