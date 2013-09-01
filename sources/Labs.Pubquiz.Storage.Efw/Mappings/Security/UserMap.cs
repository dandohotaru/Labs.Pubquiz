using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Security.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Security
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Table & Column Mappings
            ToTable("User", "security");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}