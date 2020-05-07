using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
    public class EditModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public EditModel(YanLoadingTracker.Models.LoadingTracker context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OccupationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationTypeExists(OccupationType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OccupationTypeExists(int id)
        {
            return _context.OccupationTypes.Any(e => e.Id == id);
        }
    }
}
