const { expect } = require('chai');
const { createCalculator } = require('./07.Add-Subtract');

describe('07.Add-Subtract functionality tests', () => {
    let calculator = {};

    beforeEach(() => {
        calculator = createCalculator();
    })

    it('Instance starts empty', () => {
        expect(calculator.get()).to.be.equal(0);
    })

    it('Has all methods', () => {
        expect(calculator).to.haveOwnProperty('add');
        expect(calculator).to.haveOwnProperty('subtract');
        expect(calculator).to.haveOwnProperty('get');
    })

    it('Add works with single number', () => {
        calculator.add(1);
        expect(calculator.get()).to.be.equal(1);
    })

    it('Add works with multiple numbers', () => {
        calculator.add(1);
        calculator.add(1);
        expect(calculator.get()).to.be.equal(2);
    })

    it('Add works with single string number', () => {
        calculator.add('1');
        expect(calculator.get()).to.be.equal(1);
    })

    it('Add works with multiple string numbers', () => {
        calculator.add(Number('1'));
        calculator.add(Number('1'));
        expect(calculator.get()).to.be.equal(2);
    })

    it('Subtract works with single number', () => {
        calculator.subtract(1);
        expect(calculator.get()).to.be.equal(-1);
    })

    it('Subtract works with single string number', () => {
        calculator.subtract('1');
        expect(calculator.get()).to.be.equal(-1);
    })

    it('Subtract works with multiple numbers', () => {
        calculator.subtract(1);
        calculator.subtract(1);
        expect(calculator.get()).to.be.equal(-2);
    })

    it('Subtract works with multiple string numbers', () => {
        calculator.subtract(Number('1'));
        calculator.subtract(Number('1'));
        expect(calculator.get()).to.be.equal(-2);
    })
})