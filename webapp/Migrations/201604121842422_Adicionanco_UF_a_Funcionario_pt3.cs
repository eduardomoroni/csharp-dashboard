namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionanco_UF_a_Funcionario_pt3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Funcionarios", "id_uf");
            RenameColumn(table: "dbo.Funcionarios", name: "UF_id", newName: "id_uf");
            RenameIndex(table: "dbo.Funcionarios", name: "IX_UF_id", newName: "IX_id_uf");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Funcionarios", name: "IX_id_uf", newName: "IX_UF_id");
            RenameColumn(table: "dbo.Funcionarios", name: "id_uf", newName: "UF_id");
            AddColumn("dbo.Funcionarios", "id_uf", c => c.Long());
        }
    }
}
