// Este array no se puede modificar,
var posibilidades = ["piedra", "papel", "tijera"];
//    //
let nombreValue;
let partidasTotal = 0;


/*
 *  Recogemos un array de objetos boton y a partir de este, solo cogemos el que tenga como contenido
 *       que nos interesa
 */
const botones = Array.from(document.querySelectorAll("button"))

const botonJugar = botones.find(boton => boton.textContent.trim() === "¡JUGAR!");
const botonYa = botones.find(boton => boton.textContent.trim() === "¡YA!");
const botonReset = botones.find(boton => boton.textContent.trim() === "RESET");

/*
 *  Hacemos lo mismo para las imagenes
 */
const imagenes = Array.from(document.querySelectorAll("img"));

// Elimino la ultima imagen que es la de la maquina para no interactuar en el CSS con ella
const maquinaImg = imagenes.pop();
imagenes.forEach((imagen, index) => {
    imagen.addEventListener("click", () => imageSelection(index)); 
});

// Sistema de numero partidas y nombre de usuario
function jugar() {
    // Selecciono inputs por el atributo name
    const nombre = document.querySelector('input[name="nombre"]');
    const partidas = document.querySelector('input[name="partidas"]');

    // Validador de inputs
    let incorrecto = false;
    if (partidas.value <= 0) {
        incorrecto = true;
        partidas.classList.add("fondoRojo");
    } else {
        partidas.classList.remove("fondoRojo");
    }   // Comprueba que sea +3 o numero
    if (nombre.value.length < 4 || !isNaN(nombre.value.charAt(0))) {
        incorrecto = true;
        nombre.classList.add("fondoRojo");
    } else {
        nombre.classList.remove("fondoRojo");
    } 

    // Validador que te lleva fuera
    if (incorrecto) {
        return;
    }
    nombreValue = nombre.value;
    partidasTotal = partidas.value;

    // Bloquear inputs y asignar span
    const partidasSpan = document.getElementById("total");
    partidasSpan.textContent = partidasTotal;

    nombre.disabled = true;
    partidas.disabled = true;

    // Asigno las fotografias de el jugador
    for (let i = 0; i < 3; i++){
        imagenes[i].src = "img/" + posibilidades[i] + "Jugador.png";
    } 
}

// Asignar el evento al botón encontrado
botonJugar.addEventListener("click", jugar);


//TODO Logica de juego, eleccion de la posibilidad vs random machine
function imageSelection(index) {
    imagenes.forEach((imagen, indexImg) => {
        if (indexImg == index) {
            imagen.classList.add("seleccionado");
            imagen.classList.remove("noSeleccionado");
        } else {
            imagen.classList.add("noSeleccionado");
            imagen.classList.remove("seleccionado");
        }
    });
}

function juego(){

    console.log(nombre + partidas + "bbb");
}



//TODO Guardar las partidas que se van jugando hasta que se pulse reset