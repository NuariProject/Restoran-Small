using System;
using System.Collections.Generic;

namespace Restoran_API.Models
{
    public partial class Pengguna
    {
        public int Id { get; set; }
        public int Nik { get; set; }
        public string Nama { get; set; } = null!;
        public int IdJabatan { get; set; }
        public string Password { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Jabatan IdJabatanNavigation { get; set; } = null!;
    }
}
