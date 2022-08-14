using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Models;

namespace WebForum.BLL.Interfaces
{
    public interface ICommentService
    {
        Task CreateAsync(Comment request);
        Task<List<Comment>> FindAsync(Expression<Func<Comment, Boolean>> predicate);
        Task<int> GetCountAsync();
        Task DeleteAsync(Guid id);

    }
}
