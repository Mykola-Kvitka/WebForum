using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.DAL.Models;

namespace WebForum.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<CommentEntity> Comments { get; }
        IGenericRepository<TopicEntity> Topics { get; }
        IGenericRepository<PostEntity> Posts { get; }
    }
}
