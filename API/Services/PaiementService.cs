using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services 
{
    public class PaiementService : IPaiementService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Paiement> _dbSet;

        public PaiementService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Paiement> GetPaiement(int id)
        {


            return await _dbContext.Paiements.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Paiement>> GetAll()
        {
            return await _dbContext.Paiements.ToListAsync();
        }
        public async Task AddPaiement(Paiement e)
        {
            var entry = await _dbContext.Paiements.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeletePaiement(int id)
        {
            var e = await GetPaiement(id);
            if (e != null)
            {
                _dbContext.Paiements.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdatePaiement(Paiement e)
        {
            _dbContext.Paiements.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
