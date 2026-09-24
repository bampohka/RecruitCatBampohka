using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework.models;

namespace homework.Pages.IndustryPages;

public class DetailsModel : PageModel
{
    private readonly homeworkContext _context;
    public DetailsModel(homeworkContext context)
    {
        _context = context;
    }

    public Industry Industry { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? industryid)
    {
        if (industryid is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FirstOrDefaultAsync(m => m.IndustryId == industryid);
        if (industry is null)
        {
            return NotFound();
        }
        else
        {
            Industry = industry;
        }

        return Page();
    }
}
