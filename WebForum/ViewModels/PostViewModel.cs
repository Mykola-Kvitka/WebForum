using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public DateTime PostDate { get; set; }

        public string Article { get; set; }

        public string Text { get; set; }

        public string ImagePath { get; set; }

        public IFormFile Image { get; set; }

    }
}
