﻿using Restoran_API.DTO.menu;
using Restoran_API.Models;

namespace Restoran_API.DTO.pengguna
{
    public class pesananDetailDTO
    {
        public int Id { get; set; }
        public int IdPesananHeader { get; set; }
        public int IdMenu { get; set; }
        public int Qty { get; set; }
        public menuDTO menu { get; set; }
    }
}
