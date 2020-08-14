namespace SnakeMiro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vytvorenie_databazy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypHry = c.Boolean(nullable: false),
                        Skore = c.Int(nullable: false),
                        Pouzivatel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pouzivatels", t => t.Pouzivatel_Id, cascadeDelete: true)
                .Index(t => t.Pouzivatel_Id);
            
            CreateTable(
                "dbo.Pouzivatels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Meno = c.String(),
                        Heslo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hras", "Pouzivatel_Id", "dbo.Pouzivatels");
            DropIndex("dbo.Hras", new[] { "Pouzivatel_Id" });
            DropTable("dbo.Pouzivatels");
            DropTable("dbo.Hras");
        }
    }
}
