using Microsoft.EntityFrameworkCore;
using Restoran_API.DTO.menu;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Restoran_API.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private dbRestoranMakananContext _context;
        internal DbSet<Menu> dbset;
        public MenuRepository(dbRestoranMakananContext context)
        {
            _context = context;
            this.dbset = _context.Set<Menu>();
        }
        public async Task Create(Menu model)
        {
            try
            {
                model.IsActive = true;
                model.CreatedDate = DateTime.Now;
                await dbset.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(Menu model)
        {
            try
            {
                //_context.Menus.Remove(model);
                //await _context.SaveChangesAsync();

                model.ModifiedDate = DateTime.Now;
                model.IsActive = false;
                _context.Menus.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Menu> Update(Menu model)
        {
            try
            {
                model.ModifiedDate = DateTime.Now;
                model.IsActive = true;
                _context.Menus.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public async Task<List<Menu>> getAllMenu()
        {
            var value = new List<Menu>();
            try
            {
                value = _context.Menus.Where(ss => ss.IsActive == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return value;
        }

        public async Task<Menu> getMenu(Expression<Func<Menu, bool>> filter = null)
        {
            IQueryable<Menu> query = dbset;
            try
            {
                if (filter != null)
                {
                    query = query.Where(filter);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
