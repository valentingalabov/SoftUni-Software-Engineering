const { expect } = require('chai');
const rgbToHexColor = require('./RGBToHex');

describe('rgbToHexColor', () => {
    it('convert black to hex', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });

    it('convert white to hex', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF');
    });

    it('convert red to hex', () => {
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
    });

    it('convert green to hex', () => {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
    });

    it('convert blue to hex', () => {
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
    });

    it('convert (77,77,122) to hex', () => {
        expect(rgbToHexColor(77, 77, 122)).to.equal('#4D4D7A');
    });

    it('convert (195,170,47) to hex', () => {
        expect(rgbToHexColor(195, 170, 47)).to.equal('#C3AA2F');
    });


    it('returns undefined for numbers out of rgb range', () => {
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
    });

    it('returns undefined for negative values for red', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
    });

    it('returns undefined for negative values for green', () => {
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
    });
    it('returns undefined for negative values for blue ', () => {
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
    });

    it('returns undefined for string params', () => {
        expect(rgbToHexColor('a', 'a', 'a')).to.be.undefined;
    });


});