using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
    public class DetailsModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public DetailsModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        public Load Load { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Load = await _context.Loads
                .Include(l => l.IdDisciplineNavigation)
                .Include(l => l.IdTeacherNavigation)
                .Include(l => l.IdTypeNavigation).FirstOrDefaultAsync(m => m.IdTeacher == id);

            if (Load == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
