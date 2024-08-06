namespace Token_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_ClientDetails_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientdetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(),
                        ClientSecret = c.String(),
                        ClientName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientdetails");
        }
    }
}
