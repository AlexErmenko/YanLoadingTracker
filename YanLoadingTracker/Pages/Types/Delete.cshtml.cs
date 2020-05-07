using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
    public class DeleteModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public DeleteModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        [BindProperty]
        public OccupationType OccupationType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationType = await _context.OccupationTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (OccupationType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OccupationType = await _context.OccupationTypes.FindAsync(id);

            if (OccupationType != null)
            {
                _context.OccupationTypes.Remove(OccupationType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
