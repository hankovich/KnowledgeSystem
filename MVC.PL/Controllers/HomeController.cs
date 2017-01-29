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
        
        /*
        public ActionResult Index()
        {
            var model = _repository.GetAllUsers().Select(u => new UserViewModel()
            {
                Email = u.Email,
                CreationDate = u.CreationDate,
                Role = u.Role.Name
            });

            return View(model);
        }
        */
        /*
        public ActionResult About()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.AuthType = User.Identity.AuthenticationType;
            }
            ViewBag.Login = User.Identity.Name;
            ViewBag.IsAdminInRole = User.IsInRole("Administrator") ?
                "You have administrator rights." : "You do not have administrator rights.";

            return View();
            //HttpContext.Profile["FirstName"] = "Вася";
            //HttpContext.Profile["LastName"] = "Иванов";
            //HttpContext.Profile.SetPropertyValue("Age",23);
            //Response.Write(HttpContext.Profile.GetPropertyValue("FirstName"));
            //Response.Write(HttpContext.Profile.GetPropertyValue("LastName"));
        }*/
        /*
        [Authorize(Roles = "Administrator")]
        public ActionResult UsersEdit()
        {
            var model = _repository.GetAllUsers().Select(u => new UserViewModel
            {
                Email = u.Email,
                CreationDate = u.CreationDate,
                Role = u.Role.Name
            });

            return View(model);
        }*/
    }
}