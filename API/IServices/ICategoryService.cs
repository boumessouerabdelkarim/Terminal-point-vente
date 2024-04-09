using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetCategory(int id);
        Task AddCategory(Category e);
        Task DeleteCategory(int id);
        Task UpdateCategory(Category e);
    }
}