using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Cources
{
  public class DeleteModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Course Course { get; set; }

    public DeleteModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Course = await context.Courses.FirstOrDefaultAsync(m => m.Id == id);

      if (Course == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Course = await context.Courses.FindAsync(id);

      if (Course != null)
      {
        context.Courses.Remove(Course);
        await context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}