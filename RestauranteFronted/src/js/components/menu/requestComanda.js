let requestComanda = {
    mercaderias: [1,5,7],
    formaEntrega: 1
  };
  
  export const setRequestComanda = (comanda) => {
    requestComanda = comanda;
  };
  
  export const getRequestComanda = () => {
    return requestComanda;
  };
  export const setMercaderias = (mercaderias) => {
    requestComanda.mercaderias = mercaderias;
  };
  
  export const setFormaEntrega = (formaEntrega) => {
    requestComanda.formaEntrega = formaEntrega;
  };
  
  export const getMercaderias = () => {
    return requestComanda.mercaderias;
  };
  
  export const getFormaEntrega = () => {
    return requestComanda.formaEntrega;
  };

  // Guardar el estado de requestComanda en localStorage al modificarlo
export const saveRequestComandaToLocalStorage = () => {
    localStorage.setItem('requestComanda', JSON.stringify(requestComanda));
  };
  
  const defaultRequestComanda = {
    mercaderias: [],
    formaEntrega: 1
  };
  
  export const resetRequestComanda = () => {
    requestComanda = { ...defaultRequestComanda };
  };
  
  // Restablecer el estado de requestComanda al cargar la página
  export const loadRequestComandaFromLocalStorage = () => {
    const savedComanda = localStorage.getItem('requestComanda');
    if (savedComanda) {
      requestComanda = JSON.parse(savedComanda);
    } else {
      resetRequestComanda(); // Restablecer a los valores predeterminados si no hay datos guardados
    }
  };