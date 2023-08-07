using System;
using System.Collections.Generic;

namespace Restoran_API.Models
{
    public partial class PesananHeader
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string NamaCustomer { get; set; } = null!;
        public int NoMeja { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModofiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBayar { get; set; }
    }
}
