"use strict";

let presupuesto = 0;
let idGasto = 0;
let gastos = [];

function actualizarPresupuesto(num) {
  // SI EL PRESUPUESTO ES MENOR A CERO O NO ES UN TIPO NUM
  // DEVUELVE -1
  if (num < 0 || isNaN(num)) {
    return -1;
  }
  presupuesto = num;
  return presupuesto;
}

function mostrarPresupuesto() {
  //MOSTRAR PRESUPUESTO
  return `Tu presupuesto actual es de ${presupuesto} €`;
}
function listarGastos() {
  return gastos;
}
function anyadirGasto(newGasto) {
  // Agregamos el id a gasto.
  newGasto.id = idGasto;
  // Aumentamos el idGasto
  idGasto++;
  // Añadimos a gastos el gasto seleccionado.
  gastos.push(newGasto);
}
function borrarGasto(id) {
  gastos = gastos.filter((gasto) => gasto.id !== id);
}
function calcularTotalGastos() {
  let total = 0;

  for (let i = 0; i < gastos.length; i++) {
    total += gastos[i].valor;
  }
  return total;
}
function calcularBalance() {
  let balance = presupuesto - calcularTotalGastos();
  return balance;
}

function filtrarGastos({
  fechaDesde,
  fechaHasta,
  valorMinimo,
  valorMaximo,
  descripcionContiene,
  etiquetasTiene,
}) {
  let filtered = [...gastos];
  if (fechaDesde != undefined) {
    filtered = filtered.filter(
      (gasto) => Date.parse(fechaDesde) <= gasto.fecha
    );
  }
  if (fechaHasta != undefined) {
    filtered = filtered.filter(
      (gasto) => Date.parse(fechaHasta) >= gasto.fecha
    );
  }
  if (valorMinimo != undefined) {
    filtered = filtered.filter((gasto) => valorMinimo < gasto.valor);
  }
  if (valorMaximo != undefined) {
    filtered = filtered.filter((gasto) => valorMaximo > gasto.valor);
  }
  if (descripcionContiene != undefined) {
    filtered = filtered.filter((gasto) =>
      gasto.descripcion
        .toLowerCase()
        .includes(descripcionContiene.toLowerCase())
    );
  }
  if (etiquetasTiene != undefined && etiquetasTiene.length > 0) {
    filtered = filtered.filter((producto) =>
      etiquetasTiene.some((etiqueta) => producto.etiquetas.includes(etiqueta))
    );
  }
  return filtered;
}

function agruparGastos(
  periodo = "mes", etiquetas = [],
  fechaDesde = undefined, fechaHasta = undefined,
) {
  console.log("Gastos todos:", fechaHasta);
  let filtered = filtrarGastos({
    fechaDesde: fechaDesde,
    fechaHasta: fechaHasta,
    etiquetasTiene: etiquetas,
  });

  console.log("Gastos filtrados:", filtered);

  let gastosAgrupados = filtered.reduce((acumulador, gasto) => {
    let periodoGasto = gasto.obtenerPeriodoAgrupacion(periodo);
    console.log("Periodo de agrupación:", periodoGasto);
    if (acumulador[periodoGasto] == undefined) {
      acumulador[periodoGasto] = 0;
    }

    acumulador[periodoGasto] += gasto.valor;


    return acumulador;
  }, {});
  return gastosAgrupados;
}

// FUNCION CONSTRUCTORA DE GASTO
// Revisar por defecto.
function CrearGasto(descripcion, value, date, ...etiquetas) {
  // PROPIEDADES.
  // En caso de que el numero sea menor a 0 y/o no sea un numero. Seteamos valor a 0.
  this.valor = (value < 0 || isNaN(value)) ? 0 : Number(value);

  // Seteamos descripcion
  this.descripcion = descripcion;

  this.fecha = isNaN(Date.parse(date)) ? Date.now() : Date.parse(date);

  this.etiquetas = etiquetas.length > 0 ? [...etiquetas] : [];

  // METODOS
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

  this.mostrarGasto = function () {
    return `Gasto correspondiente a ${this.descripcion} con valor ${this.valor} €`;
  };
  this.actualizarDescripcion = function (newDescripcion) {
    this.descripcion = (newDescripcion != undefined )? newDescripcion : this.descripcion; 
    
  };
  this.actualizarValor = function (newValue) {
    if (newValue >= 0 && !isNaN(newValue)) {
      this.valor = newValue;
    }
  };
  this.actualizarFecha = function (date) {
    this.fecha = isNaN(Date.parse(date)) ? this.fecha : Date.parse(date);
  };
  this.anyadirEtiquetas = function (...nuevasEtiqueta) {
    if (nuevasEtiqueta.length > 0) {
      let etiquetasAnyadir = nuevasEtiqueta.filter(
        (etiqueta) => !this.etiquetas.includes(etiqueta)
      );
      this.etiquetas = [...this.etiquetas, ...etiquetasAnyadir];
    }
    
  };
  this.borrarEtiquetas = function (...etiquetasBorrar) {
    this.etiquetas = this.etiquetas.filter(
      (etiqueta) => !etiquetasBorrar.includes(etiqueta)
    );
  };
  this.obtenerPeriodoAgrupacion = function (datePeriod) {
    // Obtenemos la fecha en objeto Date.
    let dateDate = new Date(this.fecha);
    let ret = "";

    if (datePeriod == "anyo") {
      ret = dateDate.getFullYear();
    }
    if (datePeriod == "mes") {
      ret = `${dateDate.getFullYear()}-${(
        "0" +
        (dateDate.getMonth() + 1)
      ).slice(-2)}`;
    }
    if (datePeriod == "dia") {
      ret = `${dateDate.getFullYear()}-${(
        "0" +
        (dateDate.getMonth() + 1)
      ).slice(-2)}-${("0" + dateDate.getDate()).slice(-2)}`;
    }
    return ret;
  };
}

// NO MODIFICAR A PARTIR DE AQUÍ: exportación de funciones y objetos creados para poder ejecutar los tests.
// Las funciones y objetos deben tener los nombres que se indican en el enunciado
// Si al obtener el código de una práctica se genera un conflicto, por favor incluye todo el código que aparece aquí debajo
export {
  mostrarPresupuesto,
  actualizarPresupuesto,
  CrearGasto,
  listarGastos,
  anyadirGasto,
  borrarGasto,
  calcularTotalGastos,
  calcularBalance,
  filtrarGastos,
  agruparGastos,
};
