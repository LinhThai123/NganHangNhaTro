using System.ComponentModel.DataAnnotations;
using System;

namespace NganHangNhaTro.Models.ViewModels
{
    public class VM_RealEstate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime PostTime { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime? ExprireTime { get; set; }
        public int RealEstateTypeId { get; set; }
        public string Price { get; set; }
        public string AgentName { get; set; }
        public int AgentId { get; set; }
        public int? ViewCount { get; set; }
        public bool IsActive { get; set; }

    }
}
