using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ModepaiementService : IModepaiementService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Modepaiement> _dbSet;

        public ModepaiementService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Modepaiement> GetModePaiement(int id)
        {


            return await _dbContext.Modepaiements.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Modepaiement>> GetAll()
        {
            return await _dbContext.Modepaiements.ToListAsync();
        }
        public async Task AddModePaiement(Modepaiement e)
        {
            var entry = await _dbContext.Modepaiements.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteModePaiement(int id)
        {
            var e = await GetModePaiement(id);
            if (e != null)
            {
                _dbContext.Modepaiements.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateModePaiement(Modepaiement e)
        {
            _dbContext.Modepaiements.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
