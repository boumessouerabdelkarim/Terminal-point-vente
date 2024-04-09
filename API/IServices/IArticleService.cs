using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface IArticleService
    {
        Task<List<Article>> GetAll();
        Task<Article> GetArticle(int id);
        Task AddArticle(Article e);
        Task DeleteArticle(int id);
        Task UpdateArticle(Article e);
    }
}
