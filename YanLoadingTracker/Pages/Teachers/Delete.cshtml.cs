using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Teachers
{
  public class DeleteModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Teacher Teacher { get; set; }

    public DeleteModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Teacher = await context.Teachers.Include(t => t.IdDepartmentNavigation).FirstOrDefaultAsync(m => m.Id == id);

      if (Teacher == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Teacher = await context.Teachers.FindAsync(id);

      if (Teacher != null)
      {
        context.Teachers.Remove(Teacher);
        await context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}