unamespace _03_Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingDataEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampId = c.Int(nullable: false),
                        ReferenceId = c.String(nullable: false, maxLength: 8, unicode: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        BillingAddress = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        CellPhone = c.Long(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CampDataEntity", t => t.CampId, cascadeDelete: true)
                .Index(t => t.CampId)
                .Index(t => t.ReferenceId, unique: true);
            
            CreateTable(
                "dbo.CampDataEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CampRatingDataEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CampDataEntity", t => t.CampId, cascadeDelete: true)
                .Index(t => t.CampId);
            
            CreateTable(
                "dbo.UserDataEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampRatingDataEntity", "CampId", "dbo.CampDataEntity");
            DropForeignKey("dbo.BookingDataEntity", "CampId", "dbo.CampDataEntity");
            DropIndex("dbo.CampRatingDataEntity", new[] { "CampId" });
            DropIndex("dbo.BookingDataEntity", new[] { "ReferenceId" });
            DropIndex("dbo.BookingDataEntity", new[] { "CampId" });
            DropTable("dbo.UserDataEntity");
            DropTable("dbo.CampRatingDataEntity");
            DropTable("dbo.CampDataEntity");
            DropTable("dbo.BookingDataEntity");
        }
    }
}
