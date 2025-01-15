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
        gastoFecha.innerHTML = new Date(gasto.fecha).toLocaleDateString('es-ES');
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

        // CREAR BOTONES API

        let gasto_borrar_api = document.createElement("button");
        gasto_borrar_api.classList.add("gasto-borrar-api")
        gasto_borrar_api.innerHTML = "Gasto Borrar Api"

        let gasto_event = new deleteGastoEvent();
        gasto_event.gasto = gasto;

        gasto_borrar_api.addEventListener("click", gasto_event);
        gastoDiv.appendChild(gasto_borrar_api);

        // let gasto_editar_api = document.createElement("button");
        // gasto_editar_api.innerHTML = "Gasto Editar Api"
        // gasto_borrar_api.classList.add("gasto-editar-formulario");
        // gastoDiv.appendChild(gasto_editar_api);
        
        let editButtonForm = document.createElement("button");
        editButtonForm.classList.add("gasto-editar-formulario");
        editButtonForm.type = "button";
        editButtonForm.innerHTML = "Editar (Formulario)"

        let editButtonFormHandle = new EditarHandleFormulario();
        editButtonFormHandle.gasto = gasto;
        editButtonFormHandle.gastoDiv = gastoDiv;
        editButtonFormHandle.button = editButtonForm;

        editButtonForm.addEventListener("click", editButtonFormHandle);

        gastoDiv.appendChild(editButtonForm);
        
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

// EVENT HANDLERS
function CancelHandler(){
    this.handleEvent = function() {
        this.button.removeAttribute("disabled");
        
        this.formulario.remove();


    }
}

function SubmitNewHandler(){
    this.handleEvent = function(event) {
        // PREVENT EVENT DEFAULT
        event.preventDefault();
        let formulario = event.currentTarget;
        // GATHER DATA
        let newDescrip = formulario.elements.descripcion.value;
        let newValor = formulario.elements.valor.value;
        let newFecha = formulario.elements.fecha.value;
        let newEtiqueta = (formulario.elements.etiquetas.value == null)? null : formulario.elements.etiquetas.value.split(",");

        // CREATE GASTO
        let newGasto = new gest.CrearGasto(newDescrip,newValor,newFecha,...newEtiqueta);
        gest.anyadirGasto(newGasto);    

        let activate = document.getElementById("anyadirgasto-formulario");
        activate.removeAttribute("disabled");
        repintar();
        this.formulario.remove();
    }
}
function SubmitEditHandler() {
    this.handleEvent = function(event) {
        event.preventDefault();
        let formulario = event.currentTarget;

        // GATHER DATA
        let newDescrip = formulario.elements.descripcion.value;
        let newValor = (isNaN(formulario.elements.valor.value))? this.gasto : Number(formulario.elements.valor.value);
        let newFecha = formulario.elements.fecha.value;
        let newEtiqueta = (formulario.elements.etiquetas.value == "")? undefined : formulario.elements.etiquetas.value.split(",");

        this.gasto.actualizarDescripcion(newDescrip);
        this.gasto.actualizarValor(newValor);
        this.gasto.actualizarFecha(newFecha);
        this.gasto.anyadirEtiquetas(newEtiqueta);

        
        this.button.removeAttribute("disabled");

        repintar();
        this.formulario.remove();
    }
}
// function NuevoGastoWebFormulario(){
//     this.handleEvent = function() {
//         // GET FORMULARIO
//         let plantillaFormulario = document.getElementById("formulario-template").content.cloneNode(true);
//         var formulario = plantillaFormulario.querySelector("form");

//         // DISABLE anyadirgasto-formulario BUTTON
//         let activate = document.getElementById("anyadirgasto-formulario");
//         activate.setAttribute("disabled",true);

//         // CREATE SUBMIT HANDLER
//         let submitHandler = new SubmitNewHandler();
//         submitHandler.formulario = formulario;

//         formulario.addEventListener("submit", submitHandler);

//         // GET CANCELBUTTON
//         let cancelButton = formulario.querySelector("button.cancelar");

//         // CREATE CANCEL HANDLER
//         let cancelHandler = new CancelHandler();
//         cancelHandler.formulario = formulario;
//         cancelHandler.button = activate;

//         cancelButton.addEventListener("click", cancelHandler);

//         let submitApiButton = formulario.querySelector("button.gasto-enviar-api")
//         let submitNewHandler = new SubmitNewApiHandler();
//         submitHandler.formulario = formulario
        
//         submitApiButton.addEventListener("click", submitNewHandler);

//         let div = document.getElementById("controlesprincipales");
//         div.append(formulario);
//     }
// }

// ADD EVENT TO anyadir-formulario
let addForm = document.getElementById("anyadirgasto-formulario");
let addFormHandler = new NuevoGastoWebFormulario();
addForm.addEventListener("click", addFormHandler);

function EditarHandle(){
    this.handleEvent = function(event){
        let newDescrip = prompt("Cambie la descripción", this.gasto.descripcion)
        let newValue = Number(prompt("Cambie el valor del gasto", this.gasto.valor));
        let newDate = (prompt("Cambie la fecha formato: yyyy-mm-dd", new Date(this.gasto.fecha).toISOString().slice(0, 10)));
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

function filtrarGastosWeb(event) {

        event.preventDefault();
        
        var formulario = event.currentTarget;
        // GET ETIQUETAS FROM
        let etiquetasForm = formulario.elements["formulario-filtrado-etiquetas-tiene"].value;
        let fechaDesde = formulario.elements["formulario-filtrado-fecha-desde"].value;
        let fechaHasta = formulario.elements["formulario-filtrado-fecha-hasta"].value;
        let valorMinimo = formulario.elements["formulario-filtrado-valor-minimo"].value;
        let valorMaximo = formulario.elements["formulario-filtrado-valor-maximo"].value;
        let descripcionContiene = formulario.elements["formulario-filtrado-descripcion"].value;



        let filterObject = {
            fechaDesde: (fechaDesde != "")? fechaDesde : undefined,
            fechaHasta: (fechaHasta != "")? fechaHasta : undefined,
            valorMinimo : (valorMinimo != "")? valorMinimo : undefined,
            valorMaximo : (valorMaximo != "")? valorMaximo : undefined,
            descripcionContiene: (descripcionContiene != "")? descripcionContiene : undefined,
            etiquetasTiene: (etiquetasForm != "")? gest.transformarListadoEtiquetas(etiquetasForm) : undefined
          }
        
        let gastosFiltrados = gest.filtrarGastos(filterObject);
        // Vaciamos listado-gastos-completo
        document.getElementById("listado-gastos-completo").innerHTML = "";

        // Actualizamos listado-gastos-completo con lo filtrado.
        gastosFiltrados.forEach((gasto) => mostrarGastoWeb("listado-gastos-completo", gasto));

    
}
let filtrarform = document.getElementById("formulario-filtrado");
filtrarform.addEventListener("submit", filtrarGastosWeb);
// PRACTICA 8
function guardarGastosWeb() {
    localStorage.setItem("GestorGastosDWEC", JSON.stringify(gest.listarGastos()));
}

let guardarGastosButton = document.getElementById("guardar-gastos");
guardarGastosButton.addEventListener("click", guardarGastosWeb);

function cargarGastosWeb() {
    let gastosCargados = [];
    if (localStorage.GestorGastosDWEC != undefined) {
        gastosCargados = JSON.parse(localStorage.getItem("GestorGastosDWEC"));
    }
    gest.cargarGastos(gastosCargados);
    repintar();
}

let cargarGastosButton = document.getElementById("cargar-gastos");
cargarGastosButton.addEventListener("click", cargarGastosWeb);

// PRACTICA 9
function getGastosById() {
    let userName = document.getElementById("nombre-usuario").value;
    let url = `https://suhhtqjccd.execute-api.eu-west-1.amazonaws.com/latest/${userName}`
    // let response = await fetch(url);
    // if (response.ok) {
    //     let data = await response.json();
    //     gest.cargarGastos(data);
    //     repintar();
    // } else {
    //     alert("Error-HTTP: " + response.status);
    // }
    fetch(url)
        .then((response) => {
            if (!response.ok) {
                throw Error(`Error HTTP: ${response.status}`);
            }
            return response.json();
        })
        .then((data) => {
            gest.cargarGastos(data);
            repintar()
            
        })
        .catch((error) => {
            alert(error.message);
        })

        }

function deleteGastoEvent() {
    this.handleEvent = function(event){
        let userName = document.getElementById("nombre-usuario").value;
        let url = `https://suhhtqjccd.execute-api.eu-west-1.amazonaws.com/latest/${userName}/${this.gasto.gastoId}`;
        fetch(url, {
            method: "DELETE"
        })
            .then((response) => {

                if (!response.ok) {
                    throw Error(`Error HTTP: ${response.status}`);
                }
                gest.borrarGasto(this.gasto.gastoId);
                
            })
            .catch((error) => {
                alert(error.message);
            })
            .finally(() => {
                getGastosById();
            })
    }
}


function SubmitEditApiHandler() {
    this.handleEvent = function(event) {
        let formulario = this.formulario;

        // GATHER DATA
        let newDescrip = formulario.elements.descripcion.value;
        let newValor = (isNaN(formulario.elements.valor.value))? this.gasto : Number(formulario.elements.valor.value);
        let newFecha = (formulario.elements.fecha.value == "")? undefined : formulario.elements.fecha.value;
        let newEtiqueta = (formulario.elements.etiquetas.value == "")? undefined : formulario.elements.etiquetas.value.split(",");

        if (!newDescrip || !newValor || isNaN(Number(newValor))) {
            alert("Por favor, completa todos los campos correctamente.");
            return;
        }

        // UPDATE DATA
        this.gasto.actualizarDescripcion(newDescrip);
        this.gasto.actualizarValor(newValor);
        this.gasto.actualizarFecha(newFecha);
        if (newEtiqueta != undefined) {
            this.gasto.etiquetas = [...newEtiqueta];
        } else {
            this.gasto.etiquetas = [];
        }


        let userName = document.getElementById("nombre-usuario").value;
        let url = `https://suhhtqjccd.execute-api.eu-west-1.amazonaws.com/latest/${userName}/${this.gasto.gastoId}`;
        fetch(url, {
            method: "PUT",
            // HEADER SETEA EL TIPO DE CONTENIDO A RECIBIR
            headers: {
                "Content-Type": "application/json"
            },
            // LO ENVIO A TRAVÉS DEL BODY
            body: JSON.stringify(this.gasto)
        })
            .then((response) => {

                if (!response.ok) {
                    throw Error(`Error HTTP: ${response.status}`);
                }
                getGastosById();
            })
            .catch((error) => {
                alert(error.message);
            });
        
        this.button.removeAttribute("disabled");
        this.formulario.remove();
        
    }
}

function EditarHandleFormulario(){
    this.handleEvent = function(){
        // GET FORMULARIO
        let plantillaFormulario = document.getElementById("formulario-template").content.cloneNode(true);
        var formulario = plantillaFormulario.querySelector("form");

        // GET DATA FROM GASTO AND ADD IT TO THE FORM
        let nombreGasto = this.gasto.descripcion;
        let valor = this.gasto.valor.toString();
        let date = this.gasto.fecha
        let etiquetasGasto = this.gasto.etiquetas.toString();

        let nombreInput = formulario.querySelector("#descripcion")
        nombreInput.value = nombreGasto;
        let valorInput = formulario.querySelector("#valor")
        valorInput.value = valor;

        let etiquetasInput = formulario.querySelector("#etiquetas");
        etiquetasInput.value = etiquetasGasto;


        // CREATE SUBMIT HANDLER
        let submitHandler = new SubmitEditHandler();
        submitHandler.formulario = formulario;
        submitHandler.gasto = this.gasto;
        submitHandler.button = this.button;

        let submitApi = formulario.querySelector("button.enviar");


        submitApi.addEventListener("submit", submitHandler);

        // GET CANCELBUTTON
        let cancelButton = formulario.querySelector("button.cancelar");

        // CREATE CANCEL HANDLER
        let cancelHandler = new CancelHandler();
        cancelHandler.formulario = formulario;
        cancelHandler.button = this.button;

        cancelButton.addEventListener("click", cancelHandler)
        
        // CREATE SUBMIT API
        let submitApiButton = formulario.querySelector("button.gasto-enviar-api");
        
        let submitApiHandler = new SubmitEditApiHandler();
        submitApiHandler.formulario = formulario;
        submitApiHandler.gasto = this.gasto;
        submitApiHandler.button = this.button;
        
        submitApiButton.addEventListener("click", submitApiHandler);
        
        
        
        this.button.setAttribute("disabled", true)
        this.gastoDiv.append(formulario);
    }
}

function SubmitNewApiHandler() {
    this.handleEvent = function(event) {
        let formulario = this.formulario;

        // GATHER DATA
        let newDescrip = formulario.elements.descripcion.value;
        let newValor = (isNaN(formulario.elements.valor.value))? this.gasto : Number(formulario.elements.valor.value);
        let newFecha = (formulario.elements.fecha.value == "")? undefined : formulario.elements.fecha.value;
        let newEtiqueta = (formulario.elements.etiquetas.value == "")? [] : formulario.elements.etiquetas.value.split(",");

        if (!newDescrip || !newValor || isNaN(Number(newValor))) {
            alert("Por favor, completa todos los campos correctamente.");
            return;
        }

        let gasto = new gest.CrearGasto(newDescrip,newValor,newFecha,...newEtiqueta);
        

        let userName = document.getElementById("nombre-usuario").value;
        let url = `https://suhhtqjccd.execute-api.eu-west-1.amazonaws.com/latest/${userName}`;
        fetch(url, {
            method: "POST",
            // HEADER SETEA EL TIPO DE CONTENIDO A RECIBIR
            headers: {
                "Content-Type": "application/json"
            },
            // LO ENVIO A TRAVÉS DEL BODY
            body: JSON.stringify(gasto)
        })
            .then((response) => {

                if (!response.ok) {
                    throw Error(`Error HTTP: ${response.status}`);
                }
                getGastosById();
            })
            .catch((error) => {
                alert(error.message);
            });
        
        this.button.removeAttribute("disabled");
        this.formulario.remove();
        
    }
}

function NuevoGastoWebFormulario(){
    this.handleEvent = function() {
        // GET FORMULARIO
        let plantillaFormulario = document.getElementById("formulario-template").content.cloneNode(true);
        var formulario = plantillaFormulario.querySelector("form");

        // DISABLE anyadirgasto-formulario BUTTON
        let activate = document.getElementById("anyadirgasto-formulario");
        activate.setAttribute("disabled",true);

        // CREATE SUBMIT HANDLER
        let submitHandler = new SubmitNewHandler();
        submitHandler.formulario = formulario;

        formulario.addEventListener("submit", submitHandler);

        // GET CANCELBUTTON
        let cancelButton = formulario.querySelector("button.cancelar");

        // CREATE CANCEL HANDLER
        let cancelHandler = new CancelHandler();
        cancelHandler.formulario = formulario;
        cancelHandler.button = activate;

        cancelButton.addEventListener("click", cancelHandler);

        let submitApiButton = formulario.querySelector("button.gasto-enviar-api")
        let submitNewHandler = new SubmitNewApiHandler();
        submitNewHandler.formulario = formulario;
        submitNewHandler.button = activate;
        
        submitApiButton.addEventListener("click", submitNewHandler);

        let div = document.getElementById("controlesprincipales");
        div.append(formulario);
    }
}

let cargarApiBtn = document.getElementById("cargar-gastos-api");
cargarApiBtn.addEventListener("click", getGastosById);

export {
    mostrarDatoEnId,
    mostrarGastoWeb,
    mostrarGastosAgrupadosWeb,
    repintar,
    actualizarPresupuestoWeb,
    nuevoGastoWeb,
  };