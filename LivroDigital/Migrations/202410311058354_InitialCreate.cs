namespace LivroDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        DataNascimento = c.DateTime(nullable: false),
                        Nacionalidade = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        AnoPublicacao = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        EditoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LivroId)
                .ForeignKey("dbo.Editoras", t => t.EditoraId, cascadeDelete: true)
                .Index(t => t.ISBN, unique: true)
                .Index(t => t.EditoraId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Editoras",
                c => new
                    {
                        EditoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Cidade = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EditoraId);
            
            CreateTable(
                "dbo.Emprestimoes",
                c => new
                    {
                        EmprestimoId = c.Int(nullable: false, identity: true),
                        LivroId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmprestimoId)
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.LivroId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LivroAutor",
                c => new
                    {
                        LivroId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LivroId, t.AutorId })
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.LivroId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.LivroCategoria",
                c => new
                    {
                        LivroId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LivroId, t.CategoriaId })
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.LivroId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Emprestimoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Emprestimoes", "LivroId", "dbo.Livroes");
            DropForeignKey("dbo.Livroes", "EditoraId", "dbo.Editoras");
            DropForeignKey("dbo.LivroCategoria", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.LivroCategoria", "LivroId", "dbo.Livroes");
            DropForeignKey("dbo.LivroAutor", "AutorId", "dbo.Autors");
            DropForeignKey("dbo.LivroAutor", "LivroId", "dbo.Livroes");
            DropIndex("dbo.LivroCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.LivroCategoria", new[] { "LivroId" });
            DropIndex("dbo.LivroAutor", new[] { "AutorId" });
            DropIndex("dbo.LivroAutor", new[] { "LivroId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Emprestimoes", new[] { "UsuarioId" });
            DropIndex("dbo.Emprestimoes", new[] { "LivroId" });
            DropIndex("dbo.Livroes", new[] { "EditoraId" });
            DropIndex("dbo.Livroes", new[] { "ISBN" });
            DropTable("dbo.LivroCategoria");
            DropTable("dbo.LivroAutor");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Emprestimoes");
            DropTable("dbo.Editoras");
            DropTable("dbo.Categorias");
            DropTable("dbo.Livroes");
            DropTable("dbo.Autors");
        }
    }
}
