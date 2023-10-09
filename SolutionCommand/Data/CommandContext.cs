using Microsoft.EntityFrameworkCore;
using Solution.Models;

namespace Solution.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options)
            : base(options) { }

        public DbSet<Command> Commands { get; set; }
    }
}