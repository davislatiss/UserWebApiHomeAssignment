namespace KleintechTestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Married : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Married", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Married");
        }
    }
}
