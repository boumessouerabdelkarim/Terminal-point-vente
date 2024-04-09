using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class VenteService : IVenteService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Vente> _dbSet;

        public VenteService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Vente> GetVente(int id)
        {


            return await _dbContext.Ventes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vente>> GetAll()
        {
            return await _dbContext.Ventes.ToListAsync();
        }
        public async Task AddVente(Vente e)
        {
            var entry = await _dbContext.Ventes.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteVente(int id)
        {
            var e = await GetVente(id);
            if (e != null)
            {
                _dbContext.Ventes.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateVente(Vente e)
        {
            _dbContext.Ventes.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
