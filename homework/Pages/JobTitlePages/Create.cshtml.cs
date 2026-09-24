using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.JobTitlePages;

public class CreateModel : PageModel
{
    private readonly homeworkContext _context;

    public CreateModel(homeworkContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public JobTitle JobTitle { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.JobTitle.Add(JobTitle);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
