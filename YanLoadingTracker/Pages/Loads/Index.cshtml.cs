using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Loads
{
    public class IndexModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public IndexModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        public IList<Load> Load { get;set; }

        public async Task OnGetAsync()
        {
            Load = await _context.Loads
                .Include(l => l.IdDisciplineNavigation)
                .Include(l => l.IdTeacherNavigation)
                .Include(l => l.IdTypeNavigation).ToListAsync();
        }
    }
}
