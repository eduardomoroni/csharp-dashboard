namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Beneficios", "id_funcionario", "dbo.Funcionarios");
            DropForeignKey("dbo.Documentos", "id_funcionario", "dbo.Funcionarios");
            AddForeignKey("dbo.Beneficios", "id_funcionario", "dbo.Funcionarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.Documentos", "id_funcionario", "dbo.Funcionarios", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentos", "id_funcionario", "dbo.Funcionarios");
            DropForeignKey("dbo.Beneficios", "id_funcionario", "dbo.Funcionarios");
            AddForeignKey("dbo.Documentos", "id_funcionario", "dbo.Funcionarios", "id");
            AddForeignKey("dbo.Beneficios", "id_funcionario", "dbo.Funcionarios", "id");
        }
    }
}
