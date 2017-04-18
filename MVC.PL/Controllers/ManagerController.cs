using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.PL.Models;
using Newtonsoft.Json;


namespace MVC.PL.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ISkillCategoryService skillCategoryService;
        private readonly IUserSkillService userSkillService;
        private readonly ISkillService skillService;
        private readonly IUserService userService;

        public ManagerController(ISkillCategoryService skillCategoryService, IUserSkillService userSkillService,
            ISkillService skillService, IUserService userService)
        {
            this.skillCategoryService = skillCategoryService;
            this.skillService = skillService;
            this.userSkillService = userSkillService;
            this.userService = userService;
        }

        // GET: Manager
        [Authorize(Roles = "manager")]
        public ActionResult Index()
        {
            TempData["list"] = new List<KeyValuePair<int, int>>();
            return View(GenerateModel());
        }

        [Authorize(Roles = "manager")]
        private ManagerModel GenerateModel(List<KeyValuePair<int, int>> list = null)
        {
            var allUsers = userService.GetAllUserEntities();
            List<ProfileModel> profilesToShow = (from user in allUsers
                let count =
                    list?.Count(
                        skill => userSkillService.GetLevelOfSkillForUserEntity(user.id, skill.Key) >= skill.Value) ?? 0
                where list == null || count == list.Count
                select new ProfileModel
                {
                    id = user.id,
                    City = user.City,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Company = user.Company,
                    DateOfBirth = user.DateOfBirth?.Date.ToShortDateString() ?? string.Empty,
                    Phone = user.Phone,
                    Email = user.Email,
                    Login = user.Login
                }).ToList();

            var model = new ManagerModel
            {
                SkillCategory = skillCategoryService.GetAllSkillCategoryEntities().Select(sc => new SkillCategoryModel
                {
                    Id = sc.id,
                    Name = sc.Name,
                    Skills = skillService.GetAllSkillEntitiesForCategory(sc.id).Select(skill => new SkillModel
                    {
                        Id = skill.id,
                        Name = skill.SkillName,
                        Level = list?.FirstOrDefault(listItem => listItem.Key == skill.id).Value ?? 0
                    }),

                }),
                Users = profilesToShow,
            };
            return model;
        }

        [Authorize(Roles = "manager")]
        public ActionResult RateSkill(int id, int rate)
        {
            List<KeyValuePair<int, int>> list = (List<KeyValuePair<int, int>>) TempData["list"];
            //List<Pair> list = JsonConvert.DeserializeObject<List<Pair>>(listStr);

            if (list.Any(listItem => listItem.Key == id))
            {
                int oldRate = list.FirstOrDefault(listItem => listItem.Key == id).Value;
                list.Remove(new KeyValuePair<int, int>(id, oldRate));
            }
            if (rate != 0)
                list.Add(new KeyValuePair<int, int>(id, rate));

            TempData.Keep("list");
            bool success = true;
            string error = "";


            return
                Json(
                    new
                    {
                        error = error,
                        success = success,
                        pid = id,
                        View = PartialView("_ManagerUpdateView", GenerateModel(list)).RenderToString()
                    },
                    JsonRequestBehavior.AllowGet);
        }
    }

    public static class ViewExtensions
    {
        public static string RenderToString(this PartialViewResult partialView)
        {
            var httpContext = HttpContext.Current;

            if (httpContext == null)
            {
                throw new NotSupportedException("An HTTP context is required to render the partial view to a string");
            }

            var controllerName = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();

            var controller = (ControllerBase)ControllerBuilder.Current.GetControllerFactory().CreateController(httpContext.Request.RequestContext, controllerName);

            var controllerContext = new ControllerContext(httpContext.Request.RequestContext, controller);

            var view = ViewEngines.Engines.FindPartialView(controllerContext, partialView.ViewName).View;

            var sb = new StringBuilder();

            using (var sw = new StringWriter(sb))
            {
                using (var tw = new HtmlTextWriter(sw))
                {
                    view.Render(new ViewContext(controllerContext, view, partialView.ViewData, partialView.TempData, tw), tw);
                }
            }

            return sb.ToString();
        }
    }
}