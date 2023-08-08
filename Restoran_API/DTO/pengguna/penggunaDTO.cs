namespace Restoran_API.DTO.pengguna
{
    public class penggunaDTO
    {
        public int Id { get; set; }
        public int Nik { get; set; }
        public string Nama { get; set; } = null!;
        public int IdJabatan { get; set; }
        public string Password { get; set; } = null!;
    }
}
