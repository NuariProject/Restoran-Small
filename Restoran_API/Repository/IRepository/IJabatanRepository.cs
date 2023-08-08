using Restoran_API.DTO.pengguna;
using Restoran_API.Models;

namespace Restoran_API.Repository.IRepository
{
    public interface IPenggunaRepository
    {
        Task<List<Pengguna>> getAllPengguna();
    }
}
