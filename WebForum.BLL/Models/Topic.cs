using Microsoft.AspNetCore.Http;

namespace WebForum.BLL.Models
{
    public class Topic
    {
        public string TopicName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

    }
}
