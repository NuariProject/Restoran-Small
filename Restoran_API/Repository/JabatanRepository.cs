using Restoran_API.Models;
using Restoran_API.Repository.IRepository;

namespace Restoran_API.Repository
{
    public class PenggunaRepository : IPenggunaRepository
    {
        private dbRestoranMakananContext _context;
        public PenggunaRepository(dbRestoranMakananContext context)
        {
            _context = context;
        }

        public async Task<List<Pengguna>> getAllPengguna()
        {
            List<Pengguna> value = new List<Pengguna>();
            try
            {
                value = _context.Penggunas.Where(ss => ss.IsActive == true).ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return value;
        }
    }
}
