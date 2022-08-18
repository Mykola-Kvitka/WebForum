using AutoMapper;
using WebForum.BLL.Models;
using WebForum.PL.ViewModels;
using WebForum.DAL.Models;
using System.Linq.Expressions;
using System;

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
            CreateMap<Expression<Func<Post, bool>>, Expression<Func<PostEntity, bool>>>().ReverseMap();
            CreateMap<Expression<Func<Comment, bool>>, Expression<Func<CommentEntity, bool>>>().ReverseMap();
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
