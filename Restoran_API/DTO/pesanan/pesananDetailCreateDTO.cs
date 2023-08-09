using Restoran_API.DTO.menu;
using Restoran_API.Models;

namespace Restoran_API.DTO.pengguna
{
    public class pesananDetailCreateDTO
    {
        public int IdPesananHeader { get; set; }
        public int IdMenu { get; set; }
        public int Qty { get; set; }
    }
}
