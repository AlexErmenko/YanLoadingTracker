using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Departments
{
  public class EditModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Department Department { get; set; }

    public EditModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Department = await context.Departments.FirstOrDefaultAsync(m => m.Id == id);

      if (Department == null) return NotFound();
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Attach(Department).State = EntityState.Modified;

      try { await context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!DepartmentExists(Department.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool DepartmentExists(int id) { return context.Departments.Any(e => e.Id == id); }
  }
}