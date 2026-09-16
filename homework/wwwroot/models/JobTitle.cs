namespace homework.wwwroot.models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Title { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }

        // --- Additional property #2 (string) ---
        // Provides a brief description of the job title, outlining its responsibilities and requirements.
        public string JobDescription { get; set; }

        // --- Additional property #3 (bool) ---
        // Indicates whether this role is typically offered as remote friendly.
        public bool RemoteAvailability { get; set; }

    }
}
