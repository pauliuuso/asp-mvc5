namespace aspnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "birthday");
        }
    }
}
