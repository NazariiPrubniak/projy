using Microsoft.EntityFrameworkCore;

namespace Wrap.Data
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
          : base(options)
        {
        }
        public DbSet<Wrap.Model.Account>? Account { get; set; }
    }
}
