using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class PostDetailViewModel
    {
        public PostViewModel Posts { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }

    }
}
