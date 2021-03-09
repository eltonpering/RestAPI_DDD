using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS] " +
               "   ([STREET], [NUMBER],[ZIPCODE], [CITY], [STATE], [COUNTRY])    " +
               "VALUES " +
               "   ('Avenida Imigrantes', 1, 88100000, 'Brasília', 'Distrito Federal', 'Brasil')");
            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS] " +
                "   ([STREET], [NUMBER],[ZIPCODE], [CITY], [STATE], [COUNTRY])    " +
                "VALUES " +
                "   ('Rua Gonçalo de Carvalho', 2, 88200000, 'Porto Alegre', 'Rio Grande do Sul', 'Brasil')");
            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS] " +
                "   ([STREET], [NUMBER],[ZIPCODE], [CITY], [STATE], [COUNTRY])    " +
                "VALUES " +
                "   ('Rua das Pedras', 3, 88300000, 'Buzios', 'Rio de Janeiro', 'Brasil')");
            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS] " +
                "   ([STREET], [NUMBER],[ZIPCODE], [CITY], [STATE], [COUNTRY])    " +
                "VALUES " +
                "   ('Avenida Paulista', 4, 88400000, 'São Paulo', 'São Paulo', 'Brasil')");


            mb.Sql("INSERT INTO[dbo].[TB_CUSTOMER] " +
            "   ([Name]) " +
            "VALUES " +
            "   ('José Silva')");
            mb.Sql("INSERT INTO[dbo].[TB_CUSTOMER] " +
            "   ([Name]) " +
            "VALUES " +
            "   ('Maria Perreira')");
            mb.Sql("INSERT INTO[dbo].[TB_CUSTOMER] " +
            "   ([Name]) " +
            "VALUES " +
            "   ('João Santos')");


            mb.Sql("INSERT INTO[dbo].[TB_PHONE_CUSTOMER] " +
                "   ([CustomerId], [PhoneNumber]) " +
                "VALUES " +
                "   (1, 99999999)");
            mb.Sql("INSERT INTO[dbo].[TB_PHONE_CUSTOMER] " +
                "   ([CustomerId], [PhoneNumber]) " +
                "VALUES " +
                "   (1, 11111111)");
            mb.Sql("INSERT INTO[dbo].[TB_PHONE_CUSTOMER] " +
                "   ([CustomerId], [PhoneNumber]) " +
                "VALUES " +
                "   (2, 99999999)");
            mb.Sql("INSERT INTO[dbo].[TB_PHONE_CUSTOMER] " +
                "   ([CustomerId], [PhoneNumber]) " +
                "VALUES " +
                "   (3, 91919191)");

            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS_CUSTOMER] " +
                "   ([CustomerId], [AddressId]) " +
                "VALUES " +
                "   (1, 1)");
            mb.Sql("INSERT INTO[dbo].[TB_ADDRESS_CUSTOMER] " +
                "   ([CustomerId], [AddressId]) " +
                "VALUES " +
                "   (2, 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from tb_address");
            mb.Sql("Delete from tb_phone_customer");
        }
    }
}
