"use strict";

// GLOBAL VARIABLES
let empleadoId = 0;
let empleados =  [];

// FUNCIONES SOBRE EL ARRAY EMPLEADOS
function anyadirEmpleado(empleado) {
    empleado.id = empleadoId;
    empleados.push(empleado);
    empleadoId++;
}
// EMPLOYEE
function CrearEmpleado(nombre, apellidos, nif, edad, puesto, salario, antiguedad) {
    this.nombre = nombre;
    this.apellidos = apellidos;
    this.nif = nif;
    this.edad = isNaN(edad)? undefined : edad;
    this.puesto = puesto;
    this.salario = isNaN(salario)? 1000 : salario;
    this.antiguedad = isNaN(antiguedad)? 0 : antiguedad;
}

/*

insertará un encabezado h1 con id tituloH1 con la frase "Listado de Empleados" 
creará una lista ordenada con el id listaOrd y con la clase "rounded-list"
 A continuación con un bucle se irá recorriendo el array global de empleados para ir 
llamando a la función muestraEmpleado a la que se le pasará un empleado como argumento y 
que se describe a continuación.
 ·         
También esta función nos servirá para repintar. Así que al principio de la misma podemos 
comprobar con if si tenemos los divs no son nulos y así hacer un borrado del contenido antes de 
pintarlo.
*/

function muestraWeb() {
    let divEmple = document.getElementById("divEmple");
    divEmple.innerHTML = "";

    // CREATE H1
    let h1 = document.createElement("h1");
    h1.id = "tituloH1";
    h1.innerHTML = "Listado de Empleados"
    // ADD H1
    divEmple.append(h1);

    // CREATE OL
    let ol = document.createElement("ol");
    ol.id = "listaOrd";
    ol.classList.add("rounded-list");
    divEmple.append(ol);
    
    empleados.forEach(empleado => muestraEmpleado(empleado));
    // ADD OL
    
}

function muestraEmpleado(empleado) {
    let ol = document.getElementById("listaOrd");

    let li = document.createElement("li");
    li.id = `li${empleado.id}`;

    // CREATE DIV
    let div = document.createElement("div");
    div.id = empleado.id;
    div.classList.add("empleado");

    // CREATE P WITH DATA
    let pNombre = document.createElement("p");
    pNombre.innerHTML = `${empleado.nombre} ${empleado.apellidos}`;
    div.append(pNombre);

    let pNIF = document.createElement("p");
    pNIF.innerHTML = "NIF: " + empleado.nif;
    div.append(pNIF);

    let pEdad = document.createElement("p");
    pEdad.innerHTML = "EDAD: " + empleado.edad;
    div.append(pEdad);

    let pPuesto = document.createElement("p");
    pPuesto.innerHTML = "PUESTO: " + empleado.puesto;
    div.append(pPuesto);

    let pSalario = document.createElement("p");
    pSalario.innerHTML = `SALARIO: ${empleado.salario}`;
    div.append(pSalario);

    let pAntiguedad = document.createElement("p");
    pAntiguedad.innerHTML = `ANTIGUEDAD: ${empleado.antiguedad}`;
    div.append(pAntiguedad);

    // CREATE BUTTONS
    let editButton = document.createElement("button");
    editButton.innerText = "Edit";
    editButton.id = `bEdit${empleado.id}`;
    
    let editHandle = new EditarHandle();
    editHandle.empleado = empleado;
    editButton.addEventListener("click", editHandle); 
    
    div.append(editButton);
    

    
    let deleteButton = document.createElement("button");
    deleteButton.innerText = "Delete";
    deleteButton.id = `bDelete${empleado.id}`;

    let borrarHandle = new BorrarHandle();
    borrarHandle.empleado = empleado;
    deleteButton.addEventListener("click", borrarHandle);

    div.append(deleteButton);

    // APPEND DIV TO LI
    li.append(div);
    // APPEND LI TO OL
    ol.append(li);
    
}

// MANEJADORES DE EVENTOS
function EditarHandle() {
    this.handleEvent = function(){
        this.empleado.nombre = prompt("Cambie el nombre", this.empleado.nombre);
        this.empleado.apellidos = prompt("Cambie los apellidos", this.empleado.apellidos);
        this.empleado.nif = prompt("Cambie el NIF", this.empleado.nif);
        let nuevaEdad = prompt("Cambie la edad", this.empleado.edad);
        this.empleado.edad = isNaN(nuevaEdad)? edad : nuevaEdad;
        this.empleado.puesto = prompt("Cambie el puesto", this.empleado.puesto);
        let nuevoSalario = prompt("Cambie el salario", this.empleado.salario);
        this.empleado.salario = isNaN(nuevoSalario)? salario : nuevoSalario;
        let nuevaAntiguedad = prompt("Cambie la antiguedad", this.empleado.antiguedad);
        this.empleado.antiguedad = isNaN(nuevaAntiguedad)? antiguedad : nuevaAntiguedad;
        muestraWeb();
    }
}

function BorrarHandle() {
    this.handleEvent = function(){
        empleados.splice(this.empleado.id, 1);
        muestraWeb();
    }
}

let empleado1 = new CrearEmpleado("Carlos", "García López", "12345678A", 35, "Desarrollador", 2000, 5);
let empleado2 = new CrearEmpleado("Ana", "Martínez Fernández", "87654321B", 29, "Diseñadora", 1800, 3);
let empleado3 = new CrearEmpleado("Luis", "Pérez Gómez", "11223344C", 45, "Gerente", 3000, 10);
let empleado4 = new CrearEmpleado("María", "Sánchez Ruiz", "55667788D", 32, "Marketing", 1500, 4);
anyadirEmpleado(empleado1);
anyadirEmpleado(empleado2);
anyadirEmpleado(empleado3);
anyadirEmpleado(empleado4);

muestraWeb();