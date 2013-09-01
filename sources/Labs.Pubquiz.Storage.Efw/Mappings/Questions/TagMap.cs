using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Questions
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Table & Column Mappings
            ToTable("Tag", "questions");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);

            // Relationships
            HasOptional(t => t.Parent)
                .WithMany(t => t.Children)
                .HasForeignKey(d => d.ParentId);
            HasMany(t => t.Children)
                .WithOptional(t => t.Parent)
                .HasForeignKey(t => t.ParentId);
        }
    }
}