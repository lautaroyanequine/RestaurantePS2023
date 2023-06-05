import PostComanda from '../services/postComanda.js'
import GetMercarderiaById from '../services/getMercaderiaById.js';
import CarritoMercaderia from '../components/carrito.js';
import { setMercaderias,setMercaderiasNueva,getMercaderias,getRequestComanda,resetRequestComanda,getFormaEntrega, loadRequestComandaFromLocalStorage ,saveRequestComandaToLocalStorage} from '../components/requestComanda.js';




document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  loadRequestComandaFromLocalStorage(); 
  mostrarPedido();
  agregarEventoConfirmar();

}


function agregarEventoConfirmar() {
  let botonConfirmar = document.querySelector('.barra-enviar');
  botonConfirmar.addEventListener('click',postComanda);
}
function postComanda(e){
  e.preventDefault();
  console.log(getFormaEntrega());
  console.log(getRequestComanda());

  PostComanda.Post(getRequestComanda());

  resetRequestComanda(); // Restablecer requestComanda a los valores predeterminados
  saveRequestComandaToLocalStorage(); // Guardar el estado actualizado en localStorage


}

async function mostrarPedido() {
  const lista = document.querySelector('.lista-pedidos');
  let data = getMercaderias();
  let mercaderiasMostradas = [];

  for (let i = 0; i < data.length; i++) {
    const mercaderia = data[i];
    if (yaFueSeleccionado(mercaderiasMostradas, mercaderia))continue;
    let dataMercaderia = await GetMercarderiaById.GetById(mercaderia);
    lista.innerHTML += CarritoMercaderia(dataMercaderia);
    mercaderiasMostradas.push(mercaderia);
  }
  actualizarPedido();
  eliminarPedido();
  agregarMercaderia();

}

function actualizarPedidoBotones(mercaderiaUnica,bool){
    let precioAModificar=document.querySelector(`[data-id-precio="${mercaderiaUnica}"]`);
    let cantidadAModificar=document.querySelector(`[data-id-nombre="${mercaderiaUnica}"]`);
    let precioNuevo=0;
    if(bool){
      precioNuevo=parseInt(precioAModificar.dataset.idPrecioValor)+parseInt(precioAModificar.textContent);
     console.log(cantidadAModificar.textContent);
      cantidadAModificar.textContent=parseInt(cantidadAModificar.textContent)+1;
    }
    else{
      precioNuevo=parseInt(precioAModificar.textContent)-parseInt(precioAModificar.dataset.idPrecioValor);
      cantidadAModificar.textContent=parseInt(cantidadAModificar.textContent)-1;

    }
    precioAModificar.textContent=precioNuevo;
}

function actualizarPedido(){
  let data = getMercaderias();
  let mercaderiasMostradas = [];
  for (let i = 0; i < data.length; i++) {
    const mercaderia = data[i];
    if (yaFueSeleccionado(mercaderiasMostradas, mercaderia))continue;
    const repeticiones=contarRepeticiones(data,mercaderia);
    let cantidadAModificar=document.querySelector(`[data-id-nombre="${mercaderia}"]`);
    let precioAModificar=document.querySelector(`[data-id-precio="${mercaderia}"]`);
    let carritoAModificar=document.querySelector(`[data-id-cantidad="${mercaderia}"]`);
    carritoAModificar.textContent=repeticiones;
    cantidadAModificar.textContent=repeticiones;
    let precioNuevo=repeticiones*parseInt(precioAModificar.textContent);
    precioAModificar.textContent=precioNuevo;
    mercaderiasMostradas.push(mercaderia);
  }
}

function obtenerTotal(){
  let data = getMercaderias();
  let mercaderiasMostradas = [];
  let total=0;
  for (let i = 0; i < data.length; i++) {
    const mercaderia = data[i];
    if (yaFueSeleccionado(mercaderiasMostradas, mercaderia))continue;
    let precioAModificar=document.querySelector(`[data-id-precio="${mercaderia}"]`);
    total += parseInt(precioAModificar.textContent);
    mercaderiasMostradas.push(mercaderia);
  }
  return total;
}


function eliminarPedido(){
  let botonTacho= document.querySelectorAll('.tacho');
  botonTacho.forEach(boton =>{
    console.log(boton);
    boton.addEventListener('click',()=> eliminarPedidoAction(boton))
  })
}

const eliminarPedidoAction = (boton)=>{
  let data= getMercaderias();
  let nuevaData=data.filter((mercaderia) => mercaderia !== parseInt(boton.dataset.idTacho));
  setMercaderiasNueva(nuevaData);
  saveRequestComandaToLocalStorage();
  let li = document.querySelector(`[data-id-mercaderia-carrito$="${boton.dataset.idTacho}"]`);
  li.innerHTML="";
}

function agregarMercaderia(){

  let botonCarrito=document.querySelectorAll('.accion-carrito');
  botonCarrito.forEach(boton =>{
    boton.addEventListener('click', agregaMercaderiaAction(boton))
  })
}
const agregaMercaderiaAction=(boton) =>{
  const cantidadMenorElement = boton.querySelector(`[data-id-decrementar]`);
  const cantidadValorElement = boton.querySelector(`[data-id-cantidad]`);
  const cantidadMayorElement = boton.querySelector(`[data-id-aumentar]`);
  let data = getMercaderias();

  cantidadMenorElement.addEventListener('click', () => {
    let cantidad = parseInt(cantidadValorElement.textContent);
    if (cantidad > 1) {
      cantidad--;
      cantidadValorElement.textContent = cantidad;
      let mercaderia =cantidadMenorElement.dataset.idDecrementar;
      let nuevaData = eliminarNumero(data,parseInt(mercaderia));
      setMercaderiasNueva(nuevaData);
      saveRequestComandaToLocalStorage();
      actualizarPedidoBotones(mercaderia,false);


    }
  })
  
  cantidadMayorElement.addEventListener('click', () => {
    let cantidad = parseInt(cantidadValorElement.textContent);
    cantidad++;
    cantidadValorElement.textContent = cantidad;
    let mercaderia =cantidadMayorElement.dataset.idAumentar;
    console.log(mercaderia);
    let mercaderiaAgregar=[];
    mercaderiaAgregar.push(parseInt(mercaderia));
    console.log(mercaderiaAgregar);
    setMercaderias(mercaderiaAgregar);
    let nuevaData=getMercaderias();
    console.log(nuevaData);
    saveRequestComandaToLocalStorage();
    actualizarPedidoBotones(mercaderia,true);
  });

}

function contarRepeticiones(array, numero) {
  let contador = 0;
  
  for (let i = 0; i < array.length; i++) {
    if (array[i] === numero) {
      contador++;
    }
  }
  
  return contador;
}

function yaFueSeleccionado(array, numero) {
  if (array.includes(numero))return true;
  return false;
}

const eliminarNumero = (array, numero) => {
  const index = array.indexOf(numero);
  if (index !== -1) {
    array.splice(index, 1);
  }
  return array;
};