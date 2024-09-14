using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EfCore
{
    public class RepositoryContext : DbContext
    {
        //veritabanına bağlanmak için bir ctor tanımlıyoruz;
        public RepositoryContext(DbContextOptions options) : base(options)
        { //kalıtım yoluyla, options ile bağlantı dizesi yapmış olduk?

        }
        //veritabanıdaki tablolarımız
        public DbSet<User> User { get; set; }
        public DbSet<Jobs> Job { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }


    }
}
