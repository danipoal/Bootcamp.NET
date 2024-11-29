// Este array no se puede modificar,
var posibilidades = ["piedra", "papel", "tijera"];
//    //
let nombreValue = "jugador";
let partidasTotal = 0;
let partidaActual = 0;

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
    // Asigno las fotografias de el jugador
for (let i = 0; i < 3; i++){
    imagenes[i].src = "img/" + posibilidades[i] + "Jugador.png";
} 
// Obtengo tambien el span del historial
const historySpan = document.querySelector("#historial");

// Coloco la funcion de seleccion de el la posibilidad 
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
}

// Asignar el evento al botón encontrado
botonJugar.addEventListener("click", jugar);


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

function juegoYa(){

    // Si las partida actual ya es el numero total, no se hacen
    if (partidasTotal == partidaActual) {
        return ;
    }

    // Generar opcion aleatoria en maquina
    const numeroAleatorio = Math.floor(Math.random() * 3);
    let numJugador;

    // Colocar imagen maquina
    maquinaImg.src = "img/" + posibilidades[numeroAleatorio] + "Ordenador.png";

    // Sacar el numero elegido por el jugador
    imagenes.forEach((imagen, index) => {
        if (imagen.classList.contains("seleccionado")) {
            numJugador = index;
        }
    })

    // Logica de el juego
    let jugHand = posibilidades[numJugador];
    let machHand = posibilidades[numeroAleatorio];
    let ganador;

    // Se que el enunciado ponia de hacerlo como que la posicion mayor del array gana, pero me parecia poco visual
    // Tambien podria haber añadido un enum, pero al final como era simple lo he hecho asi
    if (jugHand == machHand){
        ganador = "Empate";
    } else if ((jugHand == "piedra" && machHand == "papel") || (jugHand == "papel" && machHand == "tijera") || (jugHand == "tijera" && machHand == "piedra")) {
        ganador = "Gana la maquina";
    } else {
        ganador = "Gana " + nombreValue;
    }
    addHistorial(ganador);
}

function addHistorial(ganador) {
    // Actualizamos el historial
    historySpan.textContent += partidaActual + ": "+ganador +" ";

    // Actualizamos el numero de partida por el que vamos
    partidaActualSpan = document.getElementById("actual");
    partidaActual++;
    partidaActualSpan.textContent = partidaActual;
}

botonYa.addEventListener("click", juegoYa)



//TODO Guardar las partidas que se van jugando incluso si se pulsa reset

function reset() {
    const nombre = document.querySelector('input[name="nombre"]');
    const partidas = document.querySelector('input[name="partidas"]');

    nombre.disabled = false;
    partidas.disabled = false;

    partidaActual = 0;
    document.getElementById("actual").textContent = partidaActual;

    maquinaImg.src = "img/defecto.png";

}

botonReset.addEventListener("click", reset)
