namespace KleintechTestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address_Id = c.Int(nullable: false),
                        Spouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Spouse_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.Spouse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Spouse_Id", "dbo.People");
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Spouse_Id" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
