using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "imagen_TortilladePapas ", "Papa,Chorizo colorado,Huevos,Cebolla,Queso", "Tortilla de papas", 800, " Para preparar tortilla de papas: freír papas y cebolla en aceite, mezclar con huevo batido, sazonar, verter en sartén, cocinar a fuego medio-bajo hasta dorar por ambos lados, retirar de la sartén y dejar enfriar.", 1 },
                    { 2, "imagen_NachosConQueso", "Naachos,Queso cheddar,Tomate,Verdeo,Guacamole", "Nachos con queso y guacamole", 600, "colocar nachos en una bandeja, agregar queso rallado, hornear a 180°C por unos minutos hasta que el queso se derrita, retirar del horno y servir con salsa y guacamole.", 1 },
                    { 3, "imagen_MilanesasPapasFritas", "Milanesas de peceto y papas", "Milanesas con papa fritas", 1500, "pasar la carne por huevo batido y pan rallado, freír en aceite caliente hasta dorar ambos lados, acompañar con papas fritas previamente cortadas y fritas en aceite caliente, escurrir el exceso de aceite y servir caliente con limón y/o salsa al gusto.", 2 },
                    { 4, "imagen_MilanesasNapoPapasFritas", "Milanesas de peceto y papas", "Milanesas napolitana con papa fritas", 1500, "Para preparar milanesas napolitanas con papas fritas, sigue los pasos para las milanesas simples. Después de freír las milanesas, cúbrelas con salsa de tomate y queso mozzarella rallado. Hornea durante 5-7 minutos o hasta que el queso se derrita. ", 2 },
                    { 5, "imagen_SpaghettiScarparo", "Crema. oliva, ajo, verdeo, pomodoro fresco y pesto genovés", "Spaghetti Scarparo", 2400, "saltear ajo y ají en aceite, agregar tomate, aceitunas, alcaparras y vino, cocinar salsa. Cocer spaghetti, mezclar con salsa y servir con queso y perejil.", 3 },
                    { 6, "imagen_SorrentinosPannaDiChampignones", "Sorrentinos,Crema, ajo, Champignones y jerez", "Sorrentinos Panna di Champignones", 2900, "cocinar sorrentinos en agua hirviendo con sal, saltear champiñones en aceite con ajo y cebolla, agregar crema de leche y cocinar hasta espesar, mezclar con los sorrentinos y servir con queso rallado y perejil", 3 },
                    { 7, "imagen_BifeDeChorizo", "Bife de Chorizo y acompañamiento", "Bife de Chorizo. C/ Papas o Ensalada", 3000, "salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.", 4 },
                    { 8, "imagen_TapaDeAsado", "Tapa de Asado y acompañamiento", "Tapa de Asado. C/ Papas o Ensalada", 2800, "Salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.", 4 },
                    { 9, "imagen_PizzaMuzzarella", "Pizza con salsa y muzaarella", "Pizza Muzzarella", 2000, "Estirar la masa de pizza, agregar salsa de tomate, colocar mozzarella en rodajas, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con orégano y/o aceitunas al gusto.", 5 },
                    { 10, "imagen_Fugazzeta", "Fugazzeta con cebolla,morron, jamon y queso", "Fugazzeta", 3000, "Estirar la masa de pizza, agregar cebolla en rodajas y queso rallado, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con aceitunas y/o salsa criolla al gusto.", 5 },
                    { 11, "imagen_SandwichMilanesasPapasFritas", "Milanesa de carne y papas fritas", "Sandwich de Milanesa con Papas Fritas", 2000, "Cocinar la milanesa empanizada en aceite caliente hasta dorar, armar el sandwich con pan, lechuga, tomate y mayonesa, acompañar con papas fritas hechas en aceite caliente y servir caliente.", 6 },
                    { 12, "imagen_SandwichBondiola", "Bondiola,Queso Provolone,Cebolla Caramelizada", "Sandwich de Bondiola", 2000, "Marinar la carne con hierbas y especias, sellar en una sartén caliente con aceite hasta dorar, cocinar en horno a 180°C durante 45-60 minutos, retirar del horno y dejar reposar, cortar en rodajas y servir caliente con guarnición de verduras al gusto. ", 6 },
                    { 13, "imagen_EnsaladaCesar", "Lechuga romana,Queso parmesano rallado,Croutones,Salsa César (mayonesa, ajo, jugo de limón, mostaza Dijon, anchoas y queso parmesano rallado)", "Ensalda Cesar", 1200, "Mezclar lechuga romana, pollo asado en trozos, pan tostado y queso parmesano rallado, aderezar con salsa césar (mayonesa, ajo, mostaza, anchoas, jugo de limón y parmesano) y servir frío.", 7 },
                    { 14, "imagen_EnsaladaRusa", "Papas cocidas y cortadas en cubitos,Zanahorias cocidas y cortadas en cubitos,Guisantes o arvejas cocidas,Mayonesa,Sal y pimienta al gusto", "Ensalda Rusa", 900, "Cocer papas y zanahorias, pelar y cortar en cubos junto con arvejas cocidas y huevo duro, mezclar con mayonesa, sal y pimienta al gusto, enfriar en nevera durante 1 hora y servir frío. ", 7 },
                    { 15, "imagen_CocaCola", "Coca Cola 650ml ", "Coca Cola ", 500, "Coca Cola en botella", 8 },
                    { 16, "imagen_AguaMineral", "Agua Mineral 1lt ", "Agua Mineral", 500, "Agua Mineral en botella", 8 },
                    { 17, "imagen_CervezaIpa", "Malta base,Malta especial ,Lúpulo,Agua,Levadura", "Cerveza IPA", 900, "Mezclar agua caliente con malta, lúpulo y levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.", 9 },
                    { 18, "imagen_CervezaHoney", "Malta base,Malta especial ,Lúpulo,Agua,Levadura", "Cerveza Honey", 900, "mezclar agua caliente con malta, lúpulo y miel, agregar levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.", 9 },
                    { 19, "imagen_Flan", "Huevos,Leche,Azúcar,Esencia de vainilla o ralladura de limón,Caramelo", "Flan C/Dulce o Crema", 1200, "Mezclar leche, huevos, azúcar y esencia de vainilla, verter en un molde acaramelado, cocinar a baño maría en el horno hasta que esté firme, enfriar en nevera y desmoldar antes de servir.", 10 },
                    { 20, "imagen_Helado", "Helado sabor a eleccion(3 bochas)", "Helado", 1500, "Bochas de Helado", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
