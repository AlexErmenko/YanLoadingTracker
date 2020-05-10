using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
{
  public class DeleteModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Discipline Discipline { get; set; }

    public DeleteModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Discipline = await context.Disciplines.Include(d => d.IdCourseNavigation).FirstOrDefaultAsync(m => m.Id == id);

      if (Discipline == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Discipline = await context.Disciplines.FindAsync(id);

      if (Discipline != null)
      {
        context.Disciplines.Remove(Discipline);
        await context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}