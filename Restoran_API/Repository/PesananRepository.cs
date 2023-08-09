using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restoran_API.DTO.menu;
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
        internal DbSet<PesananHeader> dbset;
        public PesananRepository(dbRestoranMakananContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
            this.dbset = _context.Set<PesananHeader>();
        }

        public async Task<List<pesananHeaderDTO>> getAllPesanan()
        {
            List<pesananHeaderDTO> mappingHeader = new List<pesananHeaderDTO>();
            List<menuDTO> mappingMenu = new List<menuDTO>();
            List<pesananDetailDTO> mappingDetail = new List<pesananDetailDTO>();
            try
            {
                var valueHeader = _context.PesananHeaders.Where(ss => ss.IsActive).ToList();
                var valueDetail = _context.PesananDetails.Where(ss => ss.IsActive).ToList();
                var valueMenu = _context.Menus.Where(ss => ss.IsActive).ToList();

                mappingHeader = _mapping.Map<List<pesananHeaderDTO>>(valueHeader);
                mappingDetail = _mapping.Map<List<pesananDetailDTO>>(valueDetail);
                mappingMenu = _mapping.Map<List<menuDTO>>(valueMenu);


                foreach (var item in mappingDetail)
                {
                    item.menu = mappingMenu.Where(detail => detail.Id == item.IdMenu).FirstOrDefault();
                } 

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
            List<menuDTO> mappingMenu = new List<menuDTO>();
            List<pesananDetailDTO> mappingDetail = new List<pesananDetailDTO>();
            try
            {
                var valueHeader = _context.PesananHeaders.Where(filter).FirstOrDefault();
                var valueDetail = _context.PesananDetails.Where(ss => ss.IsActive).ToList();
                var valueMenu = _context.Menus.Where(ss => ss.IsActive).ToList();

                mappingHeader = _mapping.Map<pesananHeaderDTO>(valueHeader);
                mappingDetail = _mapping.Map<List<pesananDetailDTO>>(valueDetail);
                mappingMenu = _mapping.Map<List<menuDTO>>(valueMenu);

                if (valueHeader != null)
                {
                    mappingHeader.PesananDetails = mappingDetail
                        .Where(detail => detail.IdPesananHeader == mappingHeader.Id)
                        .ToList();

                    foreach (var item in mappingHeader.PesananDetails)
                    {
                        item.menu = mappingMenu.Where(detail => detail.Id == item.IdMenu).FirstOrDefault();
                    }

                }

                return mappingHeader;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task Create(PesananHeader header, List<PesananDetail> details)
        {
            using (var trx = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    header.CreatedDate = DateTime.Now;
                    header.IsActive = true;
                    _context.PesananHeaders.AddAsync(header);
                    await _context.SaveChangesAsync();
                    var headerId = header.Id;

                    foreach (var item in details)
                    {
                        item.CreatedDate = DateTime.Now;
                        item.IsActive = true;
                        item.IdPesananHeader = headerId;
                        _context.PesananDetails.AddAsync(item);
                        await _context.SaveChangesAsync();
                    }

                    trx.Commit();
                    
                }
                catch (Exception)
                {
                    trx.Rollback();
                    throw;
                }
            }
        }

        public async Task<pesananHeaderDTO> Update(PesananHeader header, List<PesananDetail> details)
        {
            var mapingHeader = _mapping.Map<pesananHeaderDTO>(header);
            mapingHeader.PesananDetails = _mapping.Map<List<pesananDetailDTO>>(details);

            using (var trx = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    header = await _context.PesananHeaders.FindAsync(header.Id);
                    header.ModifiedDate = DateTime.Now;
                    header.IsActive = true;
                    _context.PesananHeaders.Update(header);
                    await _context.SaveChangesAsync();
                    var headerId = header.Id;


                    var dtl= await _context.PesananDetails.Where(ss => ss.IdPesananHeader == header.Id).ToListAsync();
                    _context.PesananDetails.RemoveRange(dtl);
                    await _context.SaveChangesAsync();

                    foreach (var item in details)
                    {
                        item.ModifiedDate = DateTime.Now;
                        item.CreatedDate = DateTime.Now;
                        item.IsActive = true;
                        item.IdPesananHeader = headerId;
                        _context.PesananDetails.AddAsync(item);
                        await _context.SaveChangesAsync();
                    }

                    trx.Commit();

                    return mapingHeader;

                }
                catch (Exception)
                {
                    trx.Rollback();
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            using (var trx = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var header = await _context.PesananHeaders.FindAsync(id);

                    header.ModifiedDate = DateTime.Now;
                    header.IsActive = false;
                    _context.PesananHeaders.Update(header);
                    await _context.SaveChangesAsync();

                    trx.Commit();

                }
                catch (Exception)
                {
                    trx.Rollback();
                    throw;
                }
            }
        }
    }
}
