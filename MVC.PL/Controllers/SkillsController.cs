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
    public class SkillsController : Controller
    {
        private readonly IUserService userService;
        private readonly ISkillService skillService;
        private readonly ISkillCategoryService skillCategoryService;

        public SkillsController(IUserService userService, ISkillService skillService, ISkillCategoryService skillCategoryService)
        {
            this.userService = userService;
            this.skillService = skillService;
            this.skillCategoryService = skillCategoryService;
        }

        [Authorize]
        public ActionResult Manage()
        {
            var user = userService.GetUserEntityByLogin(User.Identity.Name) ??
                          userService.GetUserEntityByEmail(User.Identity.Name);

            var model = skillCategoryService.GetAllSkillCategoryEntities().Select(sc => new SkillCategoryModel
            {
                Id = sc.id,
                Name = sc.Name,
                Skills = skillService.GetAllSkillEntitiesForCategory(sc.id).Select(skill => new SkillModel
                {
                    Id = skill.id,
                    Name = skill.SkillName
                }),
            });
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(SkillCategoryModel model)
        {
            /*if (ModelState.IsValid)
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
            }*/
            return View(model);
        }
    }
}