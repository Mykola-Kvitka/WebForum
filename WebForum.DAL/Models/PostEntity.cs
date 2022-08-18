using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.DAL.Models
{
    public class PostEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TopicId { get; set; }

        public DateTime PostDate { get; set; }


        [MaxLength(64)]
        public string Article { get; set; }

        public string Text { get; set; }

        public string ImagePath { get; set; }

    }
}
