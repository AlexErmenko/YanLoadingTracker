using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Teachers
{
  public class IndexModel : PageModel
  {
    private readonly LoadingTracker context;

    public IList<Teacher> Teacher { get; set; }

    public IndexModel(LoadingTracker context) { this.context = context; }

    public async Task OnGetAsync()
    {
      Teacher = await context.Teachers.Include(t => t.IdDepartmentNavigation).ToListAsync();
    }
  }
}