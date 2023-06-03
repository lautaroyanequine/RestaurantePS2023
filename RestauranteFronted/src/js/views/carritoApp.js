import PostComanda from '../services/postComanda.js'
import { resetRequestComanda,getFormaEntrega, loadRequestComandaFromLocalStorage ,saveRequestComandaToLocalStorage} from '../components/menu/requestComanda.js';




document.addEventListener('DOMContentLoaded', ()=> iniciarApp());

function iniciarApp(){
  loadRequestComandaFromLocalStorage(); 
  
  agregarEventoConfirmar();

}

function agregarEventoConfirmar() {
  let botonConfirmar = document.querySelector('.barra-enviar');
  botonConfirmar.addEventListener('click',postComanda);
}
function postComanda(e){
  e.preventDefault();
  console.log(getFormaEntrega());

  resetRequestComanda(); // Restablecer requestComanda a los valores predeterminados
  saveRequestComandaToLocalStorage(); // Guardar el estado actualizado en localStorage
 //console.log(getRequestComanda());

 // PostComanda.Post(requestComanda);


}
