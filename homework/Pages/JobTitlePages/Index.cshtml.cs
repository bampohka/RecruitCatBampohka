using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.JobTitlePages;

public class IndexModel : PageModel
{
    private readonly homeworkContext _context;

    public IndexModel(homeworkContext context)
    {
        _context = context;
    }

    public IList<JobTitle> JobTitle { get; set; } = default!;

    public async Task OnGetAsync()
    {
        JobTitle = await _context.JobTitle.ToListAsync();
    }
}
