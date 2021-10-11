const { expect } = require('chai');
const { mathEnforcer } = require('./04.MathEnforcer');

describe('Test 04.MathEnforcer functionality', () => {
    //const instane = mathEnforcer;

    it('Add should work as expected', () => {
        expect(mathEnforcer.addFive(5)).to.equal(10);
        expect(mathEnforcer.addFive(0)).to.equal(5);
        expect(mathEnforcer.addFive(-10)).to.equal(-5);
        expect(mathEnforcer.addFive(5.05)).to.be.closeTo(10.05, 0.01);
        expect(mathEnforcer.addFive(-10.05)).to.be.closeTo(-5.05, 0.01);
    })

    it('Add function returns undefined if wrong type is provided', () => {
        expect(mathEnforcer.addFive('1')).to.be.undefined;
        expect(mathEnforcer.addFive([1, 2])).to.be.undefined;
        expect(mathEnforcer.addFive(['1'])).to.be.undefined;
        expect(mathEnforcer.addFive({})).to.be.undefined;
    })

    it('Subtract should work as expected', () => {
        expect(mathEnforcer.subtractTen(0)).to.equal(-10);
        expect(mathEnforcer.subtractTen(10)).to.equal(0);
        expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        expect(mathEnforcer.subtractTen(-10.05)).to.be.closeTo(-20.05, 0.01);
        expect(mathEnforcer.subtractTen(20.05)).to.be.closeTo(10.05, 0.01);
    })

    it('Subtract function returns undefined if wrong type is provided', () => {
        expect(mathEnforcer.subtractTen('1')).to.be.undefined;
        expect(mathEnforcer.subtractTen([1, 2])).to.be.undefined;
        expect(mathEnforcer.subtractTen(['1'])).to.be.undefined;
        expect(mathEnforcer.subtractTen({})).to.be.undefined;
    })

    it('Sum should work as expected', () => {
        expect(mathEnforcer.sum(0, 0)).to.equal(0);
        expect(mathEnforcer.sum(0, 10)).to.equal(10);
        expect(mathEnforcer.sum(5, 5)).to.equal(10);
        expect(mathEnforcer.sum(-20, 5)).to.equal(-15);
        expect(mathEnforcer.sum(5.05, 5.05)).to.be.closeTo(10.10, 0.01);
        expect(mathEnforcer.sum(5.05, 5)).to.be.closeTo(10.05, 0.01);
        expect(mathEnforcer.sum(-10.05, 5)).to.be.closeTo(-5.05, 0.01);
    })

    it('Sum function returns undefined if wrong type is provided', () => {
        expect(mathEnforcer.sum('1', 1)).to.be.undefined;
        expect(mathEnforcer.sum([1, 2], 1)).to.be.undefined;
        expect(mathEnforcer.sum(['1'], 1)).to.be.undefined;
        expect(mathEnforcer.sum({}, 1)).to.be.undefined;
        expect(mathEnforcer.sum(1, '1')).to.be.undefined;
        expect(mathEnforcer.sum(1, [1, 2])).to.be.undefined;
    })
})