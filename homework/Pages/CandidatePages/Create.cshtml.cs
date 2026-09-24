using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace homework.Pages.CandidatePages;

public class CreateModel : PageModel
{
    private readonly homeworkContext _context;

    public CreateModel(homeworkContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {

        ViewData["JobTitles"] = new SelectList(_context.JobTitle, "JobTitleId", "Title");
        ViewData["Companies"] = new SelectList(_context.Company, "CompanyId", "Name");
        ViewData["Industries"] = new SelectList(_context.Industry, "IndustryId", "Name");
        return Page();
    }

    [BindProperty]
    public Candidate Candidate { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Candidate.Add(Candidate);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
