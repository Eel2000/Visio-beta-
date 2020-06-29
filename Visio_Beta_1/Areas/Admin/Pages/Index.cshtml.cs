using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Visio_Beta_1.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnGetLivres()
        {
            return RedirectToPage("Livres", "Admin", "?Index%Des%livres");
        }
        
        public async Task<IActionResult> OnGetCategories()
        {
            return RedirectToPage("Categories", "Admin", "?Index%Des%Categories%All");
        }
    }
}
