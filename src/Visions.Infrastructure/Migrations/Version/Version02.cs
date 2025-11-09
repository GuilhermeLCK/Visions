using FluentMigrator;

namespace Visions.Infrastructure.Migrations.Version
{

    [Migration(02, "Criação da tabela Aluno")]

    public class Version02 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Aluno")
             .WithColumn("Nome").AsString(200).NotNullable()
                .WithColumn("Email").AsString(150).NotNullable()
                .WithColumn("Matricula").AsString(50).NotNullable()
                .WithColumn("Curso").AsString(100).NotNullable()
                .WithColumn("Ativo").AsBoolean().NotNullable().WithDefaultValue(true);
        }
    }
}
