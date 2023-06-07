export default function Comandas(comanda) {
    const productosMap = new Map();
    comanda.mercaderias.forEach((mercaderia) => {
      const { id,nombre } = mercaderia;
      if (productosMap.has(id)) {
        const cantidad = productosMap.get(id);
        productosMap.set(id, cantidad + 1);
      } else {
        productosMap.set(id, 1);
      }
    });
  
    const productosUnicos = Array.from(productosMap.entries()).map(([id, cantidad]) => {
      const producto = comanda.mercaderias.find((mercaderia) => mercaderia.id === id);
      return { ...producto, cantidad };
    });
    let fechaDia=comanda.fecha.toString().split('T')[0];
    let hora=comanda.fecha.toString().split('T')[1].split('.')[0];
  
    return `
      <li>
        <div class="pedido">
          <div class="flex-pedido">
            <h4>Pedido</h4>
            <h4>${comanda.id}</h4>
          </div>
          <div class="flex-mercaderia">
            <h4>Mercaderia</h4>
            <ul>
              ${productosUnicos
                .map((producto) => {
                    return `
                      <li>
                        <div class="flex-pedido-mercaderia">
                        <h4>${producto.id}</h4>
                          <h4 class="nombre-comanda">${producto.cantidad}x ${producto.nombre}</h4>
                          <h4 class="precio">$${producto.precio}</h4>
                        </div>
                      </li>
                    `;
                })
                .join("")}
            </ul>
          </div>
          <div class="flex-forma-entrega">
            <h4>Forma entrega</h4>
            <h4>${comanda.formaEntrega.descripcion}</h4>
          </div>
          <div class="flex-fecha">
            <h4>Fecha</h4>
            <h4>${fechaDia} | ${hora}</h4>
          </div>
          <div class="flex-total">
            <h4>Total</h4>
            <h4>$${comanda.total}</h4>
          </div>
        </div>
      </li>
    `;
  }