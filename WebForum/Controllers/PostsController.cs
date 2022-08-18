using AutoMapper;
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
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ITopicService _topicService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public PostsController(
            IPostService postService,
            ITopicService topicService,
            ICommentService commentService,
            IMapper mapper)
        {
            _postService = postService;
            _topicService = topicService;
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("topic/detail/{id}")]
        public async Task<ActionResult> Index(Guid id)
        {
            var posts = new TopicDetailsViewModel();
            posts.Topic = _mapper.Map < Topic, TopicViewModel >( await _topicService.GetAsync(id));

            var post = await _postService.FindAsync(a => a.TopicId == id);
            posts.Posts = _mapper.Map <IEnumerable<Post>, IEnumerable<PostViewModel> >(post);
            return View(posts);
        }

        [HttpGet("posts")]
        public async Task<ActionResult> PostsAsync(int page = 1)
        {
            var result = new AdminPostViewModel();

            if (page == 1)
            {
                result.TotalCount = await _postService.GetCountAsync();
            }

            var activities = await _postService.GetPagedAsync(page);

            result.Page = page;
            result.Posts = _mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(activities);

            return View(result);
        }

        [HttpGet("posts/create/{id}")]
        public ActionResult CreatePostAsync(Guid id)
        {
            var viewModel = new PostViewModel();
            viewModel.TopicId = id;

            return View(viewModel);
        }

        [HttpPost("posts/create/{id}")]
        public async Task<ActionResult> CreatePostAsync(Guid id, PostViewModel requestVm)
        {

            var request = _mapper.Map<PostViewModel, Post>(requestVm);

            await _postService.CreateAsync(request);

            return Redirect("~/home");
        }

        [HttpPost("posts/delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            await _postService.DeleteAsync(id);

            return Redirect("~/home");
        }

        [HttpGet("posts/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var details = new PostDetailViewModel();
            details.Posts = _mapper.Map<Post, PostViewModel>(await _postService.GetAsync(id));
            details.Comments = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(await _commentService.FindAsync(a => a.PostId == id));

            return View(details);
        }
    }
}
