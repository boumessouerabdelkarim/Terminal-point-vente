using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface ICaisseService
    {
        Task<List<Caisse>> GetAll();
        Task<Caisse> GetCaisse(int id);
        Task AddCaisse(Caisse e);
        Task DeleteCaisse(int id);
        Task UpdateCaisse(Caisse e);
    }
}
