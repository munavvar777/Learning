using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Core.ViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator Code")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Remember this machine?")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
