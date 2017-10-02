namespace LiveScore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeLeft : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "TimeLeft", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "TimeLeft");
        }
    }
}
