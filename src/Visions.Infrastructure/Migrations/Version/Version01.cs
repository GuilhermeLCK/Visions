using FluentMigrator;

namespace Visions.Infrastructure.Migrations.Version
{
    [Migration(01, "Criação da tabela Livro")]
    public class Version01 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Livro")
            .WithColumn("Titulo").AsString(255).NotNullable()
            .WithColumn("Autor").AsString(255).NotNullable()
            .WithColumn("ISBN").AsString(13).NotNullable()
            .WithColumn("AnoPublicacao").AsInt32().NotNullable()
            .WithColumn("Categoria").AsString(100).NotNullable()
            .WithColumn("QuantidadeTotal").AsInt32().NotNullable()
            .WithColumn("QuantidadeDisponivel").AsInt32().NotNullable();
        }
    }
}
