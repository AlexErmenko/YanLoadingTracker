using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
  public class DetailsModel : PageModel
  {
    private readonly LoadingTracker context;

    public OccupationType OccupationType { get; set; }

    public DetailsModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      OccupationType = await context.OccupationTypes.FirstOrDefaultAsync(m => m.Id == id);

      if (OccupationType == null) return NotFound();
      return Page();
    }
  }
}