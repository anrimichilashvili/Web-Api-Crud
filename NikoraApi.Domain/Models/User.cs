using NikoraApi.Domain.Enums;
using NikoraApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikoraApi.Domain.Models
{
    public class User : IIdentity
    {
        [Key]
        [Column("Id")]
        [DisplayName("User Id")]
        public int Id { get; set; }

        [Column("UserName")]
        [DisplayName("User Name")]
        [Required(ErrorMessage ="UserName is required")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Username must be between 5 and 50 characters")]
        public string UserName { get; set; }

        [Column("Password")]
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(256, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        public string Password { get; set; }

        [Column("DateTime")]
        [DisplayName("DateTime")]
        [Required(ErrorMessage = "DateTime is required")]
        public DateTime DateTime { get; set; }

        [Column("Status")]
        [DisplayName("User Status")]
        public UserStatusEnum Status { get; set; }
    }
}
