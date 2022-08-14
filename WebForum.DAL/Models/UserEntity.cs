using Microsoft.AspNetCore.Identity;
using System;

namespace WebForum.DAL.Models
{
    public class UserEntity : IdentityUser<Guid>
    {
    }
}
