namespace KleintechTestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_Id" });
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "PhoneNumber", c => c.String());
            AlterColumn("dbo.People", "Address_Id", c => c.Int());
            CreateIndex("dbo.People", "Address_Id");
            AddForeignKey("dbo.People", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_Id" });
            AlterColumn("dbo.People", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            CreateIndex("dbo.People", "Address_Id");
            AddForeignKey("dbo.People", "Address_Id", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
