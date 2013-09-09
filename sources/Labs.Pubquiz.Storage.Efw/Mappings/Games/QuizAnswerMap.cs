using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class QuizAnswerMap : EntityTypeConfiguration<QuizAnswer>
    {
        public QuizAnswerMap()
        {
            // Table & Column Mappings
            ToTable("QuizAnswer", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}