using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface ISessionService
    {
        Task<List<Session>> GetAll();
        Task<Session> GetSession(int id);
        Task AddSession(Session e);
        Task DeleteSession(int id);
        Task UpdateSession(Session e);
    }
}
