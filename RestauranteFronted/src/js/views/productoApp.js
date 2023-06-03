import Producto from '../components/menu/producto/producto.js'

import GetMercarderiaById from '../services/getMercaderiaById.js';


document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  mostrarProducto();
  numerosCarrito();

}

async function mostrarProducto(){
  const urlParams = new URLSearchParams(window.location.search);
  let data = await GetMercarderiaById.GetById(urlParams.get('id'));
  document.querySelector(".relative").innerHTML+=Producto(data);
  agrandarImagen();

}

function agrandarImagen(){
  let icono= document.querySelector('.icono-ampliar');
  const imagenMercaderia= document.querySelector(".imagen-mercaderia");
  icono.addEventListener('click',() => agrandarImagenFuncion(imagenMercaderia)
  );
}

const agrandarImagenFuncion = (imagenMercaderia) =>{
  const imagen = document.createElement('IMG');
  imagen.src=imagenMercaderia.src;

  const overlay = document.createElement('DIV');
  overlay.appendChild(imagen)
  overlay.classList.add('overlay');


  const cerrarImagen = document.createElement('P');
    cerrarImagen.textContent = 'X';
    cerrarImagen.classList.add('btn-cerrar');

    cerrarImagen.onclick = function(){
      overlay.remove();
      body.classList.remove('fijar-body');
      footer.classList.remove('d-none');


  }

  overlay.onclick = function(){
      overlay.remove();
      body.classList.remove('fijar-body');
      footer.classList.remove('d-none');

  }

  overlay.appendChild(cerrarImagen);
  

  const body = document.querySelector('body');
  body.appendChild(overlay);
  body.classList.add('fijar-body');
  
  const footer = document.querySelector('.site-footer');
  footer.classList.add('d-none');

}

function numerosCarrito(){
  const cantidadMenorElement = document.getElementById('cantidad-menor');
const cantidadValorElement = document.getElementById('cantidad-valor');
const cantidadMayorElement = document.getElementById('cantidad-mayor');

// Agrega el evento click para decrementar la cantidad
cantidadMenorElement.addEventListener('click', () => {
  let cantidad = parseInt(cantidadValorElement.textContent);
  if (cantidad > 1) {
    cantidad--;
    cantidadValorElement.textContent = cantidad;
  }
});

// Agrega el evento click para incrementar la cantidad
cantidadMayorElement.addEventListener('click', () => {
  let cantidad = parseInt(cantidadValorElement.textContent);
  cantidad++;
  cantidadValorElement.textContent = cantidad;
});
}