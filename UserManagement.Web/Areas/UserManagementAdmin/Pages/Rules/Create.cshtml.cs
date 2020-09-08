using CrossCutting.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserManagement.Application.Services.Abstraction;
using UserManagement.Domain.ViewModels;
using UserManagement.Web.Code;
using RulesManagementResources = UserManagement.Localization.RulesManagement.RulesManagement;
using SharedResources = Common.Localization.Shared.Shared;

namespace Christmas_Application.Web.Areas.UserManagementAdmin.Pages.Rules
{
    public class CreateModel : BasePageModel
    {
            public CreateModel(IRuleService ruleService)
            {
                Title = RulesManagementResources.Create_Title;
                RuleService = ruleService;
            }

            #region Dependencies
            public IRuleService RuleService { get; }
            #endregion

            #region Properties
            [BindProperty]
            public RuleViewModel Input { set; get; } = new RuleViewModel();

            #endregion

            #region Get
            public void OnGet()
            {
            }
            #endregion

            #region Post
            public async Task<IActionResult> OnPostSubmit()
            {
                if (!ModelState.IsValid)
                    return Page();

                var result = await RuleService.Add(new ReturnResult<RuleViewModel>() { Value = Input });
                ModelState.Merge(result);

                if (!ModelState.IsValid)
                    return Page();

                ShowMessage(CoreEnumerations.MessageTypes.info, SharedResources.CreateSuccess);

                return RedirectToPage("/Rules/Index", new { area = "UserManagementAdmin" });
            }

            public IActionResult OnPostCancel()
            {
                return RedirectToPage("/Rules/Index", new { area = "UserManagementAdmin" });
            }
            #endregion
        }
    
}
