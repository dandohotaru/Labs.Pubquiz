namespace Labs.Pubquiz.Storage.Efw.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaptRoundKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("games.Round", "Quiz_Id", "games.Quiz");
            DropIndex("games.Round", new[] { "Quiz_Id" });
            RenameColumn(table: "games.Round", name: "Quiz_Id", newName: "QuizId");
            AddForeignKey("games.Round", "QuizId", "games.Quiz", "Id", cascadeDelete: true);
            CreateIndex("games.Round", "QuizId");
            DropColumn("games.Round", "GameId");
        }
        
        public override void Down()
        {
            AddColumn("games.Round", "GameId", c => c.Guid(nullable: false));
            DropIndex("games.Round", new[] { "QuizId" });
            DropForeignKey("games.Round", "QuizId", "games.Quiz");
            RenameColumn(table: "games.Round", name: "QuizId", newName: "Quiz_Id");
            CreateIndex("games.Round", "Quiz_Id");
            AddForeignKey("games.Round", "Quiz_Id", "games.Quiz", "Id");
        }
    }
}
