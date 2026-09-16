namespace homework.wwwroot.models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public string Location { get; set; }

        // --- Additional property #1 (string) ---
        // Provides the official contact email address of a company.
        public string ContactEmail { get; set; }
    }
}
