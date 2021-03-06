﻿using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using YanLoadingTracker.Models;

namespace YanLoadingTracker.Pages.Cources
{
  public class CreateModel : PageModel
  {
    private readonly LoadingTracker context;

    [BindProperty]
    public Course Course { get; set; }

    public CreateModel(LoadingTracker context) { this.context = context; }

    public IActionResult OnGet() { return Page(); }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      context.Courses.Add(Course);
      await context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}