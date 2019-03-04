namespace FeelMiserable.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class newmigrationexpress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlangStores",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.SlangStores");
        }
    }
}
