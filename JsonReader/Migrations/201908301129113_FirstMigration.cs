namespace JsonReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.B2b",
                c => new
                    {
                        B2BId = c.Int(nullable: false, identity: true),
                        ctin = c.String(),
                        cfs = c.String(),
                    })
                .PrimaryKey(t => t.B2BId);
            
            CreateTable(
                "dbo.Invs",
                c => new
                    {
                        InvId = c.Int(nullable: false, identity: true),
                        val = c.Single(nullable: false),
                        inv_typ = c.String(),
                        pos = c.String(),
                        idt = c.String(),
                        rchrg = c.String(),
                        inum = c.String(),
                        chksum = c.String(),
                    })
                .PrimaryKey(t => t.InvId);
            
            CreateTable(
                "dbo.Itms",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        num = c.Int(nullable: false),
                        itm_det_ItemDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Itm_Det", t => t.itm_det_ItemDetailId)
                .Index(t => t.itm_det_ItemDetailId);
            
            CreateTable(
                "dbo.Itm_Det",
                c => new
                    {
                        ItemDetailId = c.Int(nullable: false, identity: true),
                        samt = c.Single(nullable: false),
                        rt = c.Int(nullable: false),
                        txval = c.Single(nullable: false),
                        camt = c.Single(nullable: false),
                        csamt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemDetailId);
            
            CreateTable(
                "dbo.JSONReaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        gstin = c.String(),
                        fp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Itms", "itm_det_ItemDetailId", "dbo.Itm_Det");
            DropIndex("dbo.Itms", new[] { "itm_det_ItemDetailId" });
            DropTable("dbo.JSONReaders");
            DropTable("dbo.Itm_Det");
            DropTable("dbo.Itms");
            DropTable("dbo.Invs");
            DropTable("dbo.B2b");
        }
    }
}
