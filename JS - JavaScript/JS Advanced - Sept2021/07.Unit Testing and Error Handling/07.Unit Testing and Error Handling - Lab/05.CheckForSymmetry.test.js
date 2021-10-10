const { expect } = require('chai');
const { isSymmetric } = require('./05.CheckForSymmetry');

describe('05.CheckForSymmetry functionality tests', () => {
    it('Returns false if we provide something different from Array type', () => {
        expect(isSymmetric(1)).to.be.false;
        expect(isSymmetric('1')).to.be.false;
        expect(isSymmetric(1, 1)).to.be.false;
        expect(isSymmetric(undefined)).to.be.false;
        expect(isSymmetric()).to.be.false;
    })

    it('Returns true if array is symmetric', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
        expect(isSymmetric([2, 2, 2, 2])).to.be.true;
        expect(isSymmetric([1, 2, 3, 2, 1])).to.be.true;
    })

    it('Returns false if array is not symmetric', () => {
        expect(isSymmetric([1, 2, 3, 3, 1])).to.be.false;
        expect(isSymmetric([1, 2, 3, 1])).to.be.false;
    })

    it('Returns false if type-different array', () => {
        expect(isSymmetric([1, 2, '1'])).to.be.false;
    })
})