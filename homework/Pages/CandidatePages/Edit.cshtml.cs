using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CandidatePages;

public class EditModel : PageModel
{
    private readonly homeworkContext _context;

    public EditModel(homeworkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Candidate Candidate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var candidate = await _context.Candidate.FirstOrDefaultAsync(m => m.CandidateId == id);
        if (candidate is null)
        {
            return NotFound();
        }
        Candidate = candidate;

        ViewData["JobTitles"] = new SelectList(_context.JobTitle, "JobTitleId", "Title", candidate.JobTitleId);
        ViewData["Companies"] = new SelectList(_context.Company, "CompanyId", "Name", candidate.CompanyId);
        ViewData["Industries"] = new SelectList(_context.Industry, "IndustryId", "Name", candidate.IndustryId);

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

        _context.Attach(Candidate).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CandidateExists(Candidate.CandidateId))
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

    private bool CandidateExists(int id)
    {
        return _context.Candidate.Any(e => e.CandidateId == id);
    }
}