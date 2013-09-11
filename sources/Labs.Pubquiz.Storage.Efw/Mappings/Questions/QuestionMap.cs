using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Questions.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Questions
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Table & Column Mappings
            ToTable("Question", "questions");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");

            // Relationships
            HasOptional(t => t.Answers);

            HasMany(t => t.Tags)
                .WithMany()
                .Map(m =>
                         {
                             m.ToTable("QuestionTag", "questions");
                             m.MapLeftKey("QuestionId");
                             m.MapRightKey("TagId");
                         });
        }
    }
}