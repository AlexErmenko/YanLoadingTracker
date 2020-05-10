using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Cources
{
  public class DetailsModel : PageModel
  {
    private readonly LoadingTracker context;

    public Course Course { get; set; }

    public DetailsModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Course = await context.Courses.FirstOrDefaultAsync(m => m.Id == id);

      if (Course == null) return NotFound();
      return Page();
    }
  }
}