using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.PL.ViewModels.Admin
{
    public class AdminTopicViewModel : PagedViewModel
    {
        public IEnumerable<TopicViewModel> Topics { get; set; }
    }
}
