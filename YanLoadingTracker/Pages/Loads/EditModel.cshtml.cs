using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
  [BindProperties]
  public class EditModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty(SupportsGet = true)]
    public Load Load { get; set; }


    [BindProperty]
    public int IdDisc { get; set; }

    [BindProperty]
    public int IdType { get; set; }

    public EditModel(LoadingTracker context) { this.context = context; }


    public async Task<IActionResult> OnGetAsync(int id, int type, int d)
    {
      Load = await context.Loads.Include(l => l.IdDisciplineNavigation)
                           .Include(l => l.IdTeacherNavigation)
                           .Include(l => l.IdTypeNavigation)
                           .FirstOrDefaultAsync(m => m.IdTeacher == id);

      IdDisc = d;
      IdType = type;

      if (Load == null) return NotFound();


      ViewData["IdDiscipline"] = new SelectList(context.Disciplines, "Id", "Name");
      ViewData["IdTeacher"]    = new SelectList(context.Teachers, "Id", "FirstName");
      ViewData["IdType"]       = new SelectList(context.OccupationTypes, "Id", "Name");


      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();


      Load load = await context.Loads.Include(l => l.IdDisciplineNavigation)
                                .Include(l => l.IdTeacherNavigation)
                                .Include(l => l.IdTypeNavigation)
                                .FirstOrDefaultAsync(m => m.IdTeacher    == Load.IdTeacher && m.IdType == IdType &&
                                                          m.IdDiscipline == IdDisc) ;
      context.Loads.Remove(load);
      await context.SaveChangesAsync();


      context.Add(new Load { IdType = Load.IdType, IdTeacher = Load.IdTeacher, IdDiscipline = Load.IdDiscipline });


      //_context.Attach(Load).State = EntityState.Modified;

      try { await context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!LoadExists(Load.IdTeacher))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool LoadExists(int id) { return context.Loads.Any(e => e.IdTeacher == id); }
  }
}