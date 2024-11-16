
// Create global variable
let ordenadores = [];

function anyadirOrdernador(ordenador){
    ordenadores.push(ordenador);
}

function getFechasAlta(){
    let fechasAlta = {};
    ordenadores.forEach(
        ordenador => {
            let fecha = new Date(ordenador.fecha).toLocaleDateString()
            if(fechasAlta[fecha] === undefined){
                fechasAlta[fecha] = 1
            }
            else {
                fechasAlta[fecha] += 1;
            }
        }
    )
    return fechasAlta;
}


function Ordenador(marca, modelo, ram, disco, pulgadas, fecha, ...accesorios) {
    this.marca = (typeof marca === "string")? marca : NaN;
    this.modelo = (typeof modelo === "string")? modelo : NaN;
    this.ram = isNaN(ram)? 16 : ram;
    this.disco = isNaN(disco)? 256 : disco;
    this.pulgadas = isNaN(pulgadas)? 15.6 : pulgadas;
    this.fecha = isNaN(Date.parse(fecha))? new Date() : new Date(fecha);
    this.accesorios = (accesorios.length > 0) ? [...accesorios] : [];

    this.mostrarOrdenador = function () {
        let accesorios_text = "ACCESORIOS: \n"; 
        this.accesorios.forEach(accesorio => {
            accesorios_text += `- ${accesorio}\n`;
        });
        
        console.log(`ORDENADOR: ${this.marca} ${this.modelo}
            RAM: ${this.ram}GB
            DISCO: ${this.disco}GB
            PULGADAS: ${this.pulgadas}"
             ALTA: ${new Date(this.fecha).toLocaleDateString()}
            ${accesorios_text}`);
        };
    this.actualizarMarcaModelo = function(newMarca, newModelo){
        this.marca = (typeof newMarca === "string")? newMarca : this.marca;
        this.modelo = (typeof newModelo === "string")? newModelo : this.modelo; 
    };

    this.actualizarRamDiscoPulgadas = function(newRam, newDisco, newPulgadas){
        this.ram = (!isNaN(newRam))? newRam : this.ram;
        this.newDisco = (!isNaN(newDisco))? newDisco : this.disco;
        this.newPulgadas = (!isNaN(newPulgadas))? newPulgadas : this.pulgadas;
    }
    this.actualizarFecha = function(fecha){
        this.fecha = (isNaN(Date.parse(fecha)))? this.fecha : Date.parse(fecha);
    }
    this.anyadirAccesorios = function(...acc) {
        acc.forEach( accesorio => {
            (!this.accesorios.includes(accesorio))? this.accesorios.push(accesorio) : null; 
        })
    }
    this.borrarAccesorios = function(...acc) {
        acc.forEach( accesorio => {
            (this.accesorios.indexOf(accesorio) >= 0)? this.accesorios.splice(this.accesorios.indexOf(accesorio), 1) : null;
        })
    }

};

anyadirOrdernador(new Ordenador('lenovo', 'legion', 32, 256, 15.6, '2022-11-09', 'ratón', 'teclado'))
anyadirOrdernador(new Ordenador('hp', 'omen', 32, 256, 15.6, '2022-11-09', 'ratón', 'teclado'));
anyadirOrdernador(new Ordenador('acer', 'ferrari', 32, 256, 15.6, '2022-09-09', 'ratón', 'teclado'));
anyadirOrdernador(new Ordenador('msi', 'modern', 32, 256, 15.6, '2022-08-09', 'ratón', 'teclado'));

ordenadores.forEach(
    ordenador => {
        ordenador.mostrarOrdenador();
    }
)

console.log(getFechasAlta());

