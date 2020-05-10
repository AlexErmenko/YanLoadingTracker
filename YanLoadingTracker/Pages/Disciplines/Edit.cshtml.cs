using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
{
  public class EditModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Discipline Discipline { get; set; }

    public EditModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Discipline = await context.Disciplines.Include(d => d.IdCourseNavigation).FirstOrDefaultAsync(m => m.Id == id);

      if (Discipline == null) return NotFound();
      ViewData["IdCourse"] = new SelectList(context.Courses, "Id", "CourceNumber");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Attach(Discipline).State = EntityState.Modified;

      try { await context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!DisciplineExists(Discipline.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool DisciplineExists(int id) { return context.Disciplines.Any(e => e.Id == id); }
  }
}