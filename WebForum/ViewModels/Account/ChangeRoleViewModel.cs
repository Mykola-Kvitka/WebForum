using WebForum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels.Account
{
    public class ChangeRoleViewModel
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public List<RoleEntity> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<RoleEntity>();
            UserRoles = new List<string>();
        }

    }
}
