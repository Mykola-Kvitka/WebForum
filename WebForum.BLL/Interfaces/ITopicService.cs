using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Models;

namespace WebForum.BLL.Interfaces
{
    public interface ITopicService
    {
        Task CreateAsync(Topic request);
        Task<int> GetCountAsync();
        Task<IEnumerable<Topic>> GetPagedAsync(int page = 1, int pageSize = 15);
        Task<IEnumerable<Topic>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task<Topic> GetAsync(Guid id);
        Task UpdateAsync(Topic request);
    }
}
