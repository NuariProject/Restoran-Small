﻿using AutoMapper;
using Restoran_API.DTO.jabatan;
using Restoran_API.DTO.menu;
using Restoran_API.DTO.pengguna;
using Restoran_API.DTO.pesanan;
using Restoran_API.Models;

namespace Restoran_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Jabatan, jabatanDTO>().ReverseMap();

            CreateMap<Pengguna, penggunaDTO>().ReverseMap();

            CreateMap<Menu, menuDTO>().ReverseMap();
            CreateMap<Menu, menuCreateDTO>().ReverseMap();
            CreateMap<Menu, menuUpdateDTO>().ReverseMap(
        }
    }
}
