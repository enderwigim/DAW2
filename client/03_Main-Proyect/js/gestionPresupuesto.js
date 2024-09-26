
"use strict";

let presupuesto = 0;

function actualizarPresupuesto(num) {
    // TODO
    if (num < 0 || isNaN(num)) {
        return -1;
    }
    presupuesto = num;
    return presupuesto
}

function mostrarPresupuesto() {
    return `Tu presupuesto actual es de ${presupuesto} €`
}

function CrearGasto (descripcion, value) {
    
    // PROPIEDADES.
    // En caso de que el numero sea menor a 0 y/o no sea un numero. Seteamos valor a 0.
    if (value < 0 || isNaN(value)){
        this.valor = 0;
    } else {
        this.valor = value;
    }
    // Seteamos descripcion
    this.descripcion = descripcion;

    // METODOS
    this.mostrarGasto = function (){
        return `Gasto correspondiente a ${this.descripcion} con valor ${this.valor} €`
    }
    this.actualizarDescripcion = function (newDescripcion){
        this.descripcion = newDescripcion;
    }
    this.actualizarValor = function (newValue){
        if (newValue > 0){
            this.valor = newValue;
        };
    }
}

// NO MODIFICAR A PARTIR DE AQUÍ: exportación de funciones y objetos creados para poder ejecutar los tests.
// Las funciones y objetos deben tener los nombres que se indican en el enunciado
// Si al obtener el código de una práctica se genera un conflicto, por favor incluye todo el código que aparece aquí debajo
export   {
    mostrarPresupuesto,
    actualizarPresupuesto,
    CrearGasto
}
