using System.Data.Entity.Migrations;

namespace Labs.Pubquiz.Storage.Efw.Migrations
{
    public partial class InitialSetup : DbMigration
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
                "games.Quiz",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    InitiatorId = c.Guid(nullable: false),
                    Start = c.DateTimeOffset(nullable: false, precision: 7),
                    End = c.DateTimeOffset(nullable: false, precision: 7),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "games.Round",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(),
                    QuizId = c.Guid(nullable: false),
                    Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("games.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);

            CreateTable(
                "games.QuizQuestion",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ReferenceId = c.Guid(nullable: false),
                    RoundId = c.Guid(nullable: false),
                    Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("games.Round", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.RoundId);

            CreateTable(
                "games.QuizAnswer",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ReferenceId = c.Guid(nullable: false),
                    QuestionId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("games.QuizQuestion", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);

            CreateTable(
                "games.Pick",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    PlayerId = c.Guid(nullable: false),
                    QuestionId = c.Guid(nullable: false),
                    AnswerId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("games.QuizAnswer", t => t.AnswerId)
                .ForeignKey("games.Player", t => t.PlayerId)
                .ForeignKey("games.QuizQuestion", t => t.QuestionId)
                .Index(t => t.PlayerId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);

            CreateTable(
                "games.Player",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    UserId = c.Guid(nullable: false),
                    Alias = c.String(),
                })
                .PrimaryKey(t => t.Id);

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
            DropForeignKey("games.Round", "QuizId", "games.Quiz");
            DropForeignKey("games.QuizQuestion", "RoundId", "games.Round");
            DropForeignKey("games.QuizAnswer", "QuestionId", "games.QuizQuestion");
            DropForeignKey("games.Pick", "QuestionId", "games.QuizQuestion");
            DropForeignKey("games.Pick", "PlayerId", "games.Player");
            DropForeignKey("games.Pick", "AnswerId", "games.QuizAnswer");
            DropForeignKey("questions.QuestionTag", "TagId", "questions.Tag");
            DropForeignKey("questions.QuestionTag", "QuestionId", "questions.Question");
            DropForeignKey("questions.Tag", "ParentId", "questions.Tag");
            DropForeignKey("questions.Answer", "QuestionId", "questions.Question");
            DropIndex("questions.QuestionTag", new[] {"TagId"});
            DropIndex("questions.QuestionTag", new[] {"QuestionId"});
            DropIndex("games.Pick", new[] {"AnswerId"});
            DropIndex("games.Pick", new[] {"QuestionId"});
            DropIndex("games.Pick", new[] {"PlayerId"});
            DropIndex("games.QuizAnswer", new[] {"QuestionId"});
            DropIndex("games.QuizQuestion", new[] {"RoundId"});
            DropIndex("games.Round", new[] {"QuizId"});
            DropIndex("questions.Tag", new[] {"ParentId"});
            DropIndex("questions.Answer", new[] {"QuestionId"});
            DropTable("questions.QuestionTag");
            DropTable("games.Player");
            DropTable("games.Pick");
            DropTable("games.QuizAnswer");
            DropTable("games.QuizQuestion");
            DropTable("games.Round");
            DropTable("games.Quiz");
            DropTable("questions.Tag");
            DropTable("questions.Answer");
            DropTable("questions.Question");
        }
    }
}