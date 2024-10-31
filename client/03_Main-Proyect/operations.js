function suma(a, b) {
    return a + b;
};

function resta(a, b) {
    return a - b;
};

function multiplicacion(a, b) {
    return a * b
}

function division(a, b) {
    return a / b
}

function power(a, b) {
    let total = a;
    for (let i = 1; i < b; i++ ){
        total = total * a;
    };
    return total;
}

function cuadratica(a,b,c) {
    // Declare x1 and x2
    let x1;
    let x2;

    // Calculate x1 and x2
    x1 = (-b + (Math.sqrt(b*b - (4*a*c)))) / 2*a;
    x2 = (-b - (Math.sqrt(b*b - (4*a*c)))) / 2*a; 
    
    // Return as an array.
    return [x1,  x2];
}

/* Exportación de funciones */
module.exports = {
    suma,
    resta,
    multiplicacion,
    division,
    power,
    cuadratica
}
