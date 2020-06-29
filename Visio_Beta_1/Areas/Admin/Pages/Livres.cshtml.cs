using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Visio_Beta_1.Data;
using Visio_Beta_1.Data.Models;

namespace Visio_Beta_1.Areas.Admin.Pages
{
    public class LivresModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LivresModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public IEnumerable<Book> GetBooks { get; set; }

        public async Task OnGet()
        {
            GetBooks = await _db.Books.ToListAsync();
        }
    }
}
