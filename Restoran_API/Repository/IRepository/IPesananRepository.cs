using Restoran_API.DTO.pengguna;
using Restoran_API.DTO.pesanan;
using Restoran_API.Models;
using System.Linq.Expressions;

namespace Restoran_API.Repository.IRepository
{
    public interface IPesananRepository
    {
        Task<List<pesananHeaderDTO>> getAllPesanan();
        Task<pesananHeaderDTO> getPesanan(Expression<Func<PesananHeader, bool>> filter = null);
        Task Create(PesananHeader header, List<PesananDetail> details);
        Task<pesananHeaderDTO> Update(PesananHeader header, List<PesananDetail> details);
        Task Delete(int id);
    }
}
