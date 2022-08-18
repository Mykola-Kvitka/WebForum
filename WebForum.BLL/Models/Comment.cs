using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.BLL.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } 

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string CommentBody { get; set; }

        public DateTime CommentDate { get; set; }

        public Guid CommentParent { get; set; }

        public IEnumerable<Comment> CommentsChildren { get; set; }

    }
}
