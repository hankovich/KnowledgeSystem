using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.PL.Models;

namespace MVC.PL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;

        public ProfileController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var profile = userService.GetUserEntityByLogin(User.Identity.Name) ??
                          userService.GetUserEntityByEmail(User.Identity.Name);
            var model = new ProfileModel
            {
                id = profile.id,
                City = profile.City,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Company = profile.Company,
                DateOfBirth = profile.DateOfBirth?.Date.ToShortDateString() ?? string.Empty,//profile.DateOfBirth?.Date ?? profile.DateOfBirth,
                Phone = profile.Phone
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUserEntityByLogin(User.Identity.Name) ??
                           userService.GetUserEntityByEmail(User.Identity.Name);
                DateTime dateOfBirth;
                bool res = DateTime.TryParse(model.DateOfBirth, out dateOfBirth);
                if (!res || dateOfBirth.Date > DateTime.Now.Date) // костыли-костылики
                {
                    ModelState.AddModelError("DateOfBirth", "You are trying to deceive us");
                    return View(model);
                }

                var t = new UserEntity
                {
                    id = user.id,
                    DateOfBirth = DateTime.Parse(model.DateOfBirth),//model.DateOfBirth?.Date ?? model.DateOfBirth, ////////just a date
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Company = model.Company,
                    City = model.City,
                    Phone = model.Phone,
                    Login = user.Login,
                    Email = user.Email,
                    Password = user.Password
                };


                userService.UpdateUser(t);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}