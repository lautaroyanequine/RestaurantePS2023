
const getMercaderia = async(filtrarPor,buscarPorNombre,ordenarPor) =>{
    let result= [];
    let mercaderiaDetalle= [];
    if(buscarPorNombre==null)
    {
        return;
    }

    let response = await fetch(`https://localhost:7030/api/v1/Mercaderia?tipo=${filtrarPor}&nombre=${buscarPorNombre}&orden=${ordenarPor}`);
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

 const ApiFiltered ={
    Get : getMercaderia
}
export default ApiFiltered;