using System.Data.Entity.Migrations;

namespace Labs.Pubquiz.Storage.Efw.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "questions.Question",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Text = c.String(),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "questions.Answer",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Index = c.Int(nullable: false),
                             Text = c.String(),
                             QuestionId = c.Guid(nullable: false),
                             Correct = c.Boolean(nullable: false),
                         })
                .PrimaryKey(t => t.Id)
                .ForeignKey("questions.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);

            CreateTable(
                "questions.Tag",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Name = c.String(nullable: false, maxLength: 100),
                             ParentId = c.Guid(),
                         })
                .PrimaryKey(t => t.Id)
                .ForeignKey("questions.Tag", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "questions.QuestionTag",
                c => new
                         {
                             QuestionId = c.Guid(nullable: false),
                             TagId = c.Guid(nullable: false),
                         })
                .PrimaryKey(t => new {t.QuestionId, t.TagId})
                .ForeignKey("questions.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("questions.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.TagId);
        }

        public override void Down()
        {
            DropIndex("questions.QuestionTag", new[] {"TagId"});
            DropIndex("questions.QuestionTag", new[] {"QuestionId"});
            DropIndex("questions.Tag", new[] {"ParentId"});
            DropIndex("questions.Answer", new[] {"QuestionId"});
            DropForeignKey("questions.QuestionTag", "TagId", "questions.Tag");
            DropForeignKey("questions.QuestionTag", "QuestionId", "questions.Question");
            DropForeignKey("questions.Tag", "ParentId", "questions.Tag");
            DropForeignKey("questions.Answer", "QuestionId", "questions.Question");
            DropTable("questions.QuestionTag");
            DropTable("questions.Tag");
            DropTable("questions.Answer");
            DropTable("questions.Question");
        }
    }
}