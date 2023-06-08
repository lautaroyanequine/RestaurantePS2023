
const getMercaderia = async() =>{
    let result= [];
    let mercaderiaDetalle= [];

    let response = await fetch("https://localhost:7030/api/v1/Mercaderia?tipo&orden=DESC");
        if(response.ok){
            result = await response.json();
        }

        for (const mer of result) {
            let resultadoDetalle = await fetch(`https://localhost:7030/api/v1/Mercaderia/${mer.id}?tipo=&orden=ASC`);
            if (resultadoDetalle.ok) {
                mercaderiaDetalle.push(await resultadoDetalle.json());
            }
        }
        return mercaderiaDetalle ; 
    }

 const Api ={
    Get : getMercaderia
}
export default Api;