using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.PL.Models;

namespace MVC.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly ISkillService skillService;
        private readonly ISkillCategoryService skillCategoryService;
        private readonly IUserSkillService userSkillService;

        public AdminController(IUserService userService, IRoleService roleService, ISkillService skillService, ISkillCategoryService skillCategoryService, IUserSkillService userSkillService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.skillService = skillService;
            this.skillCategoryService = skillCategoryService;
            this.userSkillService = userSkillService;
        }

        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            var model = new AdminModel
            {
                userRole = userService.GetAllUserEntities().Select(user => new UserRoleModel
                {
                    id = user.id,
                    Login = user.Login,
                    Email = user.Email,
                    Roles = roleService.GetRoleEntitiesOfUser(user.id).Select(role => role.Name),
                    AllRoles = roleService.GetAllRoleEntities().Select(role => role.Name),
                }),
                userSkills = userSkillService.GetAllUserSkillEntities(),

                skills = skillCategoryService.GetAllSkillCategoryEntities().Select(sc => new SkillCategoryModel
                {
                    Id = sc.id,
                    Name = sc.Name,
                    Skills = skillService.GetAllSkillEntitiesForCategory(sc.id).Select(skill => new SkillModel
                    {
                        Id = skill.id,
                        Name = skill.SkillName,
                        Level = 0
                    }),
                }),
            };

            return View(model);
        }

        [Authorize(Roles = "administrator")]
        public ActionResult Delete(int? userId)
        {
            if (userId == null)
                return RedirectToAction("Index");

            if (userId == (userService.GetUserEntityByLogin(User.Identity.Name)?.id ?? userService.GetUserEntityByEmail(User.Identity.Name)?.id))
                return RedirectToAction("Index");

            var user = userService.GetUserEntityById(userId.Value);
            
            userService.RemoveAllRolesFromUser(userId.Value);
            userSkillService.RemoveAllUserSkills(userId.Value);
            userService.DeleteUser(user);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "administrator")]
        //[HttpPost]
        public ActionResult AddRole(int userId = 0, string roleName = "")
        {
            var user = userService.GetUserEntityById(userId);
            userService.AddRoleToUser(user.Login, roleName);
            return RedirectToAction("Index");
            //return Json( new {id = userId, role = roleName}, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrator")]
        //[HttpPost]
        public ActionResult RemoveRole(int userId = 0, string roleName = "")
        {
            var user = userService.GetUserEntityById(userId);
            var role = roleService.GetRoleEntityByName(roleName);
            if (user != null && role != null)
                userService.RemoveRoleFromUser(user.id, role.id);
            return RedirectToAction("Index");
            //return Json( new {id = userId, role = roleName}, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrator")]
        //[HttpPost]
        public ActionResult AddCategory(string categoryName = "")
        {
            if (categoryName != string.Empty)
            {
                skillCategoryService.CreateSkillCategory(new SkillCategoryEntity()
                {
                    Name = categoryName
                });
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult AddSkillToCategory(string categoryName, string skillName)
        {
            return null;
        }
    }
}