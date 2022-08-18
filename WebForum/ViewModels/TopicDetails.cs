using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels
{
    public class TopicDetailsViewModel
    {
        public TopicViewModel Topic { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
