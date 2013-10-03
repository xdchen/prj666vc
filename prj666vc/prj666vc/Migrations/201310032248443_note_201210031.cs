namespace prj666vc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class note_201210031 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Status");
        }
    }
}
