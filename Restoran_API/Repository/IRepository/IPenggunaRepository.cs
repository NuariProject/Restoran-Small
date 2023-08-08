using Restoran_API.DTO.jabatan;
using Restoran_API.Models;

namespace Restoran_API.Repository.IRepository
{
    public interface IJabatanRepository
    {
        Task<List<Jabatan>> getAllJabatan();
    }
}
