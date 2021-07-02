namespace KleintectTestTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Struct : DbMigration
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
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Married = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                        Spouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.People", t => t.Spouse_Id)
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
