using WebAPI.Domain.Models;
using WebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WebAPI.DataAccess.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<VideoEntity>
    {
        public void Configure(EntityTypeBuilder<VideoEntity> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Name).HasMaxLength(Video.MAX_NAME_LENGTH);
            builder.Property(v => v.Duration).IsRequired();
            builder.Property(v => v.Url).IsRequired();
        }
    }
}
