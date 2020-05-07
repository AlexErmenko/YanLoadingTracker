using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public DetailsModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FirstOrDefaultAsync(m => m.Id == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
