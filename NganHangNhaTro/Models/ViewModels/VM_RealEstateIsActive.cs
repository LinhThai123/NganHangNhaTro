using System.ComponentModel.DataAnnotations;
using System;

namespace NganHangNhaTro.Models.ViewModels
{
    public class VM_RealEstateIsActive
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AgentName { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime PostTime { get; set; }
        public int Acreage { get; set; }
        public string RealEstateTypeName { get; set; }
        public string ContactNumber { get; set; }
        public int? ViewCount { get; set; }
        public bool IsActive { get; set; }
        public int ConfirmStatus { get; set; }
        public string ImageUrl { get; set; }
    }
}
