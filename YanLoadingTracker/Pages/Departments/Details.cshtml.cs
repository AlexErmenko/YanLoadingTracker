using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Departments
{
  public class DetailsModel : PageModel
  {
    private readonly LoadingTracker context;

    public Department Department { get; set; }

    public DetailsModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Department = await context.Departments.FirstOrDefaultAsync(m => m.Id == id);

      if (Department == null) return NotFound();
      return Page();
    }
  }
}