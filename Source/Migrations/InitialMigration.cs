using FluentMigrator;

namespace bsg_crud_app.Migrations;

[Migration(20240307)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(100).NotNullable().Unique()
            .WithColumn("Description").AsString(255).Nullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("CreatedAt").AsCustom("TIMESTAMPTZ")
                .NotNullable()
            .WithColumn("UpdatedAt").AsCustom("TIMESTAMPTZ").Nullable();

        Execute.Sql(@"
            ALTER TABLE ""products""
            ALTER COLUMN ""CreatedAt"" SET DEFAULT CURRENT_TIMESTAMP;
        ");
    }

    public override void Down()
    {
        Delete.Table("products");
    }
}