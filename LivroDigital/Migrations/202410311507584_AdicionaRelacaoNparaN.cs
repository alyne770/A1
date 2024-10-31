namespace LivroDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaRelacaoNparaN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "Livro_LivroId", c => c.Int());
            CreateIndex("dbo.Categorias", "Livro_LivroId");
            AddForeignKey("dbo.Categorias", "Livro_LivroId", "dbo.Livroes", "LivroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorias", "Livro_LivroId", "dbo.Livroes");
            DropIndex("dbo.Categorias", new[] { "Livro_LivroId" });
            DropColumn("dbo.Categorias", "Livro_LivroId");
        }
    }
}
