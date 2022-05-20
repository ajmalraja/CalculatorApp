namespace CalculatorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalculatorApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculatAppOperationDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstParameter = c.String(),
                        SecondParameter = c.String(),
                        OPerator = c.String(),
                        Result = c.String(),
                        ProcessedIn = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalculatAppOperationDetails");
        }
    }
}
