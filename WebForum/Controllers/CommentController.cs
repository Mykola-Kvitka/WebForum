using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using AutoMapper;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Models;
using WebForum.PL.ViewModels;
using WebForum.DAL.Models;


namespace WebForum.PL.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        //private readonly UserManager<UserEntity> _userManager;

        public CommentController(IMapper mapper, ICommentService commentService/*,  UserManager<UserEntity> userManager*/)
        {
            _commentService = commentService;
            _mapper = mapper;
            //_userManager = userManager;            
        }

        [HttpPost("post/{id}/newcomment")]
        public  IActionResult CommentsAsync([FromRoute] Guid id, CommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Fill in all fields";
                return Redirect($"~/post/comments");
            }
            var commentDto = _mapper.Map<CommentViewModel, Comment>(comment);
            commentDto.PostId = id;
            _commentService.CreateAsync(commentDto);
            return Redirect($"~/posts/{id}");
        }

        [HttpPost("post/{id}/delete/{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id, [FromRoute]Guid commentId)
        {
            await _commentService.DeleteAsync(commentId);
            return Redirect($"~/posts/{id}");
        }
    }
}
