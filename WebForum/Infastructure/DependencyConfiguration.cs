using Microsoft.Extensions.DependencyInjection;
using WebForum.BLL.Interfaces;
using WebForum.BLL.Services;
using WebForum.DAL;
using WebForum.DAL.Interfaces;
using WebForum.DAL.Models;
using WebForum.DAL.Repositories;

namespace WebForum.PL.Infastructure
{
    public static class DependencyConfiguration
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            //DAL configuration
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IGenericRepository<CommentEntity>, GenericRepository<CommentEntity>>();
            service.AddTransient<IGenericRepository<PostEntity>, GenericRepository<PostEntity>>();
            service.AddTransient<IGenericRepository<TopicEntity>, GenericRepository<TopicEntity>>();



            //BL configuration
            service.AddTransient<ICommentService, CommentService>();
            service.AddTransient<ITopicService, TopicService>();
            service.AddTransient<IPostService, PostService>();
        }

    }
}
