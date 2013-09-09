using System.Data.Entity.Migrations;

namespace Labs.Pubquiz.Storage.Efw.Migrations
{
    public partial class AddQuizEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "games.Quiz",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Name = c.String(),
                             InitiatorId = c.Guid(nullable: false),
                             Start = c.DateTimeOffset(nullable: false),
                             End = c.DateTimeOffset(nullable: false),
                             Status = c.Int(nullable: false),
                         })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "games.Round",
                c => new
                         {
                             Id = c.Guid(nullable: false),
                             Name = c.String(),
                             GameId = c.Guid(nullable: false),
                             Active = c.Boolean(nullable: false),
                             Quiz_Id = c.Guid(),
                         })
                .PrimaryKey(t => t.Id)
                .ForeignKey("games.Quiz", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);

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
                .ForeignKey("games.Player", t => t.PlayerId)
                .ForeignKey("games.QuizQuestion", t => t.QuestionId)
                .ForeignKey("games.QuizAnswer", t => t.AnswerId)
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
        }

        public override void Down()
        {
            DropIndex("games.Pick", new[] {"AnswerId"});
            DropIndex("games.Pick", new[] {"QuestionId"});
            DropIndex("games.Pick", new[] {"PlayerId"});
            DropIndex("games.QuizAnswer", new[] {"QuestionId"});
            DropIndex("games.QuizQuestion", new[] {"RoundId"});
            DropIndex("games.Round", new[] {"Quiz_Id"});
            DropForeignKey("games.Pick", "AnswerId", "games.QuizAnswer");
            DropForeignKey("games.Pick", "QuestionId", "games.QuizQuestion");
            DropForeignKey("games.Pick", "PlayerId", "games.Player");
            DropForeignKey("games.QuizAnswer", "QuestionId", "games.QuizQuestion");
            DropForeignKey("games.QuizQuestion", "RoundId", "games.Round");
            DropForeignKey("games.Round", "Quiz_Id", "games.Quiz");
            DropTable("games.Player");
            DropTable("games.Pick");
            DropTable("games.QuizAnswer");
            DropTable("games.QuizQuestion");
            DropTable("games.Round");
            DropTable("games.Quiz");
        }
    }
}