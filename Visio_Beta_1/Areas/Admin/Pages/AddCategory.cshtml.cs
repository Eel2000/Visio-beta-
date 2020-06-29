using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Visio_Beta_1.Data;
using Visio_Beta_1.Data.Models;

namespace Visio_Beta_1.Areas.Admin.Pages
{
    public class AddCategoryModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddCategoryModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSave()
        {
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(Category);
                await _db.SaveChangesAsync();

                return RedirectToPage("Categories", "Admin", "$%Categories%GetAll%&ID");
            }

            return RedirectToPage();
        }
    }
}
