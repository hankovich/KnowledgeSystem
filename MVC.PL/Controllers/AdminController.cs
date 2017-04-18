using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private AdminModel GenerateModel()
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
                        Level = 0,
                        CategoryId = sc.id
                    }),
                }),
            };
            return model;
        }

        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            return View(GenerateModel());
        }

        [Authorize(Roles = "administrator")]
        public ActionResult Delete(int? userId)
        {
            if (userId == null)
                return PartialView("_UsersView", GenerateModel());

            if (userId == (userService.GetUserEntityByLogin(User.Identity.Name)?.id ?? userService.GetUserEntityByEmail(User.Identity.Name)?.id))
                return PartialView("_UsersView", GenerateModel());

            var userToDelete = userService.GetUserEntityById(userId.Value);
            
            userService.RemoveAllRolesFromUser(userId.Value);
            userSkillService.RemoveAllUserSkills(userId.Value);
            userService.DeleteUser(userToDelete);

            return PartialView("_UsersView", GenerateModel());
        }

        [Authorize(Roles = "administrator")]
        public ActionResult AddRole(int userId = 0, string roleName = "")
        {
            var userToRemove = userService.GetUserEntityById(userId);
            var roleToRemove = roleService.GetRoleEntityByName(roleName);
            if (userToRemove != null && roleToRemove != null && !roleService.GetRoleEntitiesOfUser(userToRemove.id).Contains(roleToRemove))
                userService.AddRoleToUser(userToRemove.Login, roleToRemove.Name);

            return PartialView("_UserView", GenerateModel().userRole.FirstOrDefault(user => user.id == userId));
            //return Json( new {id = userId, role = roleName}, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrator")]
        public ActionResult RemoveRole(int userId = 0, string roleName = "")
        {
            var userToRemove = userService.GetUserEntityById(userId);
            var roleToRemove = roleService.GetRoleEntityByName(roleName);
            if (userToRemove != null)
            {
                var roleIdsOfUser = roleService.GetRoleEntitiesOfUser(userToRemove.id).Select(role => role.id);
                if (roleToRemove != null && roleIdsOfUser.Contains(roleToRemove.id))
                    userService.RemoveRoleFromUser(userToRemove.id, roleToRemove.id);
            }
            return PartialView("_UserView", GenerateModel().userRole.FirstOrDefault(user => user.id == userId));
            //return Json( new {id = userId, role = roleName}, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "administrator")]
        public ActionResult AddCategory(string categoryName = "")
        {
            if (categoryName != string.Empty)
            {
                if (skillCategoryService.GetSkillCategoryEntityByName(categoryName) == null)
                {
                    skillCategoryService.CreateSkillCategory(new SkillCategoryEntity()
                    {
                        Name = categoryName
                    });
                }
                else
                {
                    return JavaScript("DisplayFailToAddCategory();");
                }
            }

            return PartialView("_SkillAdminView", GenerateModel().skills.FirstOrDefault(skillCategoryModel => skillCategoryModel.Name == categoryName));
        }

        [Authorize(Roles = "administrator")]
        public ActionResult RenameCategory(string categoryName = "", string newCategoryName = "")
        {
            var skillCategory = skillCategoryService.GetSkillCategoryEntityByName(categoryName);
            if (skillCategory != null && newCategoryName != string.Empty)
            {
                skillCategory.Name = newCategoryName;
                var skillCategoryWithNewName = skillCategoryService.GetSkillCategoryEntityByName(newCategoryName);

                if (skillCategoryWithNewName == null)
                    skillCategoryService.UpdateSkillCategory(skillCategory);

                return PartialView("_SkillAdminView", GenerateModel().skills.FirstOrDefault(skillCategoryModel => skillCategoryModel.Name == newCategoryName));
            }
            return PartialView("_SkillAdminView");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult AddSkillToCategory(string categoryName = "", string skillName = "")
        {
            var skillCategory = skillCategoryService.GetSkillCategoryEntityByName(categoryName);
            var newSkill = new SkillEntity
            {
                SkillName = skillName,
            };

            if (skillCategory != null && skillName != string.Empty && !skillService.GetAllSkillEntitiesForCategory(skillCategory.id).Contains(newSkill))
            {
                newSkill.SkillCategoryId = skillCategory.id;
                skillService.CreateSkill(newSkill);

                return PartialView("_SkillAdminView", GenerateModel().skills.FirstOrDefault(skillCategoryModel => skillCategoryModel.Name == categoryName));
            }

            return PartialView("_SkillAdminView");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult DeleteCategory(string categoryName = "")
        {
            var skillCategory = skillCategoryService.GetSkillCategoryEntityByName(categoryName);
            if (skillCategory != null)
            {
                var skillsInCategory = skillService.GetAllSkillEntitiesForCategory(skillCategory.id);
                foreach (var skill in skillsInCategory)
                {
                    skillService.DeleteSkill(skill);
                }
                skillCategoryService.DeleteSkillCategory(skillCategory);
               
                return PartialView("_SkillsAdminView", GenerateModel());
            }

            return PartialView("_SkillsAdminView");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult RenameSkill(string skillName = "", string newSkillName = "")
        {
            var skill = skillService.GetSkillEntityByPredicate(skill1 => skill1.SkillName == skillName);
            if (skill != null && newSkillName != string.Empty)
            {
                skill.SkillName = newSkillName;
                var skillWithNewName = skillService.GetSkillEntityByPredicate(skill1 => skill1.SkillName == newSkillName);

                if (skillWithNewName == null)
                    skillService.UpdateSkill(skill);

                return PartialView("_SingleSkillAdminView", GenerateModel().skills.FirstOrDefault(skillCategoryModel => skillCategoryModel.Id == skill.SkillCategoryId)?.Skills.FirstOrDefault(skill1 => skill1.Id == skill.id));
            }
            return PartialView("_SingleSkillAdminView");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult DeleteSkill(string skillName = "")
        {
            if (skillName != string.Empty)
            {
                var skillToDelete = skillService.GetAllSkillEntities().FirstOrDefault(skill => skill.SkillName == skillName);
                if (skillToDelete != null)
                {
                    skillService.DeleteSkill(skillToDelete);
                    return PartialView("_SkillAdminView", GenerateModel().skills.FirstOrDefault(skillCategory => skillCategory.Id == skillToDelete.SkillCategoryId));
                }
            }
            return PartialView("_SkillAdminView");
        }

        [Authorize(Roles = "administrator")]
        public ActionResult UpdateStatistics()
        {
            return PartialView("_StatisticsView", GenerateModel());
        }
    }
}