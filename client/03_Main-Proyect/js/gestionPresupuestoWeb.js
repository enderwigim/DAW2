import * as gest from './gestionPresupuesto.js'


function mostrarDatoEnId(idElemento, valor){
    document.getElementById(idElemento).innerHTML = valor;
}

function mostrarGastoWeb(idElemento, gasto){
    // Get element by id
    let element = document.getElementById(idElemento);
    if (element){

        // Create gasto Div
        let gastoDiv =  document.createElement("div");
        gastoDiv.classList.add("gasto");
        
        // Create descripción
        let gastoDesc = document.createElement("div");
        gastoDesc.innerHTML = gasto.descripcion;
        gastoDesc.classList.add('gasto-descripcion');
        // Add descripción
        gastoDiv.appendChild(gastoDesc);
        
        // Create fecha
        let gastoFecha = document.createElement("div");
        gastoFecha.innerHTML = new Date(gasto.fecha).toLocaleDateString();
        gastoFecha.classList.add('gasto-fecha');
        // Add fecha
        gastoDiv.appendChild(gastoFecha);
        
        // Create value
        let gastoValue = document.createElement("div");
        gastoValue.innerHTML = gasto.valor;
        gastoValue.classList.add('gasto-valor');
        // Add Value
        gastoDiv.appendChild(gastoValue);
        
        // Create etiquetas
        let gastoEtiquetas = document.createElement("div");
        gastoEtiquetas.classList.add('gasto-etiquetas');
        
        gasto.etiquetas.forEach(etiqueta => {
            let etiquetaSpan = document.createElement("span");
            etiquetaSpan.classList.add('gasto-etiquetas-etiqueta');
            etiquetaSpan.innerHTML = etiqueta;
            
            let deleteEtiqueta = new BorrarEtiquetasHandle();
            deleteEtiqueta.gasto = gasto;
            deleteEtiqueta.etiqueta = etiqueta; 
            etiquetaSpan.addEventListener("click", deleteEtiqueta);
            
            gastoEtiquetas.appendChild(etiquetaSpan);
        })

        // Add Etiquetas
        gastoDiv.appendChild(gastoEtiquetas);
        
        let editButton = document.createElement("button");
        editButton.classList.add("gasto-editar");
        editButton.type = "button";
        editButton.innerHTML = "Editar Gasto";
        
        let editHandle = new EditarHandle();
        editHandle.gasto = gasto;
        
        editButton.addEventListener("click", editHandle);
        gastoDiv.appendChild(editButton);
        
        let deleteButton = document.createElement("button");
        deleteButton.classList.add("gasto-borrar");
        deleteButton.type = "button";
        deleteButton.innerHTML = "Borrar Gasto";
        
        let deleteHandle = new BorrarHandle();
        deleteHandle.gasto = gasto;

        deleteButton.addEventListener("click", deleteHandle);
        gastoDiv.appendChild(deleteButton);
        
        
        element.appendChild(gastoDiv);
    }
}

function mostrarGastosAgrupadosWeb(idElemento, agrup, periodo){
    let element = document.getElementById(idElemento);

    // Create DIV AND H1
    let mainDiv = document.createElement('div');
    mainDiv.classList.add("agrupacion");

    let h1 = document.createElement('h1');
    h1.innerHTML = periodo === 'anyo' ? 
                    "Gastos agrupados por año"
                    : periodo === 'mes' ?
                        "Gastos agrupados por mes"
                        : periodo === 'dia' ?
                        "Gastos agrupados por día" :
                        "ERROR - Periodo mal especificado.";
    mainDiv.appendChild(h1);
    for (const [key, value] of Object.entries(agrup)) {
        // Create div
        let keyValueDiv = document.createElement("div");
        keyValueDiv.classList.add("agrupacion-dato");
        // Create first span
        let keySpan = document.createElement("span");
        keySpan.classList.add("agrupacion-dato-clave");
        keySpan.innerHTML = key;
        // Create second span
        let valueSpan = document.createElement("span");
        valueSpan.classList.add("agrupacion-dato-valor");
        valueSpan.innerHTML = value;
        // Add spans to div
        keyValueDiv.appendChild(keySpan);
        keyValueDiv.appendChild(valueSpan);
        // Add div to mainDiv
        mainDiv.appendChild(keyValueDiv);
    }
                 
    // Add mainDiv to element
    element.appendChild(mainDiv);
}

function repintar(){
    // SHOW PRESUPUESTO
    mostrarDatoEnId("presupuesto", gest.mostrarPresupuesto());
    // SHOW GASTOS TOTALES
    mostrarDatoEnId('gastos-totales', gest.calcularTotalGastos());
    // SHOW BALANCE
    mostrarDatoEnId('balance-total', gest.calcularBalance());

    // RESET EVERY EXPENSE
    mostrarDatoEnId('listado-gastos-completo', "");

    let gastos = gest.listarGastos();
    gastos.forEach((gasto) => {
        mostrarGastoWeb('listado-gastos-completo', gasto);
    })
}

function actualizarPresupuestoWeb(){
    let newBadget = prompt("¿Cual es tu nuevo presupuesto?");
    newBadget = Number(newBadget);
    gest.actualizarPresupuesto(newBadget);
    repintar();
} 


function nuevoGastoWeb(){
    let descript = prompt("Añada una nueva descripción");
    let value = Number(prompt("Añada un costo"));
    let fecha = new Date(prompt("Añada una fecha"));
    let etiquetas = prompt("Añada etiquetas").split(",");
    let gasto = new gest.CrearGasto(descript,value,fecha,...etiquetas)
    gest.anyadirGasto(gasto);
    repintar();
}

function EditarHandle(){
    this.handleEvent = function(event){
        let newDescrip = prompt("Cambie la descripción", this.gasto.descripcion)
        let newValue = Number(prompt("Cambie el valor del gasto", this.gasto.valor));
        let newDate = (prompt("Cambie la fecha", this.gasto.fecha))
        let etiquetas = prompt("Añade etiquetas", this.gasto.etiquetas).split(",");
        this.gasto.actualizarValor(newValue);
        this.gasto.actualizarDescripcion(newDescrip);
        this.gasto.actualizarFecha(newDate);
        this.gasto.anyadirEtiquetas(...etiquetas);
        repintar();
    }
}
function BorrarHandle(){
    this.handleEvent = function(event){
        gest.borrarGasto(this.gasto.id);
        repintar();
    }
}
function BorrarEtiquetasHandle(){
    this.handleEvent = function(event){
        this.gasto.borrarEtiquetas(this.etiqueta);
        repintar();
    }
}


export {
    mostrarDatoEnId,
    mostrarGastoWeb,
    mostrarGastosAgrupadosWeb,
    repintar,
    actualizarPresupuestoWeb,
    nuevoGastoWeb,
  };