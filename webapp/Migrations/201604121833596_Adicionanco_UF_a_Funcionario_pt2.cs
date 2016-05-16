namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionanco_UF_a_Funcionario_pt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "id_uf", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionarios", "id_uf");
        }
    }
}
