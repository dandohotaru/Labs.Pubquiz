using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Table & Column Mappings
            ToTable("Answer", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}