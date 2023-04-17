using DAL.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ShowConfiguration : EntityTypeConfiguration<DBShow>
    {
        public ShowConfiguration() 
        {
            ToTable("Shows");

            Property(c => c.DBShowId)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Author)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Genre)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.CountSeats)
                .IsRequired();

            Property(c => c.Date)
                .IsRequired();

            Property(c => c.Price)
                .IsRequired();
        }
    }
}
