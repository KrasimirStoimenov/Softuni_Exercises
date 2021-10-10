const { expect } = require('chai');
const { rgbToHexColor } = require('./06.RGBToHex');

describe('06.RGBtoHex functionality tests', () => {
    it('Returns undefined if one of color is NOT integer', () => {
        expect(rgbToHexColor('123', 123, 123)).to.be.undefined;
        expect(rgbToHexColor(123, '123', 123)).to.be.undefined;
        expect(rgbToHexColor(123, 123, ' 123')).to.be.undefined;
        expect(rgbToHexColor(123, '123', '123')).to.be.undefined;
        expect(rgbToHexColor('123', '123', '123')).to.be.undefined;
        expect(rgbToHexColor()).to.be.undefined;
        expect(rgbToHexColor(123, 123)).to.be.undefined;
        expect(rgbToHexColor(123)).to.be.undefined;
    })

    it('Returns undefined if color range is out of range (0/255)', () => {
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(-1, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
        expect(rgbToHexColor(256, -1, -1)).to.be.undefined;
    })

    it('Should work as expected', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
        expect(rgbToHexColor(245, 66, 66)).to.equal('#F54242');
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    })
})