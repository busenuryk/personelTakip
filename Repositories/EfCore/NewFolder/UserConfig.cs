using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.EfCore.NewFolder
{
    public class UserConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {Name = "Personel"},
                new IdentityRole
                {Name = "Admin"}
            );
        }
    }
}
