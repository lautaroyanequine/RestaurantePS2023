export default function CarritoMercaderia(mercaderia){
    return ` 
        <li data-id-mercaderia-carrito=${mercaderia.id}>
         <div class="pedido">
            <div class="pedido-header">
                <h4><span data-id-nombre=${mercaderia.id}>1</span>x ${mercaderia.nombre}</h4>
                <h4>$<span data-id-precio="${mercaderia.id}" data-id-precio-valor="${mercaderia.precio}"> ${mercaderia.precio}</span></h4>
            </div>
            <div class="pedido-footer">
                <div class="accion-carrito">
                    <p data-id-decrementar="${mercaderia.id}">-</p>
                    <p data-id-cantidad="${mercaderia.id}" >1</p>
                    <p data-id-aumentar="${mercaderia.id}">+</p>
                </div>
                <img class="tacho" data-id-tacho="${mercaderia.id}" src="src/img/icono_basura.svg" alt="">
              </div>
            </div>
        </li>
    `;
}


