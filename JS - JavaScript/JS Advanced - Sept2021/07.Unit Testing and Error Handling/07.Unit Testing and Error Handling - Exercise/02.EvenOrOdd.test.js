const { expect } = require('chai');
const { isOddOrEven } = require('./02.EvenOrOdd');

describe('Test 02.EvenOrOdd functionality', () => {
    it('Returns even if we pass string with even length', () => {
        expect(isOddOrEven('abcd')).to.equal('even');
        expect(isOddOrEven('ab')).to.equal('even');
        expect(isOddOrEven('')).to.equal('even');
    })

    it('Returns odd if we pass string with odd length', () => {
        expect(isOddOrEven('abc')).to.equal('odd');
        expect(isOddOrEven('a')).to.equal('odd');
        expect(isOddOrEven('abcdf')).to.equal('odd');
    })

    it('Returns undefined if pass type different from string', () => {
        expect(isOddOrEven([1, 2, 3])).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven(1)).to.be.undefined;
    })
})