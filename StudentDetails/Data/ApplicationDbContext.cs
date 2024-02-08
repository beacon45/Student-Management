using Microsoft.EntityFrameworkCore;
using StudentDetails.Models.Entity;

namespace StudentDetails.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions):base(contextOptions)
        {
            
        }
        public DbSet<Student> students { get; set; }
    }
}
