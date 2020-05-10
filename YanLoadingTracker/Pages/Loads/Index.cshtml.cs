using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
  public class IndexModel : PageModel
  {
    private readonly LoadingTracker context;

    public IList<Load> Load { get; set; }

    public IndexModel(LoadingTracker context) { this.context = context; }

    public async Task OnGetAsync()
    {
      Load = await context.Loads.Include(l => l.IdDisciplineNavigation)
                          .Include(l => l.IdTeacherNavigation)
                          .Include(l => l.IdTypeNavigation)
                          .ToListAsync();
    }

    
  }
}
