using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Interface.Repository;
using DAL.Repository;
using DAL;
using ORM;
using Ninject;
using Ninject.Web.Common;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<Model1>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<Model1>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<ISkillCategoryService>().To<SkillCategoryService>();
            kernel.Bind<ISkillCategoryRepository>().To<SkillCategoryRepository>();

            kernel.Bind<ISkillService>().To<SkillService>();
            kernel.Bind<ISkillRepository>().To<SkillRepository>();

            kernel.Bind<IUserSkillService>().To<UserSkillService>();
            kernel.Bind<IUserSkillRepository>().To<UserSkillRepository>();
        }
    }
}
