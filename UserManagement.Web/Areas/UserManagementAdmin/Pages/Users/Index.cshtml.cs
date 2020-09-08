using CrossCutting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagement.Application.Services.Abstraction;
using UserManagement.Domain.ViewModels;
using UserManagement.Web.Code;
using UsersManagementResources = UserManagement.Localization.UsersManagement.UsersManagement;

namespace UserManagement.Web.Areas.UserManagementAdmin.Pages.Users
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IUsersService usersService)
        {
            Title = UsersManagementResources.Index_Title;

            UsersService = usersService;
        }
        #region Dependencies
        public IUsersService UsersService { get; }
        #endregion

        #region Get
        public void OnGet()
        {
        }
        #endregion

        #region Post
        public async Task<JsonResult> OnPostSearch(UserFilterViewModel model)
        {
            try
            {
                model = await UsersService.Search(model);
                return new JsonResult(new { Result = CommonConstants.JTableConstants.OK, Records = model.Items, TotalRecordCount = model.TotalCount });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Result = CommonConstants.JTableConstants.ERROR, ex.Message });
            }
        }


        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Index", new { area = "UserManagementAdmin" });
        }
        #endregion
    }
}
