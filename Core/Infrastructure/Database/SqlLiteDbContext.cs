using Microsoft.EntityFrameworkCore;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;

public class SqlLiteDbContext : DbContext
{
    // Define the path relative to the application's root directory
    private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "sqlite.db");

    // Ensure the Data directory is created if it doesn't exist
    static SqlLiteDbContext()
    {
        var directory = Path.GetDirectoryName(DbPath);
        if (Directory.Exists(directory))
        {
            return;
        }

        if (directory != null)
        {
            Directory.CreateDirectory(directory);
        }
    }

    // Configure EF to use the Sqlite database file
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}