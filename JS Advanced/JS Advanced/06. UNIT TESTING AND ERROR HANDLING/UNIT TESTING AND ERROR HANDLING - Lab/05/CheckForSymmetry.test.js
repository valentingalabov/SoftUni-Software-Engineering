const { expect } = require('chai');
const isSymmetric = require('./CheckForSymmetry');

describe('isSymmetric', () => {
    it('return true for valid symetric input', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('return false for invalid symetric input', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('return false for invalid argument', () => {
        expect(isSymmetric('a')).to.be.false;
    });

    it('return true for valid symetric odd-element array', () => {
        expect(isSymmetric([1, 1, 1])).to.be.true;
    });

    it('return true for valid symetric string array', () => {
        expect(isSymmetric(['a', 'a'])).to.be.true;
    });

    it('return true  for valid symetric string array', () => {
        expect(isSymmetric([1, 1, 1])).to.be.true;
    });

    it('return false  for valid non-symetric string array', () => {
        expect(isSymmetric(['a', 'b'])).to.be.false;
    });

    it('return false  for type-coerced element ', () => {
        expect(isSymmetric(['1', 1])).to.be.false;
    });

});