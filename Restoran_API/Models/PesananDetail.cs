using System;
using System.Collections.Generic;

namespace Restoran_API.Models
{
    public partial class PesananDetail
    {
        public int Id { get; set; }
        public int IdPesananHeader { get; set; }
        public int IdMenu { get; set; }
        public int Qty { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
