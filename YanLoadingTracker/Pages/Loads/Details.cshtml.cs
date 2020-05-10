using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
  public class DetailsModel : PageModel
  {
    private readonly LoadingTracker context;

    public Load Load { get; set; }

    public DetailsModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Load = await context.Loads.Include(l => l.IdDisciplineNavigation)
                          .Include(l => l.IdTeacherNavigation)
                          .Include(l => l.IdTypeNavigation)
                          .FirstOrDefaultAsync(m => m.IdTeacher == id);

      if (Load == null) return NotFound();
      return Page();
    }
  }
}