namespace LivroDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaRelacaoNparNLivroAutores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autors", "Livro_LivroId", c => c.Int());
            CreateIndex("dbo.Autors", "Livro_LivroId");
            AddForeignKey("dbo.Autors", "Livro_LivroId", "dbo.Livroes", "LivroId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Autors", "Livro_LivroId", "dbo.Livroes");
            DropIndex("dbo.Autors", new[] { "Livro_LivroId" });
            DropColumn("dbo.Autors", "Livro_LivroId");
        }
    }
}
