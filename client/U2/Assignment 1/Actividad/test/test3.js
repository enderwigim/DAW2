// Cargar el módulo assert
var assert = require('assert');

// Cargar el módulo con las funciones para testear
var operaciones = require('../operations.js');

it('comprobar función power (potencia)', function() {
    assert.equal(operaciones.power(2,3), 8);
    assert.equal(operaciones.power(8,2), 64);
});