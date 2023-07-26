using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models.DataModels
{
    public partial class RealEstate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime PostTime { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? ExprireTime { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfirm { get; set; }
        public int ConfirmStatus { get; set; }
        public bool IsAvaiable { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public int Acreage { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public bool HasPrivateWc { get; set; }
        public bool HasMezzanine { get; set; }
        public bool AllowCook { get; set; }
        public bool FreeTime { get; set; }
        public bool SecurityCamera { get; set; }
        public int? WaterPrice { get; set; }
        public int? ElectronicPrice { get; set; }
        public decimal? WifiPrice { get; set; }
        public int? ViewCount { get; set; }
        public string? imageUrl { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public Agent Agent { get; set; }
        public int RealEstateTypeId { get; set; }
        [ForeignKey("RealEstateTypeId")]
        [ValidateNever]
        public RealEstateType RealEstateType { get; set; }

    }
}
