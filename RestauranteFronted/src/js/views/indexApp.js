

import Galeria from '../components/galeria.js';
import Api from '../services/getMercaderia.js'



document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  mostrarGaleria();


}


async function mostrarGaleria(){
  const galeria = document.querySelector('.galeria');
  console.log(galeria);
  const mercaderia= await Api.Get();
  const mercaderiaFiltrada = mercaderia.filter(item => item.tipo.id >= 1 && item.tipo.id <= 6);
  const mercaderiaAleatoria = obtenerElementosAleatorios(mercaderiaFiltrada, 9);
  let data= Galeria(mercaderiaAleatoria);
  galeria.innerHTML+=data;
}

function obtenerElementosAleatorios(array, cantidad) {
  const elementosAleatorios = [];
  const arrayCopiado = array.slice(); 
  while (elementosAleatorios.length < cantidad && arrayCopiado.length > 0) {
    const indiceAleatorio = Math.floor(Math.random() * arrayCopiado.length);
    const elementoAleatorio = arrayCopiado.splice(indiceAleatorio, 1)[0];
    elementosAleatorios.push(elementoAleatorio);
  }

  return elementosAleatorios;
}
/*
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

*/
