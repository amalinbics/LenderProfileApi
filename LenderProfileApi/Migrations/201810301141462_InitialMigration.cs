namespace LenderProfileApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        MobileNo = c.String(nullable: false, maxLength: 12),
                        AlternateMobileNo = c.String(maxLength: 12),
                        Address = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnnualIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CibilScoreId = c.Byte(nullable: false),
                        LoanAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TenureInMonths = c.Byte(nullable: false),
                        RateOfInterest = c.Double(nullable: false),
                        EMI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LenderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CibilScores", t => t.CibilScoreId, cascadeDelete: true)
                .ForeignKey("dbo.Lenders", t => t.LenderId, cascadeDelete: true)
                .Index(t => t.CibilScoreId)
                .Index(t => t.LenderId);
            
            CreateTable(
                "dbo.CibilScores",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Score = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LenderId", "dbo.Lenders");
            DropForeignKey("dbo.Loans", "CibilScoreId", "dbo.CibilScores");
            DropIndex("dbo.Loans", new[] { "LenderId" });
            DropIndex("dbo.Loans", new[] { "CibilScoreId" });
            DropTable("dbo.CibilScores");
            DropTable("dbo.Loans");
            DropTable("dbo.Lenders");
        }
    }
}
