using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore5Preview1.Entities
{
    [Table("Animals")]
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
    }
}
