using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models.DataModels
{
    public partial class Agent
    {
        public int Id { get; set; }
        public string AgentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ActiveKey { get; set; }
        public string ResetPasswordKey { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
        public int LevelId { get; set; }
        public bool ConfirmPhoneNumber { get; set; }

        [ForeignKey("LevelId")]
        [ValidateNever]
        public Level Level { get; set; }


    }
}
