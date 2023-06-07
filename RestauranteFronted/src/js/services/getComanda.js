
const getComanda = async(fecha) =>{
    let result= [];
    let response = await fetch(`https://localhost:7030/api/v1/Comanda?fecha=${fecha}`);
        if(response.ok){
            result = await response.json();
        }
        return result ; 
  }
  

const GetComanda ={
    Get : getComanda
}
export default GetComanda;


