using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UserManagement.Application.Authorization.Models;

namespace UserManagement.Application.Authorization
{
    public static class ChechUserAuthorization
    {
        public static List<SitePage> SitePages { set; get; }

        static ChechUserAuthorization()
        {
            LoadSitePagesFromJson();
        }

        public static void LoadSitePagesFromJson()
        {
            var configData = AuthorizationConfig.ReadAuthorizationConfig();
            SitePages = configData.SitePages.ToList();
        }
        public static bool CanUserAccessPage(this IAuthorizationService authorizationService, ClaimsPrincipal user, string page, string area)
        {
            var sitePage = SitePages.FirstOrDefault(a => a.Path == page && a.AreaName == area);

            if (sitePage.PolicyName == AuthorizationConfig.AnonymousPolicy)
                return true;

            return authorizationService.AuthorizeAsync(user: user, policyName: sitePage.PolicyName).GetAwaiter().GetResult().Succeeded;
        }

      
    }
}
