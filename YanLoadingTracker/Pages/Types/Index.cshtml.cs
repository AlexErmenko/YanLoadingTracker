using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Types
{
    public class IndexModel : PageModel
    {
        private readonly YanLoadingTracker.Models.LoadingTracker _context;

        public IndexModel(YanLoadingTracker.Models.LoadingTracker context)
        {
            _context = context;
        }

        public IList<OccupationType> OccupationType { get;set; }

        public async Task OnGetAsync()
        {
            OccupationType = await _context.OccupationTypes.ToListAsync();
        }
    }
}
