namespace prj666vc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class note_20131002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "PostOwner", c => c.String(nullable: true));
            AlterColumn("dbo.Notes", "Name", c => c.String(nullable: true));
            AlterColumn("dbo.Notes", "CourseCode", c => c.String(nullable: true));
            DropColumn("dbo.Notes", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Owner", c => c.String());
            AlterColumn("dbo.Notes", "CourseCode", c => c.String());
            AlterColumn("dbo.Notes", "Name", c => c.String());
            DropColumn("dbo.Notes", "PostOwner");
        }
    }
}
