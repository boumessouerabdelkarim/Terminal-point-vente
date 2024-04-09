using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface ILignedeVenteService
    {
        Task<List<Lignedevente>> GetAll();
        Task<Lignedevente> GetLignedevente(int id);
        Task AddLignedevente(Lignedevente e);
        Task DeleteLignedevente(int id);
        Task UpdateLignedevente(Lignedevente e);
    }
}
