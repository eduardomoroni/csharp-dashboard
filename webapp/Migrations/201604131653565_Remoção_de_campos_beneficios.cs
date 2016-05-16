namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remoção_de_campos_beneficios : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Beneficios", "mes");
            DropColumn("dbo.Beneficios", "ano");
            DropColumn("dbo.Beneficios", "data_pagamento");
            DropColumn("dbo.Beneficios", "quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beneficios", "quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.Beneficios", "data_pagamento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Beneficios", "ano", c => c.Int(nullable: false));
            AddColumn("dbo.Beneficios", "mes", c => c.Int(nullable: false));
        }
    }
}
