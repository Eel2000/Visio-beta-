using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Visio_Beta_1.Data;
using Visio_Beta_1.Data.Models;

namespace Visio_Beta_1.Areas.Admin.Pages.Shared
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public BookViewModel BookViewModel { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public List<SelectListItem> Categories { get; set; }

        public async Task OnGet()
        {
            Categories =  _db.Categories.Select(Cat =>
                new SelectListItem { Value = Cat.Id.ToString(), Text = Cat.Designation }
            ).ToList();
        }


    }

    public class BookViewModel
    {
        [Required]
        public IFormFile Fichier { get; set; }
    }
}
