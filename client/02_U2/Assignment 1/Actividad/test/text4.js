
var should = require('should');

var operaciones = require('../operations.js');

it('comprobar función cuadratica', function() {
    operaciones.cuadratica.should.be.a.Function();
    operaciones.cuadratica(1, 2, -3).should.eql([1, -3]);
    operaciones.cuadratica(3, 4, -4).should.eql([6, -18]);
    operaciones.cuadratica(1, 2, 1).should.eql([-1, -1]);
  });