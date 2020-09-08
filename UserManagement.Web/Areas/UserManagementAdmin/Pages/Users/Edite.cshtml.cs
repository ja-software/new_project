using CrossCutting.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Application.Services.Abstraction;
using UserManagement.Domain.ViewModels;
using UserManagement.Web.Code;
using UsersManagementResources = UserManagement.Localization.UsersManagement.UsersManagement;
using UsersResources = UserManagement.Localization.Users.UsersResources;

namespace UserManagement.Web.Areas.UserManagementAdmin.Pages.Users
{
    public class EditeModel : BasePageModel
    {
        public EditeModel(IUsersService usersService, IRolesService rolesService)
        {
            Title = UsersManagementResources.Edite_Title;

            UsersService = usersService;
            RolesService = rolesService;
        }

        #region Dependencies
        public IUsersService UsersService { get; }
        public IRolesService RolesService { get; }
        #endregion

        #region Bind Properties
        [BindProperty]
        public UserViewModel Input { set; get; } = new UserViewModel();

        public List<RoleViewModel> RolesList = new List<RoleViewModel>();


        #endregion

        #region Get
        public async Task<IActionResult> OnGet(string userId)
        {

            var result = await UsersService.GetById(userId);
            ModelState.Merge(result);

            if (!ModelState.IsValid)
            {
                ShowMessage(CoreEnumerations.MessageTypes.danger, ModelState.GetErrors(" , "));
                return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });
            }
            Input = result.Value;

            RolesList = RolesService.GetAll();

            return Page();
        }
        #endregion

        #region Post
        public async Task<IActionResult> OnPostSubmit()
        {
            ModelState.Remove("Input.Password");
            ModelState.Remove("Input.ConfirmPassword");

            if (!ModelState.IsValid)
                return Page();

            var result = await UsersService.Update(new ReturnResult<UserViewModel>() { Value = Input });
            ModelState.Merge(result);

            if (!ModelState.IsValid)
                return Page();

            ShowMessage(CoreEnumerations.MessageTypes.info, UsersResources.UpdateUserSuccessfully);

            return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });
        }

        public async Task<IActionResult> OnPostRemove(Guid id)
        {
            ModelState.Remove("Input.Password");
            ModelState.Remove("Input.ConfirmPassword");

            var result = await UsersService.Delete(new ReturnResult<Guid> { Value = id });
            ModelState.Merge(result);

            if (!ModelState.IsValid)
                return Page();

            ShowMessage(CoreEnumerations.MessageTypes.info, UsersResources.DeleteUserSuccess);
            return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });

        }
        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Users/Index", new { area = "UserManagementAdmin" });
        }
        #endregion
    }
}
