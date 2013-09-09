using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class QuizQuestionMap : EntityTypeConfiguration<QuizQuestion>
    {
        public QuizQuestionMap()
        {
            // Table & Column Mappings
            ToTable("QuizQuestion", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}