using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class TopicViewModel
    {
        public string TopicName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }
    }
}
