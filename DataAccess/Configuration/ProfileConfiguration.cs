using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ProfileName).IsRequired();
            builder.Property(x => x.ProfileDescription).IsRequired();

            builder.HasOne(n => n.User)
                .WithMany(n => n.Profiles)
                .HasForeignKey(n => n.UserId)
                .HasConstraintName("FK_UserId");
        }
    }
}
