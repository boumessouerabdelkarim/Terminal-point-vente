using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CaisseService : ICaisseService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Caisse> _dbSet;

        public CaisseService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Caisse> GetCaisse(int id)
        {
           

            return await _dbContext.Caisses.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Caisse>> GetAll()
        {
            return await _dbContext.Caisses.ToListAsync();
        }
        public async Task AddCaisse(Caisse e)
        {
            var entry = await _dbContext.Caisses.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCaisse(int id)
        {
            var e = await GetCaisse(id);
            if (e != null)
            {
                _dbContext.Caisses.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateCaisse(Caisse e)
        {
            _dbContext.Caisses.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
