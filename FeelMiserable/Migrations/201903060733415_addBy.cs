namespace FeelMiserable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlangStores", "AddedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlangStores", "AddedBy");
        }
    }
}
