using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
{
  public class DetailsModel : PageModel
  {
    private readonly LoadingTracker context;

    public Discipline Discipline { get; set; }

    public DetailsModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Discipline = await context.Disciplines.Include(d => d.IdCourseNavigation).FirstOrDefaultAsync(m => m.Id == id);

      if (Discipline == null) return NotFound();
      return Page();
    }
  }
}