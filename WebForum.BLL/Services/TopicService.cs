using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.DAL.Interfaces;

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


        public Task CreateAsync(Topic request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetPagedAsync(int page = 1, int pageSize = 15)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Topic request)
        {
            throw new NotImplementedException();
        }
    }
}
