using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { Id = 1, Name = "Kalemler", IsDeleted = false },
            new Category { Id = 2, Name = "Kitaplar", IsDeleted = false },
            new Category { Id = 3, Name = "Defterler", IsDeleted = false }
            );
    }
}