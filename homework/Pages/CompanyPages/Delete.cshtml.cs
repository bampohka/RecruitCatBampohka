using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CompanyPages;

public class DeleteModel : PageModel
{
    private readonly homeworkContext _context;

    public DeleteModel(homeworkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Company Company { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var company = await _context.Company
            .Include(c => c.Industry)
            .FirstOrDefaultAsync(m => m.CompanyId == id);
        if (company is null)
        {
            return NotFound();
        }
        else
        {
            Company = company;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var company = await _context.Company.FindAsync(id);
        if (company != null)
        {
            Company = company;
            _context.Company.Remove(Company);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}