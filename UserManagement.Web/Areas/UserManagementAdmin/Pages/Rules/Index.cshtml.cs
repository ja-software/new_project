using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Models;
using UserManagement.Persistance;
using UserManagement.Web.Code;

namespace Christmas_Application.Web.Areas.UserManagementAdmin.Pages.Rules
{
    public class IndexModel : BasePageModel
    {
        public IEnumerable<Rule> Rules { get; set; }
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Rules = await _db.rules.ToListAsync();
        }

    }
}
