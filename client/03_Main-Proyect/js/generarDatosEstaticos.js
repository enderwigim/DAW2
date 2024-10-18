import * as gest from './gestionPresupuesto.js'
import * as web from './gestionPresupuestoWeb.js'

// SET PRESUPUESTO
gest.actualizarPresupuesto(1500);
web.mostrarDatoEnId('presupuesto', gest.mostrarPresupuesto())

// CREATE GASTOS
let newGastos = [];
newGastos.push(new gest.CrearGasto("Compra carne", 23.44, "2021-10-06", "casa", "comida"),
               new gest.CrearGasto("Compra fruta y verdura", 14.25, "2021-09-06", "supermercado", "comida"),    
               new gest.CrearGasto("Bonobús", 18.60, "2020-05-26", "transporte"),
               new gest.CrearGasto("Gasolina", 60.42, "2021-10-08", "transporte", "gasolina"),
               new gest.CrearGasto("Seguro hogar", 206.45, "2021-09-26", "casa", "seguros"),
               new gest.CrearGasto("Seguro coche", 195.78, "2021-10-06", "transporte", "seguros"),
            );

// ADD GASTOS
newGastos.forEach(gasto => gest.anyadirGasto(gasto));

// SHOW GASTOS TOTALES
web.mostrarDatoEnId('gastos-totales', gest.calcularTotalGastos());
// SHOW BALANCE
web.mostrarDatoEnId('balance-total', gest.calcularBalance());

// SHOW GASTOS
let gastos = gest.listarGastos() 
gastos.forEach((gasto) => {
   web.mostrarGastoWeb('listado-gastos-completo', gasto);
})

// SHOW FILTERED GASTOS SEPTEMBER
let gastosFiltradosSep = gest.filtrarGastos({
   fechaDesde: "2021-09-01",
   fechaHasta: "2021-09-30",
});
gastosFiltradosSep.forEach((gasto) => {
   web.mostrarGastoWeb('listado-gastos-filtrado-1', gasto);
})

// SHOW GASTOS > 50 EUROS
let gastosFiltrados50 = gest.filtrarGastos({
   valorMinimo: 50,
});
gastosFiltrados50.forEach((gasto) => {
   web.mostrarGastoWeb('listado-gastos-filtrado-2', gasto);
})

// SHOW GASTOS < 200 EUROS
let gastosFiltrados200 = gest.filtrarGastos({
   valorMinimo: 200,
   etiquetasTiene: ['seguros'],
})
gastosFiltrados200.forEach((gasto) => {
   web.mostrarGastoWeb('listado-gastos-filtrado-3', gasto);
})

// SHOW GASTOS < 50 EUROS && ETIQUETAS
let gastosFiltradosMenor50 = gest.filtrarGastos({
   valorMaximo: 50,
   etiquetasTiene: ['comida', 'transporte'],
})
gastosFiltradosMenor50.forEach((gasto) => {
   web.mostrarGastoWeb('listado-gastos-filtrado-4', gasto);
})