using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Visio_Beta_1.Data;
using Visio_Beta_1.Data.Models;

namespace Visio_Beta_1.Areas.Admin.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CategoriesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<Category> GetCategories { get; set; }

        public async Task OnGet()
        {
            GetCategories = await _db.Categories.ToListAsync();
        }

        public IActionResult OnGetCategories()
        {
            return RedirectToPage("Categories", "Admin", "$%Goto$%page&Admin=#$5%Add%new%categori%");
        }
    }
}
