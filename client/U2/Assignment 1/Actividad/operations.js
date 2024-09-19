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

/* Exportación de funciones */
module.exports = {
    suma,
    resta,
    multiplicacion,
    division,
    power
}
