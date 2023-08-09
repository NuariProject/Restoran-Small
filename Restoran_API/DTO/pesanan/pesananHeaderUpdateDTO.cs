using Restoran_API.DTO.pengguna;
using Restoran_API.Models;

namespace Restoran_API.DTO.pesanan
{
    public class pesananHeaderUpdateDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NamaCustomer { get; set; }
        public int NoMeja { get; set; }
        public bool IsBayar { get; set; }
        public List<pesananDetailUpdateDTO> PesananDetails { get; set; }
    }
}
