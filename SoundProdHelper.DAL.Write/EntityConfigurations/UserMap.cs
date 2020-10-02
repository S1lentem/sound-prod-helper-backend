using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoundProdHelper.Domain.Write.Entities;

namespace SoundProdHelper.DAL.Write.EntityConfigurations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Uid);

            // TODO Add constraints;
        }
    }
}