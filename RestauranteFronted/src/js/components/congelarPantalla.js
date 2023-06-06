export default function CongelarPantalla(tiempo){
        document.body.classList.add("freeze"); 
        setTimeout(function() {
          document.body.classList.remove("freeze"); 
        }, tiempo);
}

