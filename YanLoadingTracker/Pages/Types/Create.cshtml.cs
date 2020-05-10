using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
  public class CreateModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public OccupationType OccupationType { get; set; }

    public CreateModel(LoadingTracker context) { this.context = context; }

    public IActionResult OnGet() { return Page(); }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.OccupationTypes.Add(OccupationType);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}