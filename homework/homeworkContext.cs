using Microsoft.EntityFrameworkCore;

public class homeworkContext(DbContextOptions<homeworkContext> options) : DbContext(options)
{
    public DbSet<homework.models.JobTitle> JobTitle { get; set; } = default!;
    public DbSet<homework.models.Candidate> Candidate { get; set; } = default!;
    public DbSet<homework.models.Company> Company { get; set; } = default!;
    public DbSet<homework.models.Industry> Industry { get; set; } = default!;
}
