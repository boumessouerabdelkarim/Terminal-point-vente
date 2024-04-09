using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface IUtilisateurService
    {
        Task<List<Utilisateur>> GetAll();
        Task<Utilisateur> GetUtilisateur(int id);
        Task AddUtilisateur(Utilisateur e);
        Task DeleteUtilisateur(int id);
        Task UpdateUtilisateur(Utilisateur e);
    }
}
