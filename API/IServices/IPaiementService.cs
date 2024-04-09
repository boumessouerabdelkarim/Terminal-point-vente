using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface IPaiementService
    {
        Task<List<Paiement>> GetAll();
        Task<Paiement> GetPaiement(int id);
        Task AddPaiement(Paiement e);
        Task DeletePaiement(int id);
        Task UpdatePaiement(Paiement e);
    }
}
