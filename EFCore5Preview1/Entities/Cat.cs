using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore5Preview1.Entities
{
    [Table("Cats")]
    public class Cat : Pet
    {
        public string EdcuationLevel { get; set; }
    }
}
