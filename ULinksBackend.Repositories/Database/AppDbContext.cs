using UsefulLinksBackend.Models;

namespace UsefulLinksBackend.Database;
using Microsoft.EntityFrameworkCore;


// need to name like project name in complex projects
public class AppDbContext : DbContext
{
    public string DbPath { get; }
    
    public DbSet<UsefulLink> UsefulLinks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ULinkTag> ULinkTags { get; set; }


    private string dbPath = @"C:\Users\Necromant\RiderProjects\ULinksBackend\ULinksBackend.Repositories\DB\appDb.db";

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, DbPath);
        
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={dbPath}");
}