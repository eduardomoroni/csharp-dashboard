namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Voltando_campoEmail_nao_Unico : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Funcionarios", new[] { "email" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Funcionarios", "email", unique: true);
        }
    }
}
