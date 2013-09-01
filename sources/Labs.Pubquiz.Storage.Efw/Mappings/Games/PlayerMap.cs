using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Games.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Games
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            // Table & Column Mappings
            ToTable("Player", "games");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}