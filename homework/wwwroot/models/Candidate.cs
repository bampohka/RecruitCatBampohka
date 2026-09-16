namespace homework.wwwroot.models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TargetSalary { get; set; }

        // --- Additional property #4 (string) ---
        // Indicates the Email address of a job candidate.
        public string Email { get; set; }

        // --- Additional property #5 (string) ---
        // Provides the phone number of a job candidate.
        public string PhoneNumber { get; set; }

        // --- Additional property #6 (int) ---
        // Provides the number of years of experience for a job candidate.
        public int? YearsOfExperince { get; set; }
    }
}
