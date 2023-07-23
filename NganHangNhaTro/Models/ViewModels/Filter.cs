using System.Collections.Generic;

namespace NganHangNhaTro.Models.ViewModels
{
    public class Filter
    {
        public Condition Condition { get; set; }

        public List<Result> Results { get; set; }
    }

    public class Condition
    {

        public string SearchString { get; set; }

        public int PriceRange { get; set; }

        public int AcreageRange { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int Acreage { get; set; }
        public string Type { get; set; }
        public string PostTime { get; set; }
        public string ImageUrl { get; set; }
        public string AgentName { get; set; }

        public string ContactNumber { get; set; }
    }
}
