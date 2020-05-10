using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
{
  public class CreateModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Discipline Discipline { get; set; }

    public CreateModel(LoadingTracker context) { this.context = context; }

    public IActionResult OnGet()
    {
      ViewData["IdCourse"] = new SelectList(context.Courses, "Id", "CourceNumber");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Disciplines.Add(Discipline);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}