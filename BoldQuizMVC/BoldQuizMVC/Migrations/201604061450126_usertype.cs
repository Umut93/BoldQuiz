namespace BoldQuizMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "user_type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "user_type");
        }
    }
}
