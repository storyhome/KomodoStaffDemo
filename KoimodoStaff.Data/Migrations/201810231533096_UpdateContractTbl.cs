namespace KoimodoStaff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contract", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.Contract", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Developer", "FirstName", c => c.String());
            CreateIndex("dbo.Contract", "DeveloperId");
            CreateIndex("dbo.Contract", "TeamId");
            AddForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer", "DeveloperId", cascadeDelete: true);
            AddForeignKey("dbo.Contract", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            DropColumn("dbo.Contract", "dateTime");
            DropColumn("dbo.Developer", "FristName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Developer", "FristName", c => c.String());
            AddColumn("dbo.Contract", "dateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Contract", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Contract", "DeveloperId", "dbo.Developer");
            DropIndex("dbo.Contract", new[] { "TeamId" });
            DropIndex("dbo.Contract", new[] { "DeveloperId" });
            DropColumn("dbo.Developer", "FirstName");
            DropColumn("dbo.Contract", "EndDate");
            DropColumn("dbo.Contract", "TeamId");
        }
    }
}
