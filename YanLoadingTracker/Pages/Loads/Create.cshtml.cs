using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
  public class CreateModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Load Load { get; set; }

    public CreateModel(LoadingTracker context) { this.context = context; }

    public IActionResult OnGet()
    {
      ViewData["IdDiscipline"] = new SelectList(context.Disciplines, "Id", "Name");
      ViewData["IdTeacher"]    = new SelectList(context.Teachers, "Id", "FullName");
      ViewData["IdType"]       = new SelectList(context.OccupationTypes, "Id", "Name");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Loads.Add(Load);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
