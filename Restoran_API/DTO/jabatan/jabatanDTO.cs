namespace Restoran_API.DTO.jabatan
{
    public class jabatanDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Jabatan1 { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
