using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.PL.ViewModels;
using WebForum.PL.ViewModels.Admin;

namespace WebForum.PL.Controllers
{
    [Route("admin")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public AdminController(
            ITopicService topicService,
            IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("topics")]
        public async Task<ActionResult> TopicsAsync(int page = 1)
        {
            var result = new AdminTopicViewModel();

            if (page == 1)
            {
                result.TotalCount = await _topicService.GetCountAsync();
            }

            var activities = await _topicService.GetPagedAsync(page);

            result.Page = page;
            result.Topics = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicViewModel>>(activities);

            return View(result);
        }

        [HttpGet("topics/create")]
        public ActionResult CreateTopicAsync()
        {
            var viewModel = new TopicViewModel();

            return View(viewModel);
        }

        [HttpPost("topics/create")]
        public async Task<ActionResult> CreateTopicAsync(TopicViewModel requestVm)
        {

            var request = _mapper.Map<TopicViewModel, Topic>(requestVm);

            await _topicService.CreateAsync(request);

            return Redirect("~/admin/topics");
        }

        [HttpPost("topics/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTopic(Guid id)
        {
            await _topicService.DeleteAsync(id);

            return Redirect("~/admin/topics");
        }        
    }
}
