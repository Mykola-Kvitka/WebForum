using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.PL.ViewModels;

namespace WebForum.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public HomeController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var topic = await _topicService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(topic));
        }
    }
}
