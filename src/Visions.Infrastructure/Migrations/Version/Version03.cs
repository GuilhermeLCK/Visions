using FluentMigrator;

namespace Visions.Infrastructure.Migrations.Version
{

    [Migration(03, "Criação da tabela Emprestimo")]

    public class Version03 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Emprestimo")
             .WithColumn("AlunoId").AsInt64().NotNullable()
             .WithColumn("LivroId").AsInt64().NotNullable()
             .WithColumn("DataEmprestimo").AsDateTime().NotNullable()
             .WithColumn("DataPrevistaDevolucao").AsDateTime().NotNullable()
             .WithColumn("DataDevolucaoReal").AsDateTime().Nullable()
             .WithColumn("Status").AsByte().NotNullable();


            Create.ForeignKey("FK_Emprestimo_Aluno")
                .FromTable("Emprestimo").ForeignColumn("AlunoId")
                .ToTable("Aluno").PrimaryColumn("Id");

            Create.ForeignKey("FK_Emprestimo_Livro")
                .FromTable("Emprestimo").ForeignColumn("LivroId")
                .ToTable("Livro").PrimaryColumn("Id");
        }
    }
}
