using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class LignedeventeService : ILignedeVenteService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Lignedevente> _dbSet;

        public LignedeventeService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Lignedevente> GetLignedevente(int id)
        {


            return await _dbContext.Lignedeventes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Lignedevente>> GetAll()
        {
            return await _dbContext.Lignedeventes.ToListAsync();
        }
        public async Task AddLignedevente(Lignedevente e)
        {
            var entry = await _dbContext.Lignedeventes.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteLignedevente(int id)
        {
            var e = await GetLignedevente(id);
            if (e != null)
            {
                _dbContext.Lignedeventes.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateLignedevente(Lignedevente e)
        {
            _dbContext.Lignedeventes.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
