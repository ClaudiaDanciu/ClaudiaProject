using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClaudiaProject.Data;
using ClaudiaProject.Models;

namespace ClaudiaProject.Pages.Instructors
{
    public class CreateModel : PageModel
    {
        private readonly ClaudiaProject.Data.ApplicationDbContext _context;

        public CreateModel(ClaudiaProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Instructor = new Instructor
            {
                FirstMidName = "Bill",
                LastName = "Gates",
                HireDate = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instructors.Add(Instructor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}