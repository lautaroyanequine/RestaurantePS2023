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
                    Preparacion = "Para preparar tortilla de papas: freír papas y cebolla en aceite, mezclar con huevo batido, sazonar, verter en sartén, cocinar a fuego medio-bajo hasta dorar por ambos lados, retirar de la sartén y dejar enfriar.",
                    Imagen = "https://images.unsplash.com/photo-1639669794539-952631b44515?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1521&q=80"
                },
                new Mercaderia
                {
                    MercaderiaId = 2,
                    Nombre = "Nachos con queso y guacamole",
                    TipoMercaderiaId = 1,
                    Precio = 600,
                    Ingredientes = "Nachos,Queso cheddar,Tomate,Verdeo,Guacamole",
                    Preparacion = "Colocar nachos en una bandeja, agregar queso rallado, hornear a 180°C por unos minutos hasta que el queso se derrita, retirar del horno y servir con salsa y guacamole.",
                    Imagen = "https://images.unsplash.com/photo-1619604107557-b5321217aee7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=735&q=80"
                },
                new Mercaderia
                {
                    MercaderiaId = 3,
                    Nombre = "Milanesa con papa fritas",
                    TipoMercaderiaId = 2,
                    Precio = 1500,
                    Ingredientes = "Milanesas de peceto y papas",
                    Preparacion = "pasar la carne por huevo batido y pan rallado, freír en aceite caliente hasta dorar ambos lados, acompañar con papas fritas previamente cortadas y fritas en aceite caliente, escurrir el exceso de aceite y servir caliente con limón y/o salsa al gusto.",
                    Imagen = "https://astelus.com/wp-content/viajes/Plato-de-milanesa-con-papas-ti%CC%81pico-de-Argentina.jpg.webp"
                },
                new Mercaderia
                {
                    MercaderiaId = 4,
                    Nombre = "Milanesa napolitana con papa fritas",
                    TipoMercaderiaId = 2,
                    Precio = 1500,
                    Ingredientes = "Milanesas de peceto y papas",
                    Preparacion = "Para preparar milanesas napolitanas con papas fritas, sigue los pasos para las milanesas simples. Después de freír las milanesas, cúbrelas con salsa de tomate y queso mozzarella rallado. Hornea durante 5-7 minutos o hasta que el queso se derrita. ",
                    Imagen = "https://www.lanacion.com.ar/resizer/jJalmcLXGFkG8Xj37KLQ74hBcJ0=/1200x800/filters:format(webp):quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/VLWFAANIWBGPFO4CSUHS7RYVVQ.jpg"
                },
                new Mercaderia
                {
                    MercaderiaId = 5,
                    Nombre = "Spaghetti Scarparo",
                    TipoMercaderiaId = 3,
                    Precio = 2400,
                    Ingredientes = "Crema. oliva, ajo, verdeo, pomodoro fresco y pesto genovés",
                    Preparacion = "saltear ajo y ají en aceite, agregar tomate, aceitunas, alcaparras y vino, cocinar salsa. Cocer spaghetti, mezclar con salsa y servir con queso y perejil.",
                    Imagen = "https://images.unsplash.com/photo-1614777986387-015c2a89b696?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                },
                new Mercaderia
                {

                    MercaderiaId = 6,
                    Nombre = "Sorrentinos Panna di Champignones",
                    TipoMercaderiaId = 3,
                    Precio = 2900,
                    Ingredientes = "Sorrentinos,Crema, ajo, Champignones y jerez",
                    Preparacion = "cocinar sorrentinos en agua hirviendo con sal, saltear champiñones en aceite con ajo y cebolla, agregar crema de leche y cocinar hasta espesar, mezclar con los sorrentinos y servir con queso rallado y perejil",
                    Imagen = "https://cucinadonore.com/assets/img/carta/02/ravioli-di-zucca-alla-panna-mandorle.jpg?1683158400071"
                },
                new Mercaderia
                {
                    MercaderiaId = 7,
                    Nombre = "Bife de Chorizo. C/ Papas o Ensalada",
                    TipoMercaderiaId = 4,
                    Precio = 3000,
                    Ingredientes = "Bife de Chorizo y acompañamiento",
                    Preparacion = "salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.",
                    Imagen = "https://media-cdn.tripadvisor.com/media/photo-s/19/2f/17/8b/bife-de-chorizo-con-papas.jpg"
                },
                 new Mercaderia
                 {
                     MercaderiaId = 8,
                     Nombre = "Tapa de Asado. C/ Papas o Ensalada",
                     TipoMercaderiaId = 4,
                     Precio = 2800,
                     Ingredientes = "Tapa de Asado y acompañamiento",
                     Preparacion = "Salpimentar la carne y cocinar a la parrilla o en sartén caliente con aceite y manteca, dorar ambos lados al gusto, retirar del fuego y dejar reposar unos minutos, servir caliente con ensalada y/o papas fritas.",
                     Imagen = "https://images.unsplash.com/photo-1529694157872-4e0c0f3b238b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 9,
                     Nombre = "Pizza Muzzarella",
                     TipoMercaderiaId = 5,
                     Precio = 2000,
                     Ingredientes = "Pizza con salsa y muzaarella",
                     Preparacion = "Estirar la masa de pizza, agregar salsa de tomate, colocar mozzarella en rodajas, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con orégano y/o aceitunas al gusto.",
                     Imagen = "https://images.unsplash.com/photo-1595854341625-f33ee10dbf94?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 10,
                     Nombre = "Fugazzeta",
                     TipoMercaderiaId = 5,
                     Precio = 3000,
                     Ingredientes = "Fugazzeta con cebolla,morron, jamon y queso",
                     Preparacion = "Estirar la masa de pizza, agregar cebolla en rodajas y queso rallado, hornear a 200°C hasta que la masa esté dorada y el queso derretido, retirar del horno y servir caliente con aceitunas y/o salsa criolla al gusto.",
                     Imagen = "https://images.unsplash.com/photo-1644398324665-57647e829ca2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=880&q=80"
                 },
                 new Mercaderia
                 {

                     MercaderiaId = 11,
                     Nombre = "Sandwich de Milanesa con Papas Fritas",
                     TipoMercaderiaId = 6,
                     Precio = 2000,
                     Ingredientes = "Milanesa de carne y papas fritas",
                     Preparacion = "Cocinar la milanesa empanizada en aceite caliente hasta dorar, armar el sandwich con pan, lechuga, tomate y mayonesa, acompañar con papas fritas hechas en aceite caliente y servir caliente.",
                     Imagen = "https://www.comedera.com/wp-content/uploads/2021/06/sandwich-de-milanesa.jpg"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 12,
                     Nombre = "Sandwich de Bondiola",
                     TipoMercaderiaId = 6,
                     Precio = 2000,
                     Ingredientes = "Bondiola,Queso Provolone,Cebolla Caramelizada",
                     Preparacion = "Marinar la carne con hierbas y especias, sellar en una sartén caliente con aceite hasta dorar, cocinar en horno a 180°C durante 45-60 minutos, retirar del horno y dejar reposar, cortar en rodajas y servir caliente con guarnición de verduras al gusto. ",
                     Imagen = "https://www.recetasnatura.com.ar/sites/default/files/sandwich-de-bondiola-caramelizada-c.jpg"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 13,
                     Nombre = "Ensalda Cesar",
                     TipoMercaderiaId = 7,
                     Precio = 1200,
                     Ingredientes = "Lechuga romana,Queso parmesano rallado,Croutones,Salsa César (mayonesa, ajo, jugo de limón, mostaza Dijon, anchoas y queso parmesano rallado)",
                     Preparacion = "Mezclar lechuga romana, pollo asado en trozos, pan tostado y queso parmesano rallado, aderezar con salsa césar (mayonesa, ajo, mostaza, anchoas, jugo de limón y parmesano) y servir frío.",
                     Imagen = "https://images.unsplash.com/photo-1574926054530-540288c8e678?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 14,
                     Nombre = "Ensalda Rusa",
                     TipoMercaderiaId = 7,
                     Precio = 900,
                     Ingredientes = "Papas cocidas y cortadas en cubitos,Zanahorias cocidas y cortadas en cubitos,Guisantes o arvejas cocidas,Mayonesa,Sal y pimienta al gusto",
                     Preparacion = "Cocer papas y zanahorias, pelar y cortar en cubos junto con arvejas cocidas y huevo duro, mezclar con mayonesa, sal y pimienta al gusto, enfriar en nevera durante 1 hora y servir frío. ",
                     Imagen = "https://recetarius.com/wp-content/uploads/2020/12/ensalada-rusa.jpg"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 15,
                     Nombre = "Coca Cola ",
                     TipoMercaderiaId = 8,
                     Precio = 500,
                     Ingredientes = "Coca Cola 650ml ",
                     Preparacion = "Coca Cola en botella",
                     Imagen = "https://images.unsplash.com/photo-1624552184280-9e9631bbeee9?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 16,
                     Nombre = "Agua Mineral",
                     TipoMercaderiaId = 8,
                     Precio = 500,
                     Ingredientes = "Agua Mineral 500cc ",
                     Preparacion = "Agua Mineral en botella",
                     Imagen = "https://images.unsplash.com/photo-1638688569176-5b6db19f9d2a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 17,
                     Nombre = "Cerveza IPA",
                     TipoMercaderiaId = 9,
                     Precio = 900,
                     Ingredientes = "Malta base,Malta especial ,Lúpulo,Agua,Levadura",
                     Preparacion = "Mezclar agua caliente con malta, lúpulo y levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.",
                     Imagen = "https://images.unsplash.com/photo-1659464560849-78cbaa3f206e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=685&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 18,
                     Nombre = "Cerveza Honey",
                     TipoMercaderiaId = 9,
                     Precio = 900,
                     Ingredientes = "Malta base,Malta especial ,Lúpulo,Agua,Levadura",
                     Preparacion = "mezclar agua caliente con malta, lúpulo y miel, agregar levadura en un fermentador, fermentar durante una semana a temperatura controlada, embotellar con azúcar para la carbonatación natural, dejar reposar por al menos dos semanas y servir frío.",
                     Imagen = "https://imag.bonviveur.com/diferentes-vasos-de-cerveza-en-la-barra-de-un-bar.jpg"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 19,
                     Nombre = "Flan C/Dulce o Crema",
                     TipoMercaderiaId = 10,
                     Precio = 1200,
                     Ingredientes = "Huevos,Leche,Azúcar,Esencia de vainilla o ralladura de limón,Caramelo",
                     Preparacion = "Mezclar leche, huevos, azúcar y esencia de vainilla, verter en un molde acaramelado, cocinar a baño maría en el horno hasta que esté firme, enfriar en nevera y desmoldar antes de servir.",
                     Imagen = "https://images.unsplash.com/photo-1684456156705-5014341fc700?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                 },
                 new Mercaderia
                 {
                     MercaderiaId = 20,
                     Nombre = "Helado",
                     TipoMercaderiaId = 10,
                     Precio = 1500,
                     Ingredientes = "Helado sabor a eleccion(3 bochas)",
                     Preparacion = "Bochas de Helado",
                     Imagen = "https://images.unsplash.com/photo-1497034825429-c343d7c6a68f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80"
                 }

                );
        }
    }
}
