using Microsoft.EntityFrameworkCore.Design;

namespace EFCore5Preview1.Context
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
            => new SampleDbContext(args);
    }
}
