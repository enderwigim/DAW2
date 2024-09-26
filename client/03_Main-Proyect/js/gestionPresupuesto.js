// TODO: Crear las funciones, objetos y variables indicadas en el enunciado

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

function CrearGasto(num, descripcion) {
    
    if (num < 0 || isNaN(num)){
        this.valor = 0;
    } else {
        this.valor = num;
    }
    this.descripcion = descripcion;

    this.mostrarGasto = function (){
        return `Gasto correspondiente a ${descripcion} con valor ${valor} €`
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
