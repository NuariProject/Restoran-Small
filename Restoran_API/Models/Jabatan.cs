using System;
using System.Collections.Generic;

namespace Restoran_API.Models
{
    public partial class Jabatan
    {
        public Jabatan()
        {
            Penggunas = new HashSet<Pengguna>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Jabatan1 { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModofiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Pengguna> Penggunas { get; set; }
    }
}
