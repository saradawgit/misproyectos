/* 
    Alumna: Sara Reyes Grao
    Ejercicios JavaScript: Calculadora
*/


/* VARIABLES */
const pantalla = document.querySelector(".pantalla"); // Capturamos la pantalla donde se muestran los números

const botones = document.querySelectorAll(".btn"); // Capturamos todos los botones, devuelve un array

let error = false; // Variable para cuando se produce un error

/* FUNCIONES */
function mostrarPantalla (valor) {
    pantalla.textContent = valor; // Mostramos por pantalla el valor que se indique
}

function manejarClick (botonPulsado) {

    // Dependiendo del botón que se pulse, se hará una cosa u otra
    if (error) {
        error = false; 
        mostrarPantalla("0"); 
    }

    if (botonPulsado === "C") { // Si se pulsa la C, reseteamos a cero
        mostrarPantalla("0"); 

    } else if (botonPulsado === "←") { // Si se pulsa borrar, se borra el último dígito
        pantalla.textContent = pantalla.textContent.slice(0, -1) || "0";

    } else if (botonPulsado === "=") { // Si se pulsa el igual se muestra el resultado
        try { // Se manejan posibles errores de entradas no válidas
            const resultado = Function('"use strict"; return (' + pantalla.textContent + ')')();
            mostrarPantalla(resultado);
        } catch {
            mostrarPantalla("¡Error!"); // Si no se puede realizar la operación, se muestra un mensaje
            error = true;
        }
    } else {
        pantalla.textContent = 
            pantalla.textContent === "0" ? botonPulsado : pantalla.textContent + botonPulsado; // Omitimos el cero a la izquierda. Sino, se van concatenando los números
    }
}

// Capturamos el evento click para cada botón
botones.forEach(boton => {
    boton.addEventListener("click", () => {
        manejarClick(boton.textContent);
    });
});

