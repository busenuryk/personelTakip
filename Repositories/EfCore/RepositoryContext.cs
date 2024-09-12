using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryContext : DbContext
    {
        //veritabanına bağlanmak için bir ctor tanımlıyoruz;
        public RepositoryContext(DbContextOptions options) : base(options)
        { //kalıtım yoluyla, options ile bağlantı dizesi yapmış olduk?

        }
        //veritabanıdaki tablolarımız
        public DbSet<User> Users { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Department> Department { get; set; }


    }
}
