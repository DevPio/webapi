
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers;

public class DataContext : DbContext
{


    public DataContext(DbContextOptions<DataContext> opts) : base(opts)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
}