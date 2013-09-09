using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class PickMap : EntityTypeConfiguration<Pick>
    {
        public PickMap()
        {
            // Table & Column Mappings
            ToTable("Pick", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");

            // Relationships
            HasRequired(p => p.Player)
                .WithMany(p => p.Picks)
                .HasForeignKey(p => p.PlayerId)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.Question)
                .WithMany(p => p.Picks)
                .HasForeignKey(p => p.QuestionId)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.Answer)
                .WithMany(p => p.Picks)
                .HasForeignKey(p => p.AnswerId)
                .WillCascadeOnDelete(false);
        }
    }
}