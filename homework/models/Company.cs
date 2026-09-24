using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace homework.models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(150, MinimumLength = 2)]
        public string? Name { get; set; }

        [DisplayName("Position Name")]
        [StringLength(100)]
        public string? PositionName { get; set; }

        [DisplayName("Minimum Salary")]
        [Range(0, 1000000, ErrorMessage = "Minimum salary must be between {1} and {2}.")]
        public decimal? MinimumSalary { get; set; }

        [DisplayName("Maximum Salary")]
        [Range(0, 1000000, ErrorMessage = "Minimum salary must be between {1} and {2}.")]
        public decimal? MaximumSalary { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [StringLength(250)]
        public string? Location { get; set; }

        // --- Additional property #1 (string) ---
        // Provides the official contact email address of a company.

        [DisplayName("Contact Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150)]
        public string? ContactEmail { get; set; }

        // Industry relationship (required)
        [DisplayName("Industry No.")]
        public int? IndustryId { get; set; }
        public Industry? Industry { get; set; }

        // One Company -> Many Candidates
        public List<Candidate> Candidates { get; set; } 

    }
}
