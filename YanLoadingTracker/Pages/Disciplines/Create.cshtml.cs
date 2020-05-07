using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
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
        ViewData["IdCourse"] = new SelectList(_context.Courses, "Id", "CourceNumber");
            return Page();
        }

        [BindProperty]
        public Discipline Discipline { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Disciplines.Add(Discipline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
