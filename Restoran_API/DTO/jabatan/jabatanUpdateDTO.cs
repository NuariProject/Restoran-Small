namespace Restoran_API.DTO.jabatan
{
    public class jabatanUpdateDTO
    {
        public string Code { get; set; } = null!;
        public string Jabatan1 { get; set; } = null!;
        public string? ModifiedBy { get; set; }
        public DateTime? ModofiedDate { get; set; }
    }
}
