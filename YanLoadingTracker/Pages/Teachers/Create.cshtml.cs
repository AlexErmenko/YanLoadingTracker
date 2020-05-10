using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Teachers
{
  public class CreateModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Teacher Teacher { get; set; }

    public CreateModel(LoadingTracker context) { this.context = context; }

    public IActionResult OnGet()
    {
      ViewData["IdDepartment"] = new SelectList(context.Departments, "Id", "Name");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Teachers.Add(Teacher);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}