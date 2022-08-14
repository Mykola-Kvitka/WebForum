using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.DAL.DataAccses;
using WebForum.DAL.Interfaces;
using WebForum.DAL.Models;
using WebForum.DAL.Repositories;

namespace WebForum.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccsess _appData;

        private GenericRepository<CommentEntity> _comments;
        private GenericRepository<TopicEntity> _topics;
        private GenericRepository<PostEntity> _posts;


        public UnitOfWork(DataAccsess appData)
        {
            _appData = appData;
        }

        public IGenericRepository<CommentEntity> Comments => _comments ??= new GenericRepository<CommentEntity>(_appData);

        public IGenericRepository<TopicEntity> Topics => _topics ??= new GenericRepository<TopicEntity>(_appData);

        public IGenericRepository<PostEntity> Posts => _posts ??= new GenericRepository<PostEntity>(_appData);
    }
}
