using FilteringInBlazor.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FilteringInBlazor.Database
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}