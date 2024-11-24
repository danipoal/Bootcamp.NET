// Crear la instancia única de Log
// Pon tu nombre el constructor
const log = new Log("Daniel Alvarez del Reguero"); // Pon aquí tu nombre

class Pez {
    constructor(nombre, imagenPez, xInicio, yInicio, tipoMovimiento, log) {
        this.nombre = nombre;
        this.x = xInicio;
        this.y = yInicio;
        this.tipoMovimiento = tipoMovimiento;
        this.direccionX = 1;
        this.direccionY = 1;
        this.elemento = document.createElement('img');
        this.elemento.src = imagenPez;
        this.elemento.className = 'pez';
        this.velocidad = 3;
        this.log = log;
        document.getElementById('pecera').appendChild(this.elemento);
        this.elemento.style.left = `${this.x}px`;
        this.elemento.style.top = `${this.y}px`;
        this.log.registrarPez(this);
    }

    mover() {
        switch (this.tipoMovimiento) {
            case 'horizontal':
                this.moverHorizontal();
                break;
            case 'zigzag':
                this.moverZigZag();
                break;
            case 'burbujaCascada':
                this.moverBurbujaCascada();
                break;
        }
        this.actualizarPosicion();
    }

    moverHorizontal() {
        this.x += this.velocidad * this.direccionX;

        if (this.x <= 0 || this.x >= 750) {
            this.direccionX *= -1;
            this.girarPez();
        }
    }

    moverZigZag() {
        this.x += this.velocidad * this.direccionX;
        this.y += Math.sin(this.x * 0.1) * 5 * this.direccionY;

        if (this.x <= 0 || this.x >= 750) {
            this.direccionX *= -1;
            this.girarPez();
        }
        if (this.y <= 0 || this.y >= 350) {
            this.direccionY *= -1;
        }
    }

    moverBurbujaCascada() {
        this.y += this.velocidad * this.direccionY;

        if (this.y <= 0 || this.y >= 350) {
            this.direccionY *= -1;
        }
    }

    girarPez() {
        this.elemento.style.transform = `scaleX(${this.direccionX})`;
    }

    actualizarPosicion() {
        this.elemento.style.left = `${this.x}px`;
        this.elemento.style.top = `${this.y}px`;
    }
}

const peces = [
    new Pez("Rubén", 'img/pez1.png', 0, 0, 'horizontal', log),
    new Pez("Laura", 'img/pez2.png', 75, 0, 'zigzag', log),
    new Pez("Tamara", 'img/pez3.png', 100, 75, 'burbujaCascada', log),
    new Pez("Tever", 'img/pez4.png', 50, 50, 'horizontal', log),
    new Pez("Caballito", 'img/caballito.png', 25, 25, 'zigzag', log)
];

function animar() {
    peces.forEach(pez => pez.mover());
    requestAnimationFrame(animar);
}

animar();