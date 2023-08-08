namespace Restoran_API.DTO.menu
{
    public class menuCreateDTO
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Stok { get; set; }
        public decimal Harga { get; set; }
    }
}
