using ClaudiaProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaudiaProject.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ClaudiaProject.Data.ApplicationDbContext _context;

        public IndexModel(ClaudiaProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}