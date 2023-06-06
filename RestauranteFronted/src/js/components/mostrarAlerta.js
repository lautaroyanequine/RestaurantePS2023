import Alerta from '../components/alerta.js'

export default function  MostrarAlerta(mensaje,clase) {
    const alertaPrevia = document.querySelector('.alerta');
    if(alertaPrevia) {
        return;
    } 
  let div = document.querySelector('.informar');
  let data = Alerta(mensaje,clase);
  div.innerHTML+=data;
  
    setTimeout(() => {
        div.innerHTML="";
    }, 3000);
  }



