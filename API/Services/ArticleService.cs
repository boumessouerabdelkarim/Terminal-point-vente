using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ArticleService : IArticleService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Article> _dbSet;

        public ArticleService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Article> GetArticle(int id)
        {
            //Sql="SELECT * FROM ARTICLe WHERE idetd=id"

            return await _dbContext.Articles.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Article>> GetAll()
        {
            return await _dbContext.Articles.ToListAsync();
        }
        public async Task AddArticle(Article e)
        {
            var entry = await _dbContext.Articles.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteArticle(int id)
        {
            var e = await GetArticle(id);
            if (e != null)
            {
                _dbContext.Articles.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateArticle(Article e)
        {
            _dbContext.Articles.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
