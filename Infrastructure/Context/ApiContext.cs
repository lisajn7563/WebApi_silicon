
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribes { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
   
}
