using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class SessionService : ISessionService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Paiement> _dbSet;

        public SessionService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Session> GetSession(int id)
        {


            return await _dbContext.Sessions.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Session>> GetAll()
        {
            return await _dbContext.Sessions.ToListAsync();
        }
        public async Task AddSession(Session e)
        {
            var entry = await _dbContext.Sessions.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteSession(int id)
        {
            var e = await GetSession(id);
            if (e != null)
            {
                _dbContext.Sessions.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateSession(Session e)
        {
            _dbContext.Sessions.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
