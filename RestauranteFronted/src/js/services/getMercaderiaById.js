
const getMercaderiaById = async(numeroId) =>{
    let result= [];


    let response = await fetch(`https://localhost:7030/api/v1/Mercaderia/${numeroId}`);
        if(response.ok){
            result = await response.json();
        }
        return result ; 
    }

 const GetMercarderiaById ={
    GetById : getMercaderiaById
}
export default GetMercarderiaById;



