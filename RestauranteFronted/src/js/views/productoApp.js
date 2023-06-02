import Producto from '../components/menu/producto/producto.js'

import GetMercarderiaById from '../services/getMercaderiaById.js';


document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  mostrarProducto();

}

async function mostrarProducto(){
  const urlParams = new URLSearchParams(window.location.search);
  let data = await GetMercarderiaById.GetById(urlParams.get('id'));
  document.querySelector(".relative").innerHTML+=Producto(data);

}