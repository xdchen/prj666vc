namespace prj666vc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class note_20121003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "FileName");
        }
    }
}
