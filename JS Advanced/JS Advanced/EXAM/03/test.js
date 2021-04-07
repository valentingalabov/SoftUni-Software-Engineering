const stringOperations = require('./03. String Operations_Ресурси.js');
const expect = require('chai').expect;



describe("stringOperations …", function () {
    describe("stringSlicer …", function () {
        it("string slicer with words more than 3 symbols", function () {

            expect(stringOperations.stringSlicer('testString')).to.equal('tes...');
        });
        it("string slicer with word less than 3 symbols", function () {
            expect(stringOperations.stringSlicer('ab')).to.equal('ab...');
        });
    });

    describe("wordChecker …", function () {
        it("wordChecker return word if exist in text …", function () {
            expect(stringOperations.wordChecker('test', 'wordChecker return word test if exist in text')).to.equal('test');
        });

        it("wordChecker return word if exist in text if its upperCase …", function () {
            expect(stringOperations.wordChecker('tEsT', 'wordChecker return word Test if exist in text')).to.equal('test');
        });

        it("wordChecker return correct answer if word is not included …", function () {
            expect(stringOperations.wordChecker('test', 'wordChecker return word if exist in text')).to.equal(`test not found!`);
        });
    });

    describe("printEveryNthElement …", function () {
        it("check if first param is invalid throw error …", function () {
            expect(() => stringOperations.printEveryNthElement('asd', [1, 2, 3, 4, 5, 6])).to.throw(Error, 'The input is not valid!')
        });

        it("check if second param is invalid throw error …", function () {
            expect(() => stringOperations.printEveryNthElement(2, 'asdasd')).to.throw(Error, 'The input is not valid!')
        });

        it("check if parameters are valid return correct result …", function () {

            expect(stringOperations.printEveryNthElement(2, [1, 2, 3, 4, 5, 6])).to.deep.equal([1, 3, 5]);
        });

    });
});
