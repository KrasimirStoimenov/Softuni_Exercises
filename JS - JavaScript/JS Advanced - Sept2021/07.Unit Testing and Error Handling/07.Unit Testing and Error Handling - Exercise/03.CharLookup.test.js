const { expect } = require('chai');
const { lookupChar } = require('./03.CharLookup');

describe('Test 03.CharLookup functionality', () => {
    it('Returns undefined if pass types different of expected ones', () => {
        expect(lookupChar(1, 1)).to.be.undefined;
        expect(lookupChar('1', '1')).to.be.undefined;
        expect(lookupChar([], 1)).to.be.undefined;
        expect(lookupChar(1, {})).to.be.undefined;
        expect(lookupChar(1)).to.be.undefined;
        expect(lookupChar('1', 1.1)).to.be.undefined;
        expect(lookupChar()).to.be.undefined;
    })

    it('Returns "Incorrect index" if we pass index outside of bounds of the string length', () => {
        expect(lookupChar('abc', -1)).to.equal('Incorrect index');
        expect(lookupChar('abc', 3)).to.equal('Incorrect index');
    })

    it('Should works as expected', () => {
        expect(lookupChar('abc', 2)).to.equal('c');
        expect(lookupChar('abc', 0)).to.equal('a');
        expect(lookupChar('abc', 1)).to.equal('b');
    })
})