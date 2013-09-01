using System.Data.Entity.ModelConfiguration;
using Labs.Pubquiz.Domain.Security.Entities;

namespace Labs.Pubquiz.Storage.Efw.Mappings.Security
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Table & Column Mappings
            ToTable("Role", "security");

            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}