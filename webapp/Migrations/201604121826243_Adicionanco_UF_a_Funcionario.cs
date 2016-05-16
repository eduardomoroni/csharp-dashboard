namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionanco_UF_a_Funcionario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "UF_id", c => c.Long());
            CreateIndex("dbo.Funcionarios", "UF_id");
            AddForeignKey("dbo.Funcionarios", "UF_id", "dbo.UF", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "UF_id", "dbo.UF");
            DropIndex("dbo.Funcionarios", new[] { "UF_id" });
            DropColumn("dbo.Funcionarios", "UF_id");
        }
    }
}
