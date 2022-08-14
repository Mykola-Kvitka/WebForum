using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.DAL.Interfaces;
using WebForum.DAL.Models;

namespace WebForum.BLL.Services
{
    public class PostService : IPostService
    {
        private static readonly string ImagePath = "imgs/Posts";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task CreateAsync(Post request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var post = await _unitOfWork.Posts.GetAllAsync();

            return _mapper.Map<IEnumerable<PostEntity>, IEnumerable<Post>>(post);
        }

        public Task<Post> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPagedAsync(int page = 1, int pageSize = 15)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post request)
        {
            throw new NotImplementedException();
        }
    }
}
