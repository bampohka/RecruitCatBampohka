using System.ComponentModel ;
using System.ComponentModel.DataAnnotations;

namespace homework.models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [DisplayName("First Name")]
        [Required]
        [StringLength(75)]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(75)]
        public string? LastName { get; set; }

        [DisplayName("Target Salary")]
        [Range(0, 1000000, ErrorMessage = "Target salary must be between {1} and {2}.")]
        public decimal? TargetSalary { get; set; }

        // --- Additional property #4 (string) ---
        // Indicates the Email address of a job candidate.
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(150)]
        public string? Email { get; set; }
        

        // --- Additional property #5 (string) ---
        // Provides the phone number of a job candidate.

        [DisplayName("Phone Number")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$",
            ErrorMessage = "Phone number must be in the format 123-456-7890.")]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        // --- Additional property #6 (int) ---
        // Provides the number of years of experience for a job candidate.

        [DisplayName("Years Of Experience")]
        [Range(0, 75, ErrorMessage = "Years of experience must be between {1} and {2}.")]
        public int? YearsOfExperince { get; set; }

        // Optional Company relationship
        [DisplayName("Company")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        // Required Job Title relationship
        [DisplayName("Job Title")]
        public int? JobTitleId { get; set; }
        public JobTitle? JobTitle { get; set; }

        // Required Industry relationship
        [DisplayName("Industry")]
        public int? IndustryId { get; set; }
        public Industry? Industry { get; set; }
    }
}
