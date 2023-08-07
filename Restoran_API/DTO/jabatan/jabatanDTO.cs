namespace Restoran_API.DTO.jabatan
{
    public class jabatanDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Jabatan1 { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModofiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
