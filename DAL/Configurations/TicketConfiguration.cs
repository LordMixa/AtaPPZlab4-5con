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
    public class TicketConfiguration : EntityTypeConfiguration<DBTicket>
    {
        public TicketConfiguration()
        {
            ToTable("Tickets");

            Property(c => c.NameShow)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.NameOfOwner)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Date)
                .IsRequired();

            Property(c => c.Price)
                .IsRequired();
        }
    }
}
