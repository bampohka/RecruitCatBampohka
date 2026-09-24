using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CandidatePages;

public class IndexModel : PageModel
{
    private readonly homeworkContext _context;

    public IndexModel(homeworkContext context)
    {
        _context = context;
    }

    public IList<Candidate> Candidate { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Candidate = await _context.Candidate
            .Include(c => c.Company)
            .Include(c => c.JobTitle)
            .Include(c => c.Industry)
            .ToListAsync();
    }
}