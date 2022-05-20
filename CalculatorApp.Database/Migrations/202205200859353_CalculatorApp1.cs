namespace CalculatorApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalculatorApp1 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.InsertOperationalDetial",
                p => new
                    {
                        FirstParameter = p.String(),
                        SecondParameter = p.String(),
                        OPerator = p.String(),
                        Result = p.String(),
                        ProcessedIn = p.String(),
                    },
                body:
                    @"INSERT [dbo].[CalculatAppOperationDetails]([FirstParameter], [SecondParameter], [OPerator], [Result], [ProcessedIn])
                      VALUES (@FirstParameter, @SecondParameter, @OPerator, @Result, @ProcessedIn)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[CalculatAppOperationDetails]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[CalculatAppOperationDetails] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateOperationalDetial",
                p => new
                    {
                        ID = p.Int(),
                        FirstParameter = p.String(),
                        SecondParameter = p.String(),
                        OPerator = p.String(),
                        Result = p.String(),
                        ProcessedIn = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[CalculatAppOperationDetails]
                      SET [FirstParameter] = @FirstParameter, [SecondParameter] = @SecondParameter, [OPerator] = @OPerator, [Result] = @Result, [ProcessedIn] = @ProcessedIn
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteOperationalDetial",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CalculatAppOperationDetails]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteOperationalDetial");
            DropStoredProcedure("dbo.UpdateOperationalDetial");
            DropStoredProcedure("dbo.InsertOperationalDetial");
        }
    }
}
