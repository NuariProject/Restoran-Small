namespace Restoran_API.DTO.jabatan
{
    public class jabatanCreateDTO
    {
        public string Code { get; set; } = null!;
        public string Jabatan1 { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
