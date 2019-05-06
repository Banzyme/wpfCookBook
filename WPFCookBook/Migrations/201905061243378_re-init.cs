namespace WPFCookBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WpfCourseModule",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WpfCourseSectionItem",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Subtitle = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WpfCourseSection",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WpfCourseSection");
            DropTable("dbo.WpfCourseSectionItem");
            DropTable("dbo.WpfCourseModule");
        }
    }
}
