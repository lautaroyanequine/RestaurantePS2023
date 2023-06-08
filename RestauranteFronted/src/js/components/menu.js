export default function Menu(mercaderia){
    return ` 
    <li data-id-mercaderia=${mercaderia.id} data-id-tipo-mercaderia=${mercaderia.tipo.id} class="mercaderiaIndividual">
        <div class="mercaderia contenedor3">
            <img class="foto-mercaderia" src="${mercaderia.imagen}">
            <div class="texto-mercaderia">
                <h4 class="no-margin">${mercaderia.nombre}</h4>
                <p class="no-margin">${mercaderia.ingredientes}</p>
            </div>
            <p class="precio-mercaderia">$ ${mercaderia.precio}</p>
        </div>
    </li>
    `;
}
