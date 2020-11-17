using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore5Preview1.Entities
{
    [Table("Pets")]
    public class Pet : Animal
    {
        public string Name { get; set; }
    }
}