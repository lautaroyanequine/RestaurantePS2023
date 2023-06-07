import Producto from '../components/producto.js'
import GetMercarderiaById from '../services/getMercaderiaById.js';
import { setMercaderias,getMercaderias,resetRequestComanda,getFormaEntrega, loadRequestComandaFromLocalStorage ,saveRequestComandaToLocalStorage} from '../components/requestComanda.js';
import MostrarAlerta from '../components/mostrarAlerta.js'
import CongelarPantalla from '../components/congelarPantalla.js';





document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  loadRequestComandaFromLocalStorage(); 
  mostrarProducto();
  numerosCarrito();
  agregarCarrito();

}
const urlParams = new URLSearchParams(window.location.search);

async function mostrarProducto(){
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

cantidadMenorElement.addEventListener('click', () => {
  let cantidad = parseInt(cantidadValorElement.textContent);
  if (cantidad > 1) {
    cantidad--;
    cantidadValorElement.textContent = cantidad;
  }
});

cantidadMayorElement.addEventListener('click', () => {
  let cantidad = parseInt(cantidadValorElement.textContent);
  cantidad++;
  cantidadValorElement.textContent = cantidad;
});
}

function agregarCarrito(){
 const boton= document.querySelector('.agregar-carrito');
boton.addEventListener('click',()=> agregarCarritoAction()) 
}

const agregarCarritoAction = ()=>{

  let cantidad=parseInt(document.getElementById('cantidad-valor').textContent);
  let id= urlParams.get('id');

let mercaderias= [];
for (let i = 0; i < cantidad; i++) {
 mercaderias.push(parseInt(id));
}
setMercaderias(mercaderias);
saveRequestComandaToLocalStorage();
MostrarAlerta("SE AGREGO CORRECTAMENTE AL CARRITO","alerta");
CongelarPantalla(1500);




}

