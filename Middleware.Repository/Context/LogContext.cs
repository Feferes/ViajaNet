using Microsoft.EntityFrameworkCore;
using Middleware.Repository.Model;

namespace Middleware.Repository.Context
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptionsBuilder<LogContext> options)
            : base(options.Options)
        {

        }

        public DbSet<Log> Log { get; set; }
    }
}
