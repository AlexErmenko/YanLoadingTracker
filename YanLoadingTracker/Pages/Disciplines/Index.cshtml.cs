using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Disciplines
{
  public class IndexModel : PageModel
  {
    private readonly LoadingTracker context;

    public IList<Discipline> Discipline { get; set; }

    public IndexModel(LoadingTracker context) { this.context = context; }

    public async Task OnGetAsync()
    {
      Discipline = await context.Disciplines.Include(d => d.IdCourseNavigation).ToListAsync();
    }
  }
}