namespace VixEng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campoEmailUnico : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Funcionarios", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Funcionarios", new[] { "email" });
        }
    }
}
