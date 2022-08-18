using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Helpers;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.DAL.Interfaces;
using WebForum.DAL.Models;

namespace WebForum.BLL.Services
{
    public class TopicService : ITopicService
    {
        private static readonly string ImagePath = "imgs/Topics";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task CreateAsync(Topic request)
        {
            var requestEntity = _mapper.Map<Topic, TopicEntity>(request);

            if (request.Image != null)
            {
                requestEntity.ImagePath = ImageSaveHelper.SaveImageAndGeneratePath(request.Image, ImagePath);
            }

            await _unitOfWork.Topics.CreateAsync(requestEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = await GetAsync(id);
            ImageSaveHelper.DeleteImage(request.ImagePath);

            await _unitOfWork.Topics.DeleteAsync(id);
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            var post = await _unitOfWork.Topics.GetAllAsync();

            return _mapper.Map<IEnumerable<TopicEntity>, IEnumerable<Topic>>(post);
        }

        public async Task<Topic> GetAsync(Guid id)
        {
            var result = await _unitOfWork.Topics.GetAsync(id);

            return _mapper.Map<TopicEntity, Topic>(result);
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Topics.GetCountAsync();
        }

        public async Task<IEnumerable<Topic>> GetPagedAsync(int page = 1, int pageSize = 15)
        {
            var topic = await _unitOfWork.Topics.GetPagedAsync(page, pageSize);

            return _mapper.Map<IEnumerable<TopicEntity>, IEnumerable<Topic>>(topic);
        }

        public async Task UpdateAsync(Topic request)
        {
            var requestEntity = _mapper.Map<Topic, TopicEntity>(request);

            if (request.Image != null)
            {
                ImageSaveHelper.DeleteImage(requestEntity.ImagePath);
                requestEntity.ImagePath = ImageSaveHelper.SaveImageAndGeneratePath(request.Image, ImagePath);
            }

            await _unitOfWork.Topics.UpdateAsync(requestEntity);
        }
    }
}
