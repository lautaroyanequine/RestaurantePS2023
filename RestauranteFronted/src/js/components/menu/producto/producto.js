export default function Producto(mercaderia){
    return ` 
            <img class="imagen-mercaderia" src="${mercaderia.imagen}" alt="Imagen ${mercaderia.nombre}">
            <div class="icono-volver">
                <a href="menu.html"><img src="src/img/icono-back.svg" alt=""></a>
            </div>
            <div class="icono-ampliar">
                    <img src="src/img/icono_ampliar.svg" alt="">
                    <p>Ampliar imagen</p>
            </div>
            </div>
            <div class="flex-mercaderia">
            <div class="texto-mercaderia">
                <h4>${mercaderia.nombre}</h4>
                <p>
                    Ingredientes: ${mercaderia.ingredientes}
                </p>
            </div>
            <h4>${mercaderia.precio}</h4>
    `;
}

