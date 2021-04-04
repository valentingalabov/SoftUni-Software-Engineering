let { Repository } = require("./solution.js");
const expect = require('chai').expect;


describe("Tests …", function () {
    let properties;
    let repository;
    let entity;
    beforeEach('optional description', function () {
        properties = {
            name: "string",
            age: "number",
            birthday: "object"
        };
        //Initialize the repository
        repository = new Repository(properties);

        entity = {
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        };
    });

    it("props set corect", function () {

        expect(repository.props).to.deep.equal(properties);

    });

    it("count work corect when element is not added", function () {

        expect(repository.count).to.equal(0);

    });

    it("count work corect with 2 enitities", function () {

        repository.add(entity); // Returns 0
        repository.add(entity); // Returns 1

        expect(repository.count).to.equal(2);

    });

    it("add return corect result", function () {

        expect(repository.add(entity)).to.equal(0);
        expect(repository.add(entity)).to.equal(1);
    });

    it("Map prop work correct", function () {
        repository.add(entity);

        expect(repository.data.get(0)).to.deep.equal({
            name: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        });
        
    });

    it("add throw Error if property name is invalid", function () {

        expect(() => repository.add({
            invalidName: "Pesho",
            age: 22,
            birthday: new Date(1998, 0, 7)
        })).to.throw(Error,`Property name is missing from the entity!` );
        
    });
    it("add throw Error if property name is invalid value", function () {

        expect(() => repository.add({
            name: 2332,
            age: 22,
            birthday: new Date(1998, 0, 7)
        })).to.throw(Error,`Property name is not of correct type!`);
        
    });

    it("getById work correct", function () {

        repository.add(entity);

        expect(repository.getId(0)).to.deep.equal(entity);
    });
    it("getById throw Error when id doesn't exist", function () {

        repository.add(entity);

        expect(() => repository.getId(2)).to.throw(Error, 'Entity with id: 2 does not exist!');
    });

it("update change prop correct", function () {

        repository.add(entity);
        repository.update(0, {
            name: "Sasho",
            age: 23,
            birthday: new Date(1998, 0, 7)
        });
        expect(repository.getId(0)).to.deep.equal({
            name: "Sasho",
            age: 23,
            birthday: new Date(1998, 0, 7)
        });
    });

    it("update throw error when entity does not exist", function () {

        repository.add(entity);

        expect(() => repository.update(2, {
            name: "asd",
            age: 23,
            birthday: new Date(1998, 0, 7)
        })).to.throw(Error, 'Entity with id: 2 does not exist!');
    });

    
    it("update throw error with invalid property Name", function () {

        repository.add(entity);

        expect(() => repository.update(0, {
            invalid: "asrrr",
            age: 22,
            birthday: new Date(1998, 0, 7)
        })).to.throw(Error, `Property name is missing from the entity!`);

    });

    it("update throw error with invalid property value", function () {

        repository.add(entity);

        expect(() => repository.update(0, {
            name: 1544,
            age: 22,
            birthday: new Date(1998, 0, 7)
        })).to.throw(Error, `Property name is not of correct type!`);

    });

    it("del throw error if entity does not exist", function () {

        expect(() => repository.del(4)).to.throw(Error, 'Entity with id: 4 does not exist!');
    });

    it("del delete element correct", function () {
        repository.add(entity);
        repository.add(entity);
        repository.del(1)
        expect(repository.count).to.equal(1);

    });

});
