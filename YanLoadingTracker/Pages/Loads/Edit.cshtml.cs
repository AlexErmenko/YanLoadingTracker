using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
    public class EditModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public EditModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdDiscipline"] = new SelectList(_context.Disciplines, "Id", "Name");
           ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "FirstName");
           ViewData["IdType"] = new SelectList(_context.OccupationTypes, "Id", "Name");
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

            _context.Attach(Load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(Load.IdTeacher))
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

        private bool LoadExists(int id)
        {
            return _context.Loads.Any(e => e.IdTeacher == id);
        }
    }
}
