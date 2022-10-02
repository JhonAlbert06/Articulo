using Microsoft.EntityFrameworkCore;
using Articulo.Models;

namespace Articulo.Data;

public class Contexto : DbContext {
    public Contexto(DbContextOptions<Contexto> options): base(options){}

    public DbSet<Articulos> Articulos { get; set; }
}
