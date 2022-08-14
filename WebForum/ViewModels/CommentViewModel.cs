using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string CommentBody { get; set; }

        public DateTime CommentDate { get; set; }

        public Guid CommentParent { get; set; }

    }
}
