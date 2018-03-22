using System.Data.Entity.Migrations;

namespace EM.Transfer.DAL.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SourceAccountNumber = c.String(nullable: false, maxLength: 26),
                        TargetAccountNumber = c.String(nullable: false, maxLength: 26),
                        MoneyAmount = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Consolidated = c.Boolean(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
