const library = require('./library');
const { expect } = require('chai');

describe("Tests library functionality", function () {
    describe("Test calcPriceOfBook functionality", function () {
        it("Should work as expected", function () {
            expect(library.calcPriceOfBook('test', 2020)).to.be.equal("Price of test is 20.00");
            expect(library.calcPriceOfBook('abc', 1981)).to.be.equal("Price of abc is 20.00");
        });
        it("Should work with year less than 1980", function () {
            expect(library.calcPriceOfBook('test', 1980)).to.be.equal("Price of test is 10.00");
            expect(library.calcPriceOfBook('test', 1900)).to.be.equal("Price of test is 10.00");
        });
        it("Should throw error if invalid input is passed", function () {
            expect(()=>library.calcPriceOfBook('test', '2000')).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook(2000)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook(2000,2000)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook('test')).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook([], 2020)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook('test', [])).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook({}, [])).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook([], {})).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook()).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook('test', {})).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook({}, 2020)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook({}, {})).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook('test', 10.10)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook(2020, 10.10)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook(10.10, 10.10)).to.throw("Invalid input");
            expect(()=>library.calcPriceOfBook(2020, 10.10)).to.throw(Error);
        });
    });
    describe("Test findBook functionality", function () {
        it("Should work as expected", function () {
            expect(library.findBook(['a', 'b', 'c'], 'a')).to.be.equal("We found the book you want.");
            expect(library.findBook(['a'], 'a')).to.be.equal("We found the book you want.");
        });
        it("Should return properly message if book is not presented in array", function () {
            expect(library.findBook(['a', 'b', 'c'], 'd')).to.be.equal("The book you are looking for is not here!");
            expect(library.findBook(['a'], 'x')).to.be.equal("The book you are looking for is not here!");
            expect(library.findBook([1], 'x')).to.be.equal("The book you are looking for is not here!");
        });
        it("Should throw error if there's no books in array", function () {
            expect(() => library.findBook([], 'a')).to.throw("No books currently available");
            expect(() => library.findBook([])).to.throw("No books currently available");
        });
    });
    describe("Test arrangeBook functionality", function () {
        it("Should works as expected", function () {
            expect(library.arrangeTheBooks(1)).to.be.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(20)).to.be.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(40)).to.be.equal("Great job, the books are arranged.");
            expect(library.arrangeTheBooks(0)).to.be.equal("Great job, the books are arranged.");
        });
        it("Should return properly message if more books are provided than the available space", function () {
            expect(library.arrangeTheBooks(41)).to.be.equal("Insufficient space, more shelves need to be purchased.");
            expect(library.arrangeTheBooks(50)).to.be.equal("Insufficient space, more shelves need to be purchased.");
        });
        it("Should throw error if provided input is not valid", function () {
            expect(()=>library.arrangeTheBooks(-1)).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks({})).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks([-1])).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks(['a'])).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks([])).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks('test')).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks(1.1)).to.throw("Invalid input");
            expect(()=>library.arrangeTheBooks(1.1)).to.throw(Error);
        })
    });
});
