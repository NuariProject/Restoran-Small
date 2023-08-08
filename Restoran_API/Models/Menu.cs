using System;
using System.Collections.Generic;

namespace Restoran_API.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Stok { get; set; }
        public decimal Harga { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
