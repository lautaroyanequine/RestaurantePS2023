import PostComanda from '../services/postComanda.js'
import GetMercarderiaById from '../services/getMercaderiaById.js';
import CarritoMercaderia from '../components/carrito.js';
import Resumen from '../components/resumen.js';
import SinProducto from '../components/sinProducto.js';

import CongelarPantalla from '../components/congelarPantalla.js';


import { setMercaderias,setMercaderiasNueva,getMercaderias,getRequestComanda,resetRequestComanda,getFormaEntrega, loadRequestComandaFromLocalStorage ,saveRequestComandaToLocalStorage} from '../components/requestComanda.js';
import MostrarAlerta from '../components/mostrarAlerta.js';




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

  try
  {e.preventDefault();
    if(getMercaderias().length < 1 )
    {
      throw new Error("Tiene que agregar la mercaderia que desee")
    }
  PostComanda.Post(getRequestComanda());
  resetRequestComanda(); 
  saveRequestComandaToLocalStorage(); 
  let barra= document.querySelector('.barra-enviar');
  barra.classList.add('d-none');
  MostrarAlerta("SU PEDIDO FUE REALIZADO CORRECTAMENTE","enviar");
  CongelarPantalla(2000);
  setTimeout(() => {
    window.location.href = "menu.html";
  }, 2000);


  }
  catch(error) {
  console.log(error);

  }
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
  mostrarResumen();
  sinProductos();


}

function actualizarPedidoBotones(mercaderiaUnica,bool){
    let precioAModificar=document.querySelector(`[data-id-precio="${mercaderiaUnica}"]`);
    let cantidadAModificar=document.querySelector(`[data-id-nombre="${mercaderiaUnica}"]`);
    let precioNuevo=0;
    if(bool){
      precioNuevo=parseInt(precioAModificar.dataset.idPrecioValor)+parseInt(precioAModificar.textContent);
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

function mostrarResumen(bool){
  let resumen = document.querySelector('.resumen');


  let data = Resumen(getMercaderias().length,obtenerFormaEntrega(),obtenerTotal());
 if(bool){
  resumen.innerHTML+= data;
 }
 else{
  resumen.innerHTML=data;
 }
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
  mostrarResumen(false);
  sinProductos();
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
      console.log(getMercaderias());

      let nuevaData = eliminarNumero(data,parseInt(mercaderia));
      setMercaderiasNueva(nuevaData);
      console.log(getMercaderias());
      saveRequestComandaToLocalStorage();
      actualizarPedidoBotones(mercaderia,false);
      mostrarResumen(false);


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
    mostrarResumen(false);

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
function obtenerFormaEntrega(){
  let data = getFormaEntrega();
  let formaEntrega="";
  switch(data){
    case 1 :
      formaEntrega="Salon";
      break;
    case 2:
      formaEntrega= "Delivery";
      break;
    case 3 :
      formaEntrega = "Pedidos Ya";
      break;
  }
  return formaEntrega;

}

function sinProductos(){
  let mercaderia =getMercaderias();
  let resumen = document.querySelector('.resumen');
  let barra= document.querySelector('.barra-enviar');
  if(mercaderia.length<1){
    resumen.innerHTML=SinProducto();
    barra.classList.add('d-none');
  }
}

