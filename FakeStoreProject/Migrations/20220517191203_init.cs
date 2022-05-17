using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeStoreProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "varchar(255)", nullable: false),
                    City = table.Column<string>(type: "varchar(255)", nullable: false),
                    PostCode = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    ListPrice = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ItemOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Reykjavik", "101", "Store Street" },
                    { 2, "New York", "NY505", "Customer Street" },
                    { 3, "Copehagen", "CP808", "Danish Streen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Summer" },
                    { 2, "Bedroom" },
                    { 3, "Living Room" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "FirstName", "LastName" },
                values: new object[] { 1, 2, "Bob", "Customer" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ProductsId", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 10, 1 },
                    { 2, 2, 13, 1 },
                    { 3, 3, 0, 1 },
                    { 4, 4, 50, 1 },
                    { 5, 5, 22, 1 },
                    { 6, 6, 4, 1 },
                    { 7, 7, 3, 1 },
                    { 8, 8, 10, 1 },
                    { 9, 9, 15, 1 },
                    { 10, 11, 25, 1 },
                    { 11, 12, 60, 1 },
                    { 12, 13, 1, 1 },
                    { 13, 14, 7, 1 },
                    { 14, 15, 9, 1 },
                    { 15, 16, 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "Email", "Name", "Phone" },
                values: new object[] { 1, 1, "Fakestore@fakestore.com", "FakeStore", "444-5555" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "ItemOrderId", "StoreId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImgUrl", "ListPrice", "ModelYear", "Name", "StockId" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sit amet nisi lacus. Aenean eget felis tempor, blandit velit vel, dictum est. Vestibulum sed diam vulputate, commodo ligula aliquet, dictum mauris. Nullam imperdiet elementum nisi, a venenatis nulla tempus quis. Sed tempor gravida felis. Cras porttitor eleifend auctor. ", "https://media.istockphoto.com/photos/deck-chair-picture-id918244930", 100, 2000, "Summer Chair", 1 },
                    { 2, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat.", "https://media.istockphoto.com/photos/patio-table-set-picture-id903469302", 500, 2004, "Outdoor set", 2 },
                    { 3, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim.", "https://media.istockphoto.com/photos/table-and-chairs-picture-id645618262", 670, 1990, "Table Set", 3 },
                    { 4, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim.", "https://media.istockphoto.com/photos/parasol-picture-id187264061", 400, 1980, "Summer Parasol", 4 },
                    { 5, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim", "https://media.istockphoto.com/photos/gardening-lounge-chair-picture-id182403766", 100, 2000, "Lounge Chair", 5 },
                    { 6, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", "https://media.istockphoto.com/photos/ornamental-plant-with-pink-petunia-flowers-on-a-large-traditional-picture-id1154401941", 250, 2006, "Plant Pot", 6 },
                    { 7, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", "https://media.istockphoto.com/photos/blue-wooden-dresser-isolated-on-white-background-picture-id1162304784", 500, 2018, "Blue Drawer", 7 },
                    { 8, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", "https://media.istockphoto.com/photos/bed-isolated-on-white-3-picture-id173698682", 800, 2010, "Oak Bed", 8 },
                    { 9, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", "https://media.istockphoto.com/photos/brown-vintage-wooden-drawer-isolated-on-white-background-with-path-picture-id947145084", 250, 2000, "Brown Drawer", 9 },
                    { 10, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/sofa-picture-id173240457", 699, 2002, "White Sofa", 10 },
                    { 11, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/white-sofa-with-pillows-picture-id519463114", 799, 1988, "Gray Sofa", 11 },
                    { 12, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/old-retro-sixties-style-chair-in-blue-picture-id933712184", 399, 2000, "Classic Chair", 12 },
                    { 13, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/side-table-picture-id179599149", 200, 2022, "Side Table", 13 },
                    { 14, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/dark-gray-living-rolled-top-club-chair-picture-id939688452", 350, 1989, "Gray Chair", 14 },
                    { 15, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", "https://media.istockphoto.com/photos/sofa-picture-id642715652", 599, 2015, "Small Sofa", 15 }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "FirstName", "LastName", "ManagerId", "StaffId", "StoreId" },
                values: new object[] { 1, "Bob", "Staffmann", 0, null, 1 });

            migrationBuilder.InsertData(
                table: "ItemsOrders",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[] { 1, 1, 1, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsOrders_ProductId",
                table: "ItemsOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffId",
                table: "Staffs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StoreId",
                table: "Staffs",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ItemsOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
