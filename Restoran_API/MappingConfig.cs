using AutoMapper;
using Restoran_API.DTO.jabatan;
using Restoran_API.Models;

namespace Restoran_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Jabatan, jabatanDTO>().ReverseMap();
            CreateMap<Jabatan, jabatanCreateDTO>().ReverseMap();
            CreateMap<Jabatan, jabatanUpdateDTO>().ReverseMap();
        }
    }
}
