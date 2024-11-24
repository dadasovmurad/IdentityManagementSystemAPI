using IdentityManagementSystemAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
 {
     public AppDbContext CreateDbContext(string[] args)
     {
         DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();
         dbContextOptionsBuilder.UseNpgsql(ConnectionManager.ConnectionString);
         return new(dbContextOptionsBuilder.Options);
     }
 }