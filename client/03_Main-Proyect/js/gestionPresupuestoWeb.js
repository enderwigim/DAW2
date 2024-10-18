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
    gastoFecha.innerHTML = new Date(gasto.fecha);
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
    let elemento = document.getElementById(idElemento);

    // Create DIV AND H1
    let h1 = document.createElement('h1');
    h1.innerHTML = periodo === 'anyo' ? 
                    "Gastos agrupados por año"
                    : periodo === 'mes' ?
                        "Gastos agrupados por mes"
                        : periodo === 'dia' ?
                        "Gastos agrupados por día" :
                        "ERROR - Periodo mal especificado."
    

}
export {
    mostrarDatoEnId,
    mostrarGastoWeb,
    mostrarGastosAgrupadosWeb
  };