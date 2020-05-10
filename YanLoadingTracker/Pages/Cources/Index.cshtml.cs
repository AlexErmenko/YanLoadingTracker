using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Cources
{
  public class IndexModel : PageModel
  {
    private readonly LoadingTracker context;

    public IList<Course> Course { get; set; }

    public IndexModel(LoadingTracker context) { this.context = context; }

    public async Task OnGetAsync() { Course = await context.Courses.ToListAsync(); }
  }
}