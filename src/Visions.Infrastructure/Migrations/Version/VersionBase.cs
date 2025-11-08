using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visions.Infrastructure.Migrations.Version
{
   public abstract class VersionBase : ForwardOnlyMigration
    {
        protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable( string table)
        {
           return Create.Table(table)
           .WithColumn("Id").AsInt64().PrimaryKey().Identity()
           .WithColumn("Inclusao").AsDateTime().NotNullable().WithDefaultValue(DateTime.UtcNow);        
        }
    }
}
