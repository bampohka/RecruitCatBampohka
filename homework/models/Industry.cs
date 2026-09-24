using System.Collections.Generic;

namespace homework.models
{
    public class Industry
    {
        public int IndustryId { get; set; }
        public string? Name { get; set; }

        // One Industry -> Many Candidates
        public List<Candidate> Candidates { get; set; } 

        // One Industry -> Many Companies
        public List<Company> Companies { get; set; } 

    }
}
