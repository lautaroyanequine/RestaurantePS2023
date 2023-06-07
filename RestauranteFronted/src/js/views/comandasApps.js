import GetComanda from "../services/getComanda.js";
import Comandas from "../components/comandas.js";
import Alerta from "../components/alerta.js"

document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
    cargarComandas(obtenerFecha());
    cambiarFecha();
}

 async function cargarComandas(fecha){
    const calendario=document.querySelector('.calendario');
    calendario.value=fecha;
    calendario.setAttribute('max',fecha)
 let data = await GetComanda.Get(fecha);
 let div= document.querySelector('.lista-comandas');

if(data.length === 0){
   let alerta=Alerta("NO SE ENCONTRARON PEDIDOS","alerta-roja")
   div.innerHTML=alerta;
}
 data.forEach(comanda => {
   let comandaPedido= Comandas(comanda);
   div.innerHTML+=comandaPedido;
 });
}

function cambiarFecha(){
    const fechaInput = document.getElementById("fecha");
    fechaInput.addEventListener('change',e =>{
        let nuevaFecha = e.target.value;
        limpiarComandas();
        cargarComandas(nuevaFecha);

    })
}


function obtenerFecha(){
    let fecha= new Date();
    let año= fecha.getFullYear();
    let mes= fecha.getMonth()+1;
    let dia =fecha.getDate();
    if(mes < 10 ){
        mes="0"+mes;
    }
    if(dia < 10 ){
        dia="0"+dia;
    }
    let fechaString= `${año}-${mes}-${dia}`;
    return fechaString;
}

function limpiarComandas(){
    let div= document.querySelector('.lista-comandas');
   div.innerHTML="";
}

