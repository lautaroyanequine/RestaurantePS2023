document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
    mostrarMercaderias();
}

async function mostrarMercaderias(){
    try{
        const resultado = await fetch("https://localhost:7030/api/v1/Mercaderia?tipo=&orden=ASC");
        const mercaderias = await resultado.json();



        //Generar HTML
        mercaderias.forEach(({ id, nombre, precio, tipo, imagen }) => {


            const mercaderia= document.createElement('LI');
            const divMercaderia = document.createElement('DIV');
            divMercaderia.classList.add('mercaderia','contenedor3');

            const imgMercaderia = document.createElement('IMG');
            imgMercaderia.classList.add('foto-mercaderia');

            imgMercaderia.src='src/img/comida.jpg'
            const divTextoMercaderia = document.createElement('DIV');
            divTextoMercaderia.classList.add('texto-mercaderia');


            const h4Mercaderia = document.createElement('H4');
            h4Mercaderia.classList.add('no-margin');
            h4Mercaderia.textContent=`${nombre}`;

            const pMercaderia = document.createElement('P');
            pMercaderia.classList.add('no-margin');
            pMercaderia.textContent= '${tipo.descripcion}'


            precioMercaderia = document.createElement('P');
            precioMercaderia.classList.add('precio-mercaderia');
            precioMercaderia.textContent= '$ ${precio}'


            mercaderia.appendChild(divMercaderia);
            divMercaderia.appendChild(imgMercaderia);
            divMercaderia.appendChild(divTextoMercaderia);
            divMercaderia.appendChild(precioMercaderia);

            divTextoMercaderia.appendChild(h4Mercaderia);
            divTextoMercaderia.appendChild(pMercaderia);


            document.querySelector('#prueba').appendChild(mercaderia);

            console.log(mercaderia);

            console.log(`ID: ${id}`);
            console.log(`Nombre: ${nombre}`);
            console.log(`Precio: ${precio}`);
            console.log(`Tipo: ${tipo.descripcion}`);
            console.log(`Imagen: ${imagen}`);
            console.log("----------------------");
          });
        }
    catch(error)
    {
        console.log(error);
    }
} 

/*<li>    CADA MERCADERIA
<div class="mercaderia contenedor3">
    <img class="foto-mercaderia" src="/img/comida.jpg" alt="">
    <div class="texto-mercaderia">
        <h4 class="no-margin">Rabas a la romana</h4>
        <p class="no-margin " >Compuesta de rodajas finas de calamares empanadas 
        y fritas. Se sirven calientes, acompañadas con alioli.</p>
    </div>
    <p class="precio-mercaderia">$3.000</p>
</div>
</li>
*/