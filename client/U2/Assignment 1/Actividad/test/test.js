// Ejemplo de test utilizando el módulo assert disponible en NodeJS

// Cargar el módulo assert
var assert = require('assert');

// Cargar el módulo con las funciones para testear
var operaciones = require('../operations.js');

// Test
it('comprobar función suma', function() {
	  assert.equal(operaciones.suma(1, 3), 4);
	  assert.equal(operaciones.suma(-1, 3), 2);
	  assert.equal(operaciones.suma(8, -3), 5);
});

it('comprobar función división', function() {
	  assert.equal(operaciones.division(12, 3), 4);
	  assert.equal(operaciones.division(9, -3), -3);
	  assert.equal(operaciones.division(15, 5), 3);
});


