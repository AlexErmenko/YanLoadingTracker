using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
    public class CreateModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public CreateModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdDiscipline"] = new SelectList(_context.Disciplines, "Id", "Name");
        ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "FirstName");
        ViewData["IdType"] = new SelectList(_context.OccupationTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Load Load { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Loads.Add(Load);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
