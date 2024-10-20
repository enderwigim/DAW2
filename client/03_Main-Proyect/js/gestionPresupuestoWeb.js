function mostrarDatoEnId(idElemento, valor){
    document.getElementById(idElemento).innerHTML = valor;
}
function mostrarGastoWeb(idElemento, gasto){
    // Get element by id
    let element = document.getElementById(idElemento);

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
        gastoEtiquetas.appendChild(etiquetaSpan);
    })
    // Add Etiquetas
    gastoDiv.appendChild(gastoEtiquetas);

    element.appendChild(gastoDiv);
    
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
    /*
    const object = {'a': 1, 'b': 2, 'c' : 3};

    for (const [key, value] of Object.entries(object)) {
    console.log(key, value);
    }
    */
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
export {
    mostrarDatoEnId,
    mostrarGastoWeb,
    mostrarGastosAgrupadosWeb
  };