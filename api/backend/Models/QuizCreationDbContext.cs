using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models
{
    public class QuizCreationDbContext : DbContext
    {
        public QuizCreationDbContext(DbContextOptions<QuizCreationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}