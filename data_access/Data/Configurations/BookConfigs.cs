using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data.Configurations
{
    public class BookConfigs : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            builder.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Books).HasForeignKey(x => x.GenreId);
            builder.HasOne(x => x.PreviousBook).WithOne(x => x.NextBook).HasForeignKey<Book>(x => x.PreviousBookId).IsRequired(false);
        }
    }
}
