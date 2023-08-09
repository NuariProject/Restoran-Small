using Restoran_API.DTO.menu;
using Restoran_API.Models;
using System.Linq.Expressions;

namespace Restoran_API.Repository.IRepository
{
    public interface IMenuRepository
    {
        Task<List<Menu>> getAllMenu();
        Task<Menu> getMenu(Expression<Func<Menu, bool>> filter = null);
        Task Create(Menu model);
        Task<Menu> Update(Menu model);
        Task Delete(int id);
    }
}
