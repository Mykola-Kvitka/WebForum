using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        [StringLength(100)]
        public string AuthorOfParent { get; set; }

        public string UserName { get; set; }

        public string CommentBody { get; set; }

        public DateTime CommentDate { get; set; }

        public Guid CommentParent { get; set; }

        public IEnumerable<CommentViewModel> CommentsChildren { get; set; }

    }
}
