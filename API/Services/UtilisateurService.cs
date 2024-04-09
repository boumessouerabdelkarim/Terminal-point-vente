using API.Context;
using API.IServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        protected readonly IDbContextFactory _dbContextFactory;
        protected TPVDbContext _dbContext => _dbContextFactory?.DbContext;
        protected readonly DbSet<Utilisateur> _dbSet;

        public UtilisateurService(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Utilisateur> GetUtilisateur(int id)
        {


            return await _dbContext.Utilisateurs.Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Utilisateur>> GetAll()
        {
            return await _dbContext.Utilisateurs.ToListAsync();
        }
        public async Task AddUtilisateur(Utilisateur e)
        {
            var entry = await _dbContext.Utilisateurs.AddAsync(e);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUtilisateur(int id)
        {
            var e = await GetUtilisateur(id);
            if (e != null)
            {
                _dbContext.Utilisateurs.Remove(e);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateUtilisateur(Utilisateur e)
        {
            _dbContext.Utilisateurs.Update(e);
            await _dbContext.SaveChangesAsync();
        }
    }
}
