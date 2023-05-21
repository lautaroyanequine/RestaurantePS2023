using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;

namespace Infraestructure.Persistence.DataRestaurante
{
    public class MercaderiaData
    {
        public MercaderiaData(EntityTypeBuilder<Mercaderia> entityBuilder)
        {
            entityBuilder.HasData(
                new Mercaderia
                {

                    MercaderiaId = 1,
                    Nombre = "Tortilla de papas",
                    TipoMercaderiaId = 1,
                    Precio = 800,
                    Ingredientes = "Papa,Chorizo colorado,Huevos,Cebolla,Queso",
                    Preparacion = " Para preparar tortilla de papas: freír papas y cebolla en aceite, mezclar con huevo batido, sazonar, verter en sartén, cocinar a fuego medio-bajo hasta dorar por ambos lados, retirar de la sartén y dejar enfriar.",
                    Imagen = "imagen_TortilladePapas "
                },
                new Mercaderia
                {
                    MercaderiaId = 2,
                    Nombre = "Nachos con queso y guacamole",
                    TipoMercaderiaId = 1,
                    Precio = 600,
                    Ingredientes = "Naachos,Queso cheddar,Tomate,Verdeo,Guacamole",
                    Preparacion = "colocar nachos en una bandeja, agregar queso rallado, hornear a 180°C por unos minutos hasta que el queso se derrita, retirar del horno y servir con salsa y guacamole.",
                    Imagen = "imagen_NachosConQueso"
                },
                new Mercaderia
                {
                    MercaderiaId = 3,
                    Nombre = "Milanesas con papa fritas",
                    TipoMercaderiaId = 2,
                    Precio = 1500,
                    Ingredientes = "Milanesas de peceto y papas",
                    Preparacion = "pasar la carne por huevo batido y pan rallado, freír en aceite caliente hasta dorar ambos lados, acompañar con papas fritas previamente cortadas y fritas en aceite caliente, escurrir el exceso de aceite y servir caliente con limón y/o salsa al gusto.",
                    Imagen = "imagen_MilanesasPapasFritas"
                },
                new Mercaderia
                {
                    MercaderiaId = 4,
                    Nombre = "Milanesas napolitana con papa fritas",
                    TipoMercaderiaId = 2,
                    Precio = 1500,
                    Ingredientes = "Milanesas de peceto y papas",
                    Preparacion = "Para preparar milanesas napolitanas con papas fritas, sigue los pasos para las milanesas simples. Después de freír las milanesas, cúbrelas con salsa de tomate y queso mozzarella rallado. Hornea durante 5-7 minutos o hasta que el queso se derrita. ",
                    Imagen = "imagen_MilanesasNapoPapasFritas"
                },
                new Mercaderia
                {
                    MercaderiaId = 5,
                    Nombre = "Spaghetti Scarparo",
                    TipoMercaderiaId = 3,
                    Precio = 2400,
                    Ingredientes = "Crema. oliva, ajo, verdeo, pomodoro fresco y pesto genovés",
                    Preparacion = "saltear ajo y ají en aceite, agregar tomate, aceitunas, alcaparras y vino, cocinar salsa. Cocer spaghetti, mezclar con salsa y servir con queso y perejil.",
                    Imagen = "imagen_SpaghettiScarparo"
                },
                new Mercaderia
                {

                    MercaderiaId = 6,
                    Nombre = "Sorrentinos Panna di Champignones",
                    TipoMercaderiaId = 3,
                    Precio = 2900,
                    Ingredientes = "Sorrentinos,Crema, ajo, Champignones y jerez",
                    Preparacion = "cocinar sorrentinos en agua hirviendo con sal, saltear champiñones en aceite con ajo y cebolla, agregar crema de leche y cocinar hasta espesar, mezclar con los sorrentinos y servir con queso rallado y perejil",
                    Imagen = "imagen_SorrentinosPannaDiChampignones"
                },
                new Mercaderia
                {
                    MercaderiaId = 7,
                    Nombre = "Bife de Chorizo. C/ Papas o Ensalada",
                    TipoMercaderiaId = 4,
                    Precio = 3000,
                    Ingredientes = "Bife de Chorizo y acompañamiento",
                    Preparacion = "salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.",
                    Imagen = "imagen_BifeDeChorizo"
                },
                 new Mercaderia
                 {
                     MercaderiaId = 8,
                     Nombre = "Tapa de Asado. C/ Papas o Ensalada",
                     TipoMercaderiaId = 4,
                     Precio = 2800,
                     Ingredientes = "Tapa de Asado y acompañamiento",
                     Preparacion = "Salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.",
                     Imagen = "imagen_TapaDeAsado"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 9,
                     Nombre = "Pizza Muzzarella",
                     TipoMercaderiaId = 5,
                     Precio = 2000,
                     Ingredientes = "Pizza con salsa y muzaarella",
                     Preparacion = "Estirar la masa de pizza, agregar salsa de tomate, colocar mozzarella en rodajas, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con orégano y/o aceitunas al gusto.",
                     Imagen = "imagen_PizzaMuzzarella"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 10,
                     Nombre = "Fugazzeta",
                     TipoMercaderiaId = 5,
                     Precio = 3000,
                     Ingredientes = "Fugazzeta con cebolla,morron, jamon y queso",
                     Preparacion = "Estirar la masa de pizza, agregar cebolla en rodajas y queso rallado, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con aceitunas y/o salsa criolla al gusto.",
                     Imagen = "imagen_Fugazzeta"
                 },
                 new Mercaderia
                 {

                     MercaderiaId = 11,
                     Nombre = "Sandwich de Milanesa con Papas Fritas",
                     TipoMercaderiaId = 6,
                     Precio = 2000,
                     Ingredientes = "Milanesa de carne y papas fritas",
                     Preparacion = "Cocinar la milanesa empanizada en aceite caliente hasta dorar, armar el sandwich con pan, lechuga, tomate y mayonesa, acompañar con papas fritas hechas en aceite caliente y servir caliente.",
                     Imagen = "imagen_SandwichMilanesasPapasFritas"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 12,
                     Nombre = "Sandwich de Bondiola",
                     TipoMercaderiaId = 6,
                     Precio = 2000,
                     Ingredientes = "Bondiola,Queso Provolone,Cebolla Caramelizada",
                     Preparacion = "Marinar la carne con hierbas y especias, sellar en una sartén caliente con aceite hasta dorar, cocinar en horno a 180°C durante 45-60 minutos, retirar del horno y dejar reposar, cortar en rodajas y servir caliente con guarnición de verduras al gusto. ",
                     Imagen = "imagen_SandwichBondiola"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 13,
                     Nombre = "Ensalda Cesar",
                     TipoMercaderiaId = 7,
                     Precio = 1200,
                     Ingredientes = "Lechuga romana,Queso parmesano rallado,Croutones,Salsa César (mayonesa, ajo, jugo de limón, mostaza Dijon, anchoas y queso parmesano rallado)",
                     Preparacion = "Mezclar lechuga romana, pollo asado en trozos, pan tostado y queso parmesano rallado, aderezar con salsa césar (mayonesa, ajo, mostaza, anchoas, jugo de limón y parmesano) y servir frío.",
                     Imagen = "imagen_EnsaladaCesar"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 14,
                     Nombre = "Ensalda Rusa",
                     TipoMercaderiaId = 7,
                     Precio = 900,
                     Ingredientes = "Papas cocidas y cortadas en cubitos,Zanahorias cocidas y cortadas en cubitos,Guisantes o arvejas cocidas,Mayonesa,Sal y pimienta al gusto",
                     Preparacion = "Cocer papas y zanahorias, pelar y cortar en cubos junto con arvejas cocidas y huevo duro, mezclar con mayonesa, sal y pimienta al gusto, enfriar en nevera durante 1 hora y servir frío. ",
                     Imagen = "imagen_EnsaladaRusa"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 15,
                     Nombre = "Coca Cola ",
                     TipoMercaderiaId = 8,
                     Precio = 500,
                     Ingredientes = "Coca Cola 650ml ",
                     Preparacion = "Coca Cola en botella",
                     Imagen = "imagen_CocaCola"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 16,
                     Nombre = "Agua Mineral",
                     TipoMercaderiaId = 8,
                     Precio = 500,
                     Ingredientes = "Agua Mineral 1lt ",
                     Preparacion = "Agua Mineral en botella",
                     Imagen = "imagen_AguaMineral"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 17,
                     Nombre = "Cerveza IPA",
                     TipoMercaderiaId = 9,
                     Precio = 900,
                     Ingredientes = "Malta base,Malta especial ,Lúpulo,Agua,Levadura",
                     Preparacion = "Mezclar agua caliente con malta, lúpulo y levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.",
                     Imagen = "imagen_CervezaIpa"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 18,
                     Nombre = "Cerveza Honey",
                     TipoMercaderiaId = 9,
                     Precio = 900,
                     Ingredientes = "Malta base,Malta especial ,Lúpulo,Agua,Levadura",
                     Preparacion = "mezclar agua caliente con malta, lúpulo y miel, agregar levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.",
                     Imagen = "imagen_CervezaHoney"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 19,
                     Nombre = "Flan C/Dulce o Crema",
                     TipoMercaderiaId = 10,
                     Precio = 1200,
                     Ingredientes = "Huevos,Leche,Azúcar,Esencia de vainilla o ralladura de limón,Caramelo",
                     Preparacion = "Mezclar leche, huevos, azúcar y esencia de vainilla, verter en un molde acaramelado, cocinar a baño maría en el horno hasta que esté firme, enfriar en nevera y desmoldar antes de servir.",
                     Imagen = "imagen_Flan"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 20,
                     Nombre = "Helado",
                     TipoMercaderiaId = 10,
                     Precio = 1500,
                     Ingredientes = "Helado sabor a eleccion(3 bochas)",
                     Preparacion = "Bochas de Helado",
                     Imagen = "imagen_Helado"
                 }

                );
        }
    }
}
