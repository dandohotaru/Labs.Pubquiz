using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class RoundMap : EntityTypeConfiguration<Round>
    {
        public RoundMap()
        {
            // Table & Column Mappings
            ToTable("Round", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");

            // Relationships
            HasRequired(p => p.Quiz)
                .WithMany(p => p.Rounds)
                .HasForeignKey(p => p.QuizId);
        }
    }
}