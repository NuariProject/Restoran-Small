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
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBayar { get; set; }
    }
}
