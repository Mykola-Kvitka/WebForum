using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels.Admin
{
    public class AdminPostViewModel : PagedViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
