// Selecciona los elementos del DOM que se van a utilizar
const openBtn = document.querySelector('.btn');
const goBtn = document.querySelector('.btn-2');
const searchBox = document.querySelector('.searchBox');
const redo = document.querySelector('.redo');

// Lista de libros para buscar
const libros = [
  'Cien años de soledad',
  'El amor en los tiempos del cólera',
  'La sombra del viento',
  'El principito',
  '1984',
  'Orgullo y prejuicio',
  // Agrega más libros según sea necesario
];

// Añade un escuchador de eventos para el botón de apertura
openBtn.addEventListener('click', () => {
  // Cambia la escala del botón de ir para que sea visible
  goBtn.style.transform = 'scale(1)';
  // Añade una clase para que el botón de apertura cambie de apariencia
  openBtn.classList.add('appear');
  // Cambia la escala de la caja de búsqueda para que sea visible
  searchBox.style.transform = 'scale(1)';
  // Limpia el valor de la caja de búsqueda
  searchBox.value = '';
  // Cambia la opacidad del icono de redondeo para que sea visible
  redo.style.opacity = '1';
});

// Añade un escuchador de eventos para el botón de ir
goBtn.addEventListener('click', () => {
  const query = searchBox.value.toLowerCase(); // Convierte la búsqueda a minúsculas
  const resultados = libros.filter(libro => libro.toLowerCase().includes(query)); // Filtra los libros

  if (resultados.length > 0) {
    alert(`Resultados encontrados:\n${resultados.join('\n')}`); // Muestra los resultados
  } else {
    alert('No se encontraron libros que coincidan con la búsqueda.'); // Mensaje si no hay resultados
  }

  // Limpia el valor de la caja de búsqueda después de la búsqueda
  searchBox.value = '';
});

// Añade un escuchador de eventos para la caja de búsqueda
searchBox.addEventListener('keyup', (e) => {
  // Verifica si se presionó la tecla Enter
  if (e.keyCode === 13) {
    // Simula un clic en el botón de ir para iniciar la búsqueda
    goBtn.click();    
  }
});

// Añade un escuchador de eventos para el icono de redondeo
redo.addEventListener('click', () => {
  // Elimina la clase para que el botón de apertura vuelva a su apariencia original
  openBtn.classList.remove('appear');
  // Cambia la escala del botón de ir para que no sea visible
  goBtn.style.transform = 'scale(0)';
  // Cambia la escala de la caja de búsqueda para que no sea visible
  searchBox.style.transform = 'scale(0)';
  // Cambia la opacidad del icono de redondeo para que no sea visible
  redo.style.opacity = '0';
});