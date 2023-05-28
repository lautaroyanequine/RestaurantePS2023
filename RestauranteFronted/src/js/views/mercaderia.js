/*
// https://localhost:7030/api/v1/Mercaderia?tipo=&orden=ASC

async function obtenerEmpleados() {

    const archivo = 'https://localhost:7030/api/v1/Mercaderia?tipo=&orden=ASC';

    // fetch(archivo)
    //     .then( resultado => resultado.json())
    //     .then( datos => {
    //         // console.log(datos.empleados);

    //         const { empleados } = datos;
    //        console.log(empleados);
    //     });

    const resultado = await fetch(archivo);
    const datos = await resultado.json();z
    console.log(datos);
}
obtenerEmpleados();*/