using CrossCutting.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Application.Services.Abstraction;
using UserManagement.Domain.ViewModels;
using UserManagement.Web.Code;
using UsersManagementResources = UserManagement.Localization.UsersManagement.UsersManagement;
using UsersResources = UserManagement.Localization.Users.UsersResources;

namespace UserManagement.Web.Areas.UserManagementAdmin.Pages.Users
{
    public class CreateModel : BasePageModel
    {
        public CreateModel(IUsersService usersService, IRolesService rolesService)
        {
            Title = UsersManagementResources.Create_Title;

            UsersService = usersService;
            RolesService = rolesService;
        }


        #region Dependencies
        public IUsersService UsersService { get; }
        public IRolesService RolesService { get; }
        #endregion

        #region Binding Properties
        [BindProperty]
        public UserViewModel Input { set; get; } = new UserViewModel();

        public List<RoleViewModel> RolesList = new List<RoleViewModel>();
        #endregion

        #region Get
        public void OnGet()
        {
            RolesList = RolesService.GetAll();
        }
        #endregion

        #region Post
        public async Task<IActionResult> OnPostSubmit()
        {
            if (!ModelState.IsValid)
                return Page();

            var result = await UsersService.Add(new ReturnResult<UserViewModel>() { Value = Input });
            ModelState.Merge(result);

            if (!ModelState.IsValid)
                return Page();

            ShowMessage(CoreEnumerations.MessageTypes.info, UsersResources.UserCreatedSuccessfully);

            return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });
        }
        #endregion
    }
}
