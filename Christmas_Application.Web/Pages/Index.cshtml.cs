using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using UserManagement.Application.Services.Abstraction;

namespace UserManagement.Web.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IWebHostEnvironment webHostEnvironment, IUsersService usersService)
        {
            WebHostEnvironment = webHostEnvironment;
            UsersService = usersService;
        }

        #region Dependencies
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IUsersService UsersService { get; }
        #endregion

        #region Get
        public IActionResult OnGet()
        {
            return RedirectToPage("/Index", new { area = "UserManagementAdmin" });
        }

        public async Task<FileResult> OnGetLoadUserImage(string userName = "")
        {
            try
            {
                var bytes = await UsersService.LoadUserImage(WebHostEnvironment.WebRootPath, userName);
                return File(bytes, "image/jpeg");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
