using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CompanyPages;

public class EditModel : PageModel
{
    private readonly homeworkContext _context;

    public EditModel(homeworkContext context)
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

        var company = await _context.Company.FirstOrDefaultAsync(m => m.CompanyId == id);
        if (company is null)
        {
            return NotFound();
        }
        Company = company;

        ViewData["Industries"] = new SelectList(_context.Industry, "IndustryId", "Name", company.IndustryId);

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Company).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompanyExists(Company.CompanyId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CompanyExists(int id)
    {
        return _context.Company.Any(e => e.CompanyId == id);
    }
}