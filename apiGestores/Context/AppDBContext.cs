using apiGestores.models;
using Microsoft.EntityFrameworkCore;

namespace apiGestores.Context
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Gestores_bd> Gestores_bd { get; set; }
        }
}
