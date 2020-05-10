using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
  public class DeleteModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public OccupationType OccupationType { get; set; }

    public DeleteModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      OccupationType = await context.OccupationTypes.FirstOrDefaultAsync(m => m.Id == id);

      if (OccupationType == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      OccupationType = await context.OccupationTypes.FindAsync(id);

      if (OccupationType != null)
      {
        context.OccupationTypes.Remove(OccupationType);
        await context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}