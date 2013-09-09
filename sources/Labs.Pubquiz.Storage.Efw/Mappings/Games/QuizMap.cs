using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            // Table & Column Mappings
            ToTable("Quiz", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}