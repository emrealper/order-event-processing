using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Persistance.Migrations
{
    public partial class ManualDataMigration_For_FullTextSearch_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string queryToCreateFullTextCatalog = "CREATE FULLTEXT CATALOG [OrderFTCat] WITH ACCENT_SENSITIVITY = ON;";
            string queryToAddFullTextIndexOnOrder = "CREATE FULLTEXT INDEX ON [dbo].[Order]" +
                                                    $" ([CustomerFullName] LANGUAGE 'Neutral')" +
                                                    $" KEY INDEX[PK_Order] ON([OrderFTCat], FILEGROUP[PRIMARY])" +
                                                    $" WITH(CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM);";

            string queryToAddFullTextIndexOnOrderItem = "CREATE FULLTEXT INDEX ON [dbo].[OrderItem]" +
                                                        $" ([LongDescription] LANGUAGE 'Neutral')" +
                                                        $" KEY INDEX[PK_OrderItem] ON([OrderFTCat], FILEGROUP[PRIMARY])" +
                                                        $" WITH(CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM);";

            //Create FullTextCatalog
            migrationBuilder.Sql(queryToCreateFullTextCatalog, suppressTransaction: true);
            //Create FullTextIndex on Order table
            migrationBuilder.Sql(queryToAddFullTextIndexOnOrder, suppressTransaction: true);
            //Create FullTextIndex on OrderItem table
            migrationBuilder.Sql(queryToAddFullTextIndexOnOrderItem, suppressTransaction: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
