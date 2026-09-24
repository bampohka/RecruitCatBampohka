using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.IndustryPages;

public class IndexModel : PageModel
{
    private readonly homeworkContext _context;

    public IndexModel(homeworkContext context)
    {
        _context = context;
    }

    public IList<Industry> Industry { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Industry = await _context.Industry.ToListAsync();
    }
}
