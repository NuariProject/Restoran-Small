using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restoran_API.DTO.pengguna;
using Restoran_API.DTO.pesanan;
using Restoran_API.Models;
using Restoran_API.Repository.IRepository;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Restoran_API.Repository
{
    public class PesananRepository : IPesananRepository
    {
        private dbRestoranMakananContext _context;
        private readonly IMapper _mapping;
        //internal DbSet<Menu> dbset;
        public PesananRepository(dbRestoranMakananContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
            //this.dbset = _context.Set<Menu>();
        }

        public async Task<List<pesananHeaderDTO>> getAllPesanan()
        {
            List<pesananHeaderDTO> mappingHeader = new List<pesananHeaderDTO>();
            List<pesananDetailDTO> mappingDetail = new List<pesananDetailDTO>();
            try
            {
                var valueHeader = _context.PesananHeaders.Where(ss => ss.IsActive).ToList();
                var valueDetail = _context.PesananDetails.Where(ss => ss.IsActive).ToList();
                mappingHeader = _mapping.Map<List<pesananHeaderDTO>>(valueHeader);
                mappingDetail = _mapping.Map<List<pesananDetailDTO>>(valueDetail);

                foreach (var a in mappingHeader)
                {
                    a.PesananDetails = mappingDetail
                        .Where(detail => detail.IdPesananHeader == a.Id)
                        .ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return mappingHeader;
        }

        public async Task<pesananHeaderDTO> getPesanan(Expression<Func<PesananHeader, bool>> filter = null)
        {
            pesananHeaderDTO mappingHeader = new pesananHeaderDTO();
            List<pesananDetailDTO> mappingDetail = new List<pesananDetailDTO>();
            try
            {
                var valueHeader = _context.PesananHeaders.Where(filter).FirstOrDefault();
                var valueDetail = _context.PesananDetails.Where(ss => ss.IsActive).ToList();

                mappingHeader = _mapping.Map<pesananHeaderDTO>(valueHeader);
                mappingDetail = _mapping.Map<List<pesananDetailDTO>>(valueDetail);

                mappingHeader.PesananDetails = mappingDetail
                    .Where(detail => detail.IdPesananHeader == mappingHeader.Id)
                    .ToList();

                return mappingHeader;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
