
const postComanda = async(request) =>{
  
    const url = 'https://localhost:7030/api/v1/Comanda';

    try{
        const response = await fetch(url, {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
          });

          if (!response.ok) {
            throw new Error('Error en la solicitud');
          }
        const data = await response.json();
        console.log(data);
    }
    catch (error) {
        // Manejar errores de la solicitud
        console.error('Error:', error);
      }
  


}
const PostComanda ={
    Post : postComanda
}
export default PostComanda;


