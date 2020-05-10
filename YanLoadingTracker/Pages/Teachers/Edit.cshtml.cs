using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Teachers
{
  public class EditModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Teacher Teacher { get; set; }

    public EditModel(LoadingTracker context) { this.context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Teacher = await context.Teachers.Include(t => t.IdDepartmentNavigation).FirstOrDefaultAsync(m => m.Id == id);

      if (Teacher == null) return NotFound();
      ViewData["IdDepartment"] = new SelectList(context.Departments, "Id", "Name");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Attach(Teacher).State = EntityState.Modified;

      try { await context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!TeacherExists(Teacher.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool TeacherExists(int id) { return context.Teachers.Any(e => e.Id == id); }
  }
}