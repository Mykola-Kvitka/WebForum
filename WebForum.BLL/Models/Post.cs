using Microsoft.AspNetCore.Http;
using System;

namespace WebForum.BLL.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public Guid TopicId { get; set; }

        public DateTime PostDate { get; set; }

        public string Article { get; set; }

        public string Text { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

    }
}
