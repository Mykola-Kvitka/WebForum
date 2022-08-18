using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}
