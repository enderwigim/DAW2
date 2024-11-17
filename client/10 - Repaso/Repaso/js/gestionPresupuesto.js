// TODO: Crear las funciones, objetos y variables indicadas en el enunciado

// TODO: Variable global
let presupuesto = 0;
let gastos = [];
let idGasto = 0;

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
function anyadirGasto(gasto){
    gasto.id = idGasto;
    gastos.push(gasto)
    idGasto++;
}
function borrarGasto(id){
    let index = gastos.findIndex(gasto =>
                            gasto.id === id)
    if(index !== -1) {
        gastos.splice(index,1);
    }
}
function calcularBalance(){
    return presupuesto - calcularTotalGastos();
}
function calcularTotalGastos(){
    let total = 0;
    gastos.forEach((gasto) => {
        total += gasto.valor;
    })
    return total;
}
function listarGastos(){
    return gastos;
}

function CrearGasto(descripcion, valor, fecha, ...etiquetas) {
    // PROPIEDADES
    // Devuelve una descripción
    this.descripcion = descripcion;
    // La propiedad descripción será el valor introducido, solamente si es un string.
    // this.descripcion = (typeof descripcion === "string")? descripcion : null;

    // Asignamos la propiedad valor.
    this.valor = (!isNaN(valor) && valor >= 0)? valor : 0;  


    // Asignamos propiedad fecha
    this.fecha = (isNaN(Date.parse(fecha)))? new Date() : Date.parse(fecha);

    this.etiquetas = (etiquetas.length < 1)? [] : etiquetas;

    // FUNCIONES
    // VISUALES
    this.mostrarGasto = function () {
        return `Gasto correspondiente a ${this.descripcion} con valor ${this.valor} €`;
    }
    this.mostrarGastoCompleto = function () {
        let etiquetasText = "";
        for (let i = 0; i < this.etiquetas.length; i++) {
          etiquetasText += `- ${etiquetas[i]}\n`;
        }
    
        return `Gasto correspondiente a ${this.descripcion} con valor ${
          this.valor
        } €.\nFecha: ${new Date(
          this.fecha
        ).toLocaleString()}\nEtiquetas:\n${etiquetasText}`;
      };
    // CAMBIO DE PROPIEDADES
    this.actualizarDescripcion = function (newDescription) {
        this.descripcion = newDescription;
    }
    this.actualizarValor = function (newValue) {
        this.valor = (!isNaN(newValue) && newValue >= 0)? newValue : this.valor;
    }
    this.actualizarFecha = function (newFecha) {
        this.fecha = isNaN(Date.parse(newFecha))? this.fecha : Date.parse(newFecha);
    }

    this.anyadirEtiquetas = function (...etiquetas) {
        etiquetas.forEach(
            etiqueta => {
                if (!this.etiquetas.includes(etiqueta)) {
                    this.etiquetas.push(etiqueta);
                }
            }
        )
    }
    this.borrarEtiquetas = function (...etiquetas) {
        etiquetas.forEach(
            etiqueta => {
                if (this.etiquetas.includes(etiqueta)){
                    let index = this.etiquetas.indexOf(etiqueta);
                    this.etiquetas.splice(index, 1);
                }
            }
        )
    }
}

// NO MODIFICAR A PARTIR DE AQUÍ: exportación de funciones y objetos creados para poder ejecutar los tests.
// Las funciones y objetos deben tener los nombres que se indican en el enunciado
// Si al obtener el código de una práctica se genera un conflicto, por favor incluye todo el código que aparece aquí debajo
export   {
    mostrarPresupuesto,
    actualizarPresupuesto,
    CrearGasto,
    anyadirGasto,
    borrarGasto,
    calcularBalance,
    calcularTotalGastos,
    listarGastos
}
