using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CompanyPages;

public class CreateModel : PageModel
{
    private readonly homeworkContext _context;

    public CreateModel(homeworkContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["Industries"] = new SelectList(_context.Industry, "IndustryId", "Name");
        return Page();
    }

    [BindProperty]
    public Company Company { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Company.Add(Company);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}