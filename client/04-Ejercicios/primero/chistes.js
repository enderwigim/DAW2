let chistes = [
    {
	enunciado: "¿Qué le dice un bit a otro?",
	respuesta: "Nos vemos en el bus."
    },
    {
	enunciado: "¿Qué es un terapeuta?",
	respuesta: "1024 GigaPeutas."
    },
    {
	enunciado: "¿Cuántos programadores hacen falta para cambiar una bombilla?",
	respuesta: "Ninguno, porque es un problema de hardware."
    }
]

// Elemento <div> en el que se mostrarÃ¡ el listado
// Debe estar creado en el documento HTML que ejecute el script
let contenedor = document.getElementById("contenedor");

// FunciÃ³n constructora para crear los manejadores de eventos de los botones
function Manejador() {
    // MÃ©todo 'handleEvent'
    this.handleEvent = function(evento) {
	// la propiedad objetoChiste del objeto harÃ¡ referencia al objeto chiste
	alert(this.objetoChiste.respuesta);
    }
}
function ManejadorPromt(){
    this.handleEvent = function(event){
        let newEnunciado = prompt("Enunciado");
        let newRespuesta = prompt("Respuesta");
        this.oldEnunciado.innerHTML = newEnunciado;
        this.oldChiste.respuesta = newRespuesta;
    }
}

// Recorremos el array de chistes
for (let chiste of chistes) {
    let divChiste = document.createElement("div");
    // CREATE CHISTE
    let pChiste = document.createElement("p");
    pChiste.innerHTML = chiste.enunciado;
    // CREATE BUTTON
    let boton = document.createElement("button");
    boton.textContent = "Ver respuesta";
    // HANDLE EVENT BUTTON
    let manejadorBoton = new Manejador();
    manejadorBoton.objetoChiste = chiste;

    boton.addEventListener("click", manejadorBoton);
    // CREATE EDIT CHISTE
    let editChisteBut = document.createElement("button");
    editChisteBut.textContent = "Editar"

    let manejadorEditar = new ManejadorPromt();
    manejadorEditar.oldChiste = chiste;
    manejadorEditar.oldEnunciado = pChiste;

    editChisteBut.addEventListener("click", manejadorEditar);

    divChiste.append(pChiste);

    divChiste.append(boton);

    contenedor.append(divChiste);
    divChiste.append(editChisteBut);
}