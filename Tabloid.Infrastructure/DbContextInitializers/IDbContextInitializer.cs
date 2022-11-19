using Microsoft.EntityFrameworkCore;

namespace Tabloid.Infrastructure.DbContextInitializers;

public interface IDbContextInitializer
{
    void Seed(ModelBuilder modelBuilder);
}