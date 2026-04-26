using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Martsinovsky1.Models;

namespace Martsinovsky1.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("canEdit"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "canEdit" });
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "canEditUser@wingtiptoys.com",
                Email = "canEditUser@wingtiptoys.com"
            };

            IdUserResult = userMgr.Create(
                appUser,
                ConfigurationManager.AppSettings["AppUserPasswordKey"]
            );

            var user = userMgr.FindByEmail("canEditUser@wingtiptoys.com");
            if (user != null && !userMgr.IsInRole(user.Id, "canEdit"))
            {
                IdUserResult = userMgr.AddToRole(user.Id, "canEdit");
            }
        }
    }
}