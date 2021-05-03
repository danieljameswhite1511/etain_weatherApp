using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            //builder.HasOne(x => x.Menu).WithMany().HasForeignKey(x => x.MenuId);
            builder.HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentId);
            builder.Property(x => x.LinkText).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SortOrder).IsRequired();

        }
    }

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
          builder.HasMany(x => x.MenuItems);

        }
    }
}