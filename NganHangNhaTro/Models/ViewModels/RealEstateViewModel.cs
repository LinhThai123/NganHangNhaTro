namespace NganHangNhaTro.Models.ViewModels
{
    public class RealEstateViewModel
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string PostDate { get; set; }
        public string BeginTime { get; set; }
        public string ExpireTime { get; set; }
        public string Agent { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
