using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Table & Column Mappings
            ToTable("Question", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}