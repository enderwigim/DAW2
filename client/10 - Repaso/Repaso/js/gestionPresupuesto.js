// TODO: Crear las funciones, objetos y variables indicadas en el enunciado

// TODO: Variable global
let presupuesto = 0;

function actualizarPresupuesto(newNumber) {
    if(!isNaN(newNumber) && newNumber >= 0) {
        presupuesto = newNumber
        return presupuesto;
    }
    return -1;
    
}

function mostrarPresupuesto() {
    return `Tu presupuesto actual es de ${presupuesto} €`
}

function CrearGasto(descripcion, valor) {
    // Devuelve una descripción
    this.descripcion = descripcion;
    // La propiedad descripción será el valor introducido, solamente si es un string.
    // this.descripcion = (typeof descripcion === "string")? descripcion : null;

    // Asignamos la propiedad valor.
    this.valor = (!isNaN(valor) && valor >= 0)? valor : 0;  

    this.mostrarGasto = function () {
        return `Gasto correspondiente a ${this.descripcion} con valor ${this.valor} €`;
    }
    this.actualizarDescripcion = function (newDescription) {
        this.descripcion = newDescription;
    }
    this.actualizarValor = function (newValue) {
        this.valor = (!isNaN(newValue) && newValue >= 0)? newValue : this.valor;
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
