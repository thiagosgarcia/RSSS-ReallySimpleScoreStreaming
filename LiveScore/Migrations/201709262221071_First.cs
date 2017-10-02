namespace LiveScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        AwayTeam_Id = c.Int(),
                        HomeTeam_Id = c.Int(),
                        Match_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Matches", t => t.Match_Id)
                .Index(t => t.AwayTeam_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Player1 = c.String(),
                        Player2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.Scores", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Scores", "AwayTeam_Id", "dbo.Teams");
            DropIndex("dbo.Scores", new[] { "Match_Id" });
            DropIndex("dbo.Scores", new[] { "HomeTeam_Id" });
            DropIndex("dbo.Scores", new[] { "AwayTeam_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Scores");
            DropTable("dbo.Matches");
        }
    }
}
