using Microsoft.EntityFrameworkCore;

namespace EFCore5Preview1.Entities
{
    [Keyless]
    public class KeylessEntity
    {
        public string Name { get; set; }
    }
}
