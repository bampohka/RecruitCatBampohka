using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.CompanyPages;

public class IndexModel : PageModel
{
    private readonly homeworkContext _context;

    public IndexModel(homeworkContext context)
    {
        _context = context;
    }

    public IList<Company> Company { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Company = await _context.Company.Include(c => c.Industry).ToListAsync();
    }
}