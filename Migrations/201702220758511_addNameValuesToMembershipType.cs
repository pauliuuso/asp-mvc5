namespace aspnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameValuesToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET name='Pay as you go' WHERE id=1");
            Sql("UPDATE MembershipTypes SET name='Monthly' WHERE id=2");
            Sql("UPDATE MembershipTypes SET name='Quaterly' WHERE id=3");
            Sql("UPDATE MembershipTypes SET name='Yearly' WHERE id=4");
        }
        
        public override void Down()
        {
        }
    }
}
