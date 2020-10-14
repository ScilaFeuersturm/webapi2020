using Microsoft.EntityFrameworkCore;
/*El contexto de base de datos es la clase principal que coordina 
la funcionalidad de Entity Framework para un modelo de datos*/
namespace Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }

        public DbSet<UserEntity> UserItems { get; set; }
        public DbSet<StudentEntity> StudentItems { get; set; }
    }
}