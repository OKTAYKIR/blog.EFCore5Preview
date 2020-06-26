using System;
using System.Collections.Generic;

namespace EFCore5Preview1.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Blog { get; set; }
        public decimal Price { get; set; }
        public decimal Computed { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Blog> BlogList { get; set; }
    }
}