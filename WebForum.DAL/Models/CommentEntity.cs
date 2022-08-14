using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForum.DAL.Models
{
    public class CommentEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PostId { get; set; }

        public Guid UserId { get; set; }

        public string CommentBody { get; set; }

        public DateTime CommentDate { get; set; }

        public Guid CommentParent { get; set; }
    }
}
