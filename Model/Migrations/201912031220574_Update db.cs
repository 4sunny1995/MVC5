namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblUser", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUser", "Status", c => c.Boolean());
        }
    }
}
