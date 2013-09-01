using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Questions
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            // Table & Column Mappings
            ToTable("Answer", "questions");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.QuestionId).HasColumnName("QuestionId");

            // Relationships
            HasRequired(t => t.Question)
                .WithMany(t => t.Answers)
                .HasForeignKey(d => d.QuestionId);
        }
    }
}