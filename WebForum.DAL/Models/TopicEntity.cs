using System;
using System.ComponentModel.DataAnnotations;

namespace WebForum.DAL.Models
{
    public class TopicEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(64)]
        public string TopicName { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string ImagePath { get; set; }
    }
}
