using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        //[BindProperty]
        //public Book Book { get; set; }

        [BindProperty]
        public IEnumerable<Category> Categories { get; set; }

        public async Task OnGet()
        {
            Categories = await _db.Categories.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                using (var MStream = new MemoryStream())
                {
                    await BookViewModel.Fichier.CopyToAsync(MStream);

                    if(MStream.Length < 4194304)
                    {
                        var NewBook = new Book
                        {
                            Title = BookViewModel.Title,
                            Author = BookViewModel.Author,
                            Pages = BookViewModel.Pages,
                            Year = BookViewModel.Year,
                           // BookCategory = _db.Categories.Find(Categories.FirstOrDefault()),
                            Content = MStream.ToArray()
                        };

                        await _db.Books.AddAsync(NewBook);
                        await _db.SaveChangesAsync();

                        return RedirectToPage("Livres", "Admin", "$%GetALl$%^Books*&^Fr&Db@");
                    }
                }
            }

            return RedirectToPage();
        }


    }

    public class BookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Pages { get; set; }

        [Required]
        public string Year { get; set; }


        [Display(Name = "Categories")]
        public Category BookCategory { get; set; } = null;

        [Required]
        public IFormFile Fichier { get; set; }
    }
}
