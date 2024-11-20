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
function filtrarGastos({fechaDesde, fechaHasta, valorMinimo, valorMaximo, descripcionContiene, etiquetasTiene}){
    let gastosFiltrados = [...gastos];
    if (fechaDesde != undefined){
        gastosFiltrados = gastosFiltrados.filter(
            (gasto) => 
            gasto.fecha >= Date.parse(fechaDesde)
        )
    }
    if (fechaHasta != undefined && !isNaN(Date.parse(fechaHasta))){
        gastosFiltrados = gastosFiltrados.filter((gasto) => 
            gasto.fecha <= Date.parse(fechaHasta)
        )
    }
    if (valorMinimo != undefined && !isNaN(valorMinimo)) {
        gastosFiltrados = gastosFiltrados.filter((gasto) => 
            gasto.valor >= valorMinimo
        )
    }
    if (valorMaximo != undefined && !isNaN(valorMaximo)) {
        gastosFiltrados = gastosFiltrados.filter((gasto) => 
            gasto.valor <= valorMaximo
        )
    }
    if (descripcionContiene != undefined && descripcionContiene != ""){
        gastosFiltrados = gastosFiltrados.filter((gasto) => 
            gasto.descripcion.toUpperCase().includes(descripcionContiene.toUpperCase())
        )
    }
    if (etiquetasTiene != undefined && etiquetasTiene.length > 0) {
        gastosFiltrados = gastosFiltrados.filter((gasto) => 
            etiquetasTiene.some(
                (etiqueta) => {
                    return gasto.etiquetas.includes(etiqueta);
                }
            )
        )
    }
    return gastosFiltrados;
}
function agruparGastos(periodo = "mes", etiquetas = [], fechaDesde = undefined, fechaHasta = undefined){
    let gastosFiltrados = filtrarGastos({fechaDesde: fechaDesde, fechaHasta: fechaHasta,
                                        etiquetasTiene: etiquetas})
    let agrupados = gastosFiltrados.reduce((acc, gasto) => {
        if(acc[gasto.obtenerPeriodoAgrupacion(periodo)] === undefined) {
            acc[gasto.obtenerPeriodoAgrupacion(periodo)] = 0;
        }
        acc[gasto.obtenerPeriodoAgrupacion(periodo)] += gasto.valor;
        
        return acc;
    }, {})
    return agrupados;
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
    // Etiquetas
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
    // Agrupacion
    this.obtenerPeriodoAgrupacion = function (tipoFecha = "mes") {
        let ret;
        let fecha = new Date(this.fecha);
        if (tipoFecha === "anyo") {
            ret = fecha.getFullYear();
        }
        else if (tipoFecha === "mes") {
            ret = `${fecha.getFullYear()}-${("0" + (fecha.getMonth() + 1)).slice(-2)}`
        }
        else if (tipoFecha === "dia") {
            ret = `${fecha.getFullYear()}-${(
                "0" +
                (fecha.getMonth() + 1)
              ).slice(-2)}-${("0" + fecha.getDate()).slice(-2)}`;

            //ret = fecha.getFullYear() + "-0" + fecha.getMonth() + 1

            //ret = `${fecha.getFullYear()}-${(fecha.getMonth() + 1).slice(-2)}-${fecha.getDate()}`;
        }
        return ret;
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
    listarGastos,
    filtrarGastos,
    agruparGastos 
}
