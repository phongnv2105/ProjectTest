using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_Test.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [StringLength(30,MinimumLength =2)]
        public string FirstName { get; set; }
        [StringLength(10, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^(([\w])+(@)+([\w])+(.)+([a-zA-Z]{2,4}))$", ErrorMessage = "Email invalidate!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        [RegularExpression(@"^(([07]||[08]||[09]||[03]||[05])+([\d]{10}))$", ErrorMessage = "Phone Number invalidate!")]
        public string Phone { get; set; }
        
        public DateTime? Birthday { get; set; }

        public string Avatar { get; set; }
    }
}