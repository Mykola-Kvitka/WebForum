using AutoMapper;
using WebForum.BLL.Models;
using WebForum.PL.ViewModels;
using WebForum.DAL.Models;


namespace WebForum.PL.Mapping
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            AddBusinessMapping();
            AddWebMapping();
        }

        public void AddWebMapping()
        {
            CreateMap<TopicEntity, Topic>().ReverseMap();
            CreateMap<CommentEntity, Comment>().ReverseMap();
            CreateMap<PostEntity, Post>().ReverseMap();
        }

        public void AddBusinessMapping()
        {
            CreateMap<Topic, TopicViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
    }
}
