using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore5Preview1.Entities
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }

        public virtual User User { get; set; }
    }
}
