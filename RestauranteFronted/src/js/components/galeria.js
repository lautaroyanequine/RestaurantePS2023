export default function Galeria(mercaderias) {
    return `
    ${mercaderias.map((mercaderia) =>
      {
        return `
        <a href="menu.html"><img class="foto-galeria" src="${mercaderia.imagen}" alt="${mercaderia.nombre}""></a>
         `
      } ).join("")}
    `;
  }
