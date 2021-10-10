const { expect } = require('chai');
const { sum } = require('./04.SumOfNumbers');

describe('04.SumOfNumbers functionality tests', () => {
    it('Sum correctly', () => {
        expect(sum([5, 5])).to.be.equal(10);
        expect(sum([3, 3])).to.be.equal(6);
    })
})