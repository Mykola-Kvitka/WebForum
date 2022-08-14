﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.DAL.Interfaces;
using WebForum.DAL.Models;

namespace WebForum.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(Comment request)
        {
            var requestEntity = _mapper.Map<Comment, CommentEntity>(request);

            await _unitOfWork.Comments.CreateAsync(requestEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Comments.DeleteAsync(id);

        }

        public async Task<List<Comment>> FindAsync(Expression<Func<Comment, bool>> predicate)
        {
            var requestEntity = _mapper.Map<Expression<Func<Comment, bool>>, Expression<Func<CommentEntity, bool>>>(predicate);

            var replay = await _unitOfWork.Comments.FindAsync(requestEntity);

            return _mapper.Map <List<CommentEntity> , List<Comment>>(replay);
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Comments.GetCountAsync();
        }
    }
}
