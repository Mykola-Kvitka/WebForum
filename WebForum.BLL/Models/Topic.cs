using Microsoft.AspNetCore.Http;
using System;

namespace WebForum.BLL.Models
{
    public class Topic
    {
        public Guid Id { get; set; }

        public string TopicName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

    }
}
