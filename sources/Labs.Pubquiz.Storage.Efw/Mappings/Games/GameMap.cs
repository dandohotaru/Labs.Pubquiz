using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Table & Column Mappings
            ToTable("Game", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}