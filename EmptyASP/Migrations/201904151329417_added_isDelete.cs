namespace EmptyASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_isDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Suppliers", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IsDelete");
            DropColumn("dbo.Items", "IsDelete");
        }
    }
}
