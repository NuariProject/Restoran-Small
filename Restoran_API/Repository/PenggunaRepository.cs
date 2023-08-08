using Restoran_API.DTO.jabatan;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;

namespace Restoran_API.Repository
{
    public class JabatanRepository : IJabatanRepository
    {
        private dbRestoranMakananContext _context;
        public JabatanRepository(dbRestoranMakananContext context)
        {
            _context = context;
        }

        public async Task<List<Jabatan>> getAllJabatan()
        {
            List<Jabatan> value = new List<Jabatan>();
            try
            {
                value = _context.Jabatans.Where(ss => ss.IsActive == true).ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return value;
        }
    }
}
