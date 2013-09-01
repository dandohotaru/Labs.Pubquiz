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
        }
    }
}