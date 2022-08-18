using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Models;
using WebForum.DAL.Models;

namespace WebForum.BLL.Interfaces
{
    public interface IPostService
    {
        Task CreateAsync(Post request);
        Task<IEnumerable<Post>> FindAsync(Expression<Func<PostEntity, bool>> predicate);
        Task<int> GetCountAsync();
        Task<IEnumerable<Post>> GetPagedAsync(int page = 1, int pageSize = 15);
        Task<IEnumerable<Post>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task<Post> GetAsync(Guid id);
        Task UpdateAsync(Post request);
    }
}
