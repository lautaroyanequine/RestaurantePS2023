import Menu from '../components/menu.js'
import Api from '../services/getMercaderia.js'
import ApiFiltered from '../services/getMercaderiaFiltered.js'
import {  loadRequestComandaFromLocalStorage,setFormaEntrega,saveRequestComandaToLocalStorage, getFormaEntrega} from '../components/requestComanda.js'



document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp() {
  loadRequestComandaFromLocalStorage(); 
  let formaEntregaSeleccionada = document.querySelector(`[data-id-forma-entrega="${getFormaEntrega()}"]`);
  formaEntregaSeleccionada.classList.add('seleccionado');
  onListFormaEntregaClick(document.querySelectorAll(".forma-entrega"), formaEntregaSeleccionada);
  mostrarMercaderias();
  ocultarMercaderias(document.querySelectorAll(".logo-desplegable"));
  busquedaFiltrada();
  clickCarrito();
}

async function mostrarMercaderias(){
    try{
        let data = await Api.Get();
        data.forEach(mercaderiaDetalle => {
            let tipo = document.querySelector(`[data-id="${mercaderiaDetalle.tipo.id}"]`);
            tipo.innerHTML+=Menu(mercaderiaDetalle);
        })
        direccionarMercaderia();

    }

    catch(error)
    {
        console.log(error);
    }
} 

function clickCarrito(){
  let logo = document.querySelector('.logo-carrito');
  logo.addEventListener('click',() => clickCarritoAction())
}
const clickCarritoAction= () =>{
  window.location.href = "carrito.html";

}
const onClickFormaEntrega = (e) => {

    let formaEntrega;
    if(e.target.tagName=== 'P' ||e.target.tagName=== 'IMG' ) {
        
        formaEntrega = e.target.parentElement;
    }else{
        formaEntrega = e.target
    }
    let formaEntregaSeleccionada = document.querySelector('.forma-entrega.seleccionado');


    if (formaEntrega !== formaEntregaSeleccionada) {
      formaEntregaSeleccionada.classList.remove('seleccionado');
      formaEntregaSeleccionada = formaEntrega;
      formaEntregaSeleccionada.classList.add('seleccionado');
      setFormaEntrega(parseInt(formaEntregaSeleccionada.dataset.idFormaEntrega));
      saveRequestComandaToLocalStorage();
    }


  }
  
  function onListFormaEntregaClick(formasEntrega) {
    formasEntrega.forEach(formaEntrega => {
      formaEntrega.addEventListener('click', onClickFormaEntrega);
    });
  }
function ocultarMercaderias(tiposMercaderia){
    tiposMercaderia.forEach(tipoMercaderia =>{
        tipoMercaderia.addEventListener('click',()=>ocultarMercaderiasAction(tipoMercaderia));
    });
}

const ocultarMercaderiasAction = (tipoMercaderia) =>{
const tipo = tipoMercaderia.dataset.tipo;
const listaMercaderia = document.getElementById(tipo);
const hijos= listaMercaderia.children;
let aux=false;
for (let i = 0; i < hijos.length; i++) {
    const hijo = hijos[i];
    if(hijo.classList.contains('d-none')) aux=true;
}

for (let i = 0; i < hijos.length; i++) {

    const hijo = hijos[i];
    if(aux === true){ hijo.classList.add('d-none');

}
    if(hijo.classList.contains('d-none')) hijo.classList.remove('d-none');
    else hijo.classList.add('d-none');
  }
       

}

function busquedaFiltrada(){
    const selectOrdenarPor = document.getElementById('ordenarPor');
    const selectFiltrarPor = document.getElementById('filtrarPor');
    const inputBuscarMercaderia = document.getElementById('buscarMercaderia');

    selectOrdenarPor.addEventListener('change',()=> handleFiltrarMercaderia(selectOrdenarPor,selectFiltrarPor,inputBuscarMercaderia));
    selectFiltrarPor.addEventListener('change', ()=> handleFiltrarMercaderia(selectOrdenarPor,selectFiltrarPor,inputBuscarMercaderia));
    inputBuscarMercaderia.addEventListener('input', ()=> handleFiltrarMercaderia(selectOrdenarPor,selectFiltrarPor,inputBuscarMercaderia));
}

async function   handleFiltrarMercaderia(order,filter,name) {
    const ordenarPor = order.value;
    const filtrarPor = filter.value;
    const buscarPorNombre = name.value;
    let data = await ApiFiltered.Get(filtrarPor,buscarPorNombre,ordenarPor);
    const contenedores = document.querySelectorAll('.tipo-mercaderia ul');
    contenedores.forEach(contenedor => {
      const hijos = contenedor.querySelectorAll('li');
      hijos.forEach(hijo => {
        hijo.classList.add('d-none');
      });
    });
  
  ordenarPorPrecio(ordenarPor);
  data.forEach(mercaderiaDetalle => {
        let tipo=document.getElementById(`${mercaderiaDetalle.tipo.descripcion.replace(/\s/g,"")}`);
        let elemento = document.querySelector(`li[data-id-mercaderia="${mercaderiaDetalle.id}"]`);
        if(elemento.classList.contains('d-none')) elemento.classList.remove('d-none');
        else elemento.classList.add('d-none');

    })

  }

  function ordenarPorPrecio(orden){
    const elementosAuxiliares = document.querySelectorAll(".auxiliar");
    const elementosMercaderia = [];
    elementosAuxiliares.forEach(elemento =>{
        elementosMercaderia.push(elemento);
    });
    
    const hijosMercaderia = [];
    elementosAuxiliares.forEach(elemento =>{
        const hijos = Array.from(elemento.getElementsByTagName('li'));
        hijosMercaderia.push(...hijos);
    });

  hijosMercaderia.sort(function(a, b) {
    const precioA = obtenerPrecio(a);
    const precioB = obtenerPrecio(b);
    if (orden === 'DESC') return (precioA-precioB)*-1; 
      return precioA - precioB; 
  });

  elementosMercaderia.forEach(mercaderia => {
    while(mercaderia.firstChild){
        mercaderia.firstChild.remove();
    }
  });
  hijosMercaderia.forEach(elemento => {
    if (!elemento.dataset.idTipoMercaderia) {
      return;
    }
    let tipo = document.querySelector(`[data-id="${elemento.dataset.idTipoMercaderia}"]`);
    tipo.appendChild(elemento);
  });
}
function obtenerPrecio(elemento) {
    const precioElemento = elemento.querySelector('.precio-mercaderia');
    return precioElemento ? parseFloat(precioElemento.textContent.replace('$','')) : 0;
  }
  
function direccionarMercaderia(){
  const mercaderias = document.querySelectorAll('.mercaderiaIndividual');

  mercaderias.forEach(mercaderia =>{
    mercaderia.addEventListener('click',() =>{
      const idMercaderia = mercaderia.dataset.idMercaderia;
      const idTipoMercaderia = mercaderia.dataset.idTipoMercaderia;
      const urlProducto = `producto.html?id=${idMercaderia}&tipo=${idTipoMercaderia}`;
      window.location.href = urlProducto;
    })
    });
}





