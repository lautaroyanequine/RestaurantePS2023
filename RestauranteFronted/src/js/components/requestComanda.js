let requestComanda = {
    mercaderias: [],
    formaEntrega: 1
  };
  
  export const setRequestComanda = (comanda) => {
    requestComanda = comanda;
  };
  
  export const getRequestComanda = () => {
    return requestComanda;
  };
 export const setMercaderias = (mercaderias) => {
  if (!Array.isArray(requestComanda.mercaderias)) {
    requestComanda.mercaderias = [];
  }
  requestComanda.mercaderias.push(...mercaderias);
};

export const setMercaderiasNueva = (mercaderias) => {
  if (!Array.isArray(requestComanda.mercaderias)) {
    requestComanda.mercaderias = [];
  }
  requestComanda.mercaderias=mercaderias;
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
  
  export const loadRequestComandaFromLocalStorage = () => {
    const savedComanda = localStorage.getItem('requestComanda');
    if (savedComanda) {
      requestComanda = JSON.parse(savedComanda);
    } else {
      resetRequestComanda(); 
    }
  };