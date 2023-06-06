
export default function Resumen(cantidad,formaEntrega,total){
    return `    
    <div class="pedido-cantidad contenedor3">
            <h4>Cantidad de mercaderia</h4>
            <h4>${cantidad}</h4>
        </div>
        <div class="pedido-forma-entrega contenedor3">
            <h4>Forma entrega</h4>
            <h4>${formaEntrega}</h4>
        </div>
        <div class="pedido-total contenedor3">
            <h4>Total</h4>
            <h4>$${total}</h4>
        </div>
       
    </div>
    `;
}

