using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Helpers;
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

        public async Task CreateAsync(Post request)
        {
            var requestEntity = _mapper.Map<Post, PostEntity>(request);

            if (request.Image != null)
            {
                requestEntity.ImagePath = ImageSaveHelper.SaveImageAndGeneratePath(request.Image, ImagePath);
            }

            await _unitOfWork.Posts.CreateAsync(requestEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = await GetAsync(id);
            ImageSaveHelper.DeleteImage(request.ImagePath);

            await _unitOfWork.Posts.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var post = await _unitOfWork.Posts.GetAllAsync();

            return _mapper.Map<IEnumerable<PostEntity>, IEnumerable<Post>>(post);
        }

        public async Task<Post> GetAsync(Guid id)
        {
            var result = await _unitOfWork.Posts.GetAsync(id);

            return _mapper.Map<PostEntity, Post>(result);
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Posts.GetCountAsync();
        }

        public async Task<IEnumerable<Post>> GetPagedAsync(int page = 1, int pageSize = 15)
        {
            var topic = await _unitOfWork.Posts.GetPagedAsync(page, pageSize);

            return _mapper.Map<IEnumerable<PostEntity>, IEnumerable<Post>>(topic);
        }

        public async Task UpdateAsync(Post request)
        {
            var requestEntity = _mapper.Map<Post, PostEntity>(request);

            if (request.Image != null)
            {
                ImageSaveHelper.DeleteImage(requestEntity.ImagePath);
                requestEntity.ImagePath = ImageSaveHelper.SaveImageAndGeneratePath(request.Image, ImagePath);
            }

            await _unitOfWork.Posts.UpdateAsync(requestEntity);
        }

        public async Task<IEnumerable<Post>> FindAsync(Expression<Func<PostEntity, bool>> predicate)
        {

            var replay = await _unitOfWork.Posts.FindAsync(predicate);

            return _mapper.Map<List<PostEntity>, List<Post>>(replay);
        }

    }
}
