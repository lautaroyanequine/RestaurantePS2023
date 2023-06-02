import Menu from '../components/menu/menu.js'
import Api from '../services/getMercaderia.js'
import ApiFiltered from '../services/getMercaderiaFiltered.js'


document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
    onListFormaEntregaClick(document.querySelectorAll(".forma-entrega"));
    mostrarMercaderias();
    ocultarMercaderias(document.querySelectorAll(".logo-desplegable"));
    busquedaFiltrada();
}

async function mostrarMercaderias(){
    try{
        let data = await Api.Get();
        data.forEach(mercaderiaDetalle => {
            let tipo=document.getElementById(`${mercaderiaDetalle.tipo.descripcion.replace(/\s/g,"")}`);
            tipo.innerHTML+=Menu(mercaderiaDetalle);
        })
    }

    catch(error)
    {
        console.log(error);
    }
} 
let formaEntregaSeleccionada= null;
const onClickFormaEntrega = (e) => {
    let formaEntrega;
    if(e.target.tagName=== 'P' ||e.target.tagName=== 'IMG' ) {
        
        formaEntrega = e.target.parentElement;
    }else{
        formaEntrega = e.target
    }

  if (formaEntregaSeleccionada !== null) {
    if (formaEntrega === formaEntregaSeleccionada) {
      return;
    }
    formaEntregaSeleccionada.classList.remove('seleccionado');
  }
  formaEntrega.classList.add('seleccionado');
  formaEntregaSeleccionada = formaEntrega;
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
console.log(aux);

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


    data.forEach(mercaderiaDetalle => {
        let tipo=document.getElementById(`${mercaderiaDetalle.tipo.descripcion.replace(/\s/g,"")}`);
        let elemento = document.querySelector(`li[data-id-mercaderia="${mercaderiaDetalle.id}"]`);

        if(elemento.classList.contains('d-none')) elemento.classList.remove('d-none');
        else elemento.classList.add('d-none');


    })

  
  }