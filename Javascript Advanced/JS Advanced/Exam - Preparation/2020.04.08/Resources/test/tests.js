const { assert } = require("chai");
let { Repository } = require("../solution");

describe("Tests Repository functionality", function () {
    describe("Ctor and get", function () {
        it('Should return 0 when repo is empty and there is no entity', () => {
            const props = {
                name: 'string',
                age: 'number',
                bDay: 'object',
            }

            let repo = new Repository(props);

            assert.equal(repo.count, 0);
            assert.equal(repo.nextId(), 0);
        });

        it('Props should be as given', () => {
            const props = {
                name: 'string',
                age: 'number',
                bDay: 'object',
            }

            let repo = new Repository(props);

            assert.deepEqual(repo.props, { name: 'string', age: 'number', bDay: 'object', });
        });
    });

    describe('add', function () {

        it('Should throw error when incorrect prop name is given', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });

            let entity = { na: 'Alo', age: 82, bDay: {} };
            let entity1 = { name: 'Alo', ae: 82, bDay: {} };
            let entity2 = { name: 'Alo', age: 82, bay: {} };
            assert.throws(() => repo.add(entity), 'Property name is missing from the entity!');
            assert.throws(() => repo.add(entity1), 'Property age is missing from the entity!');
            assert.throws(() => repo.add(entity2), 'Property bDay is missing from the entity!');
        });

        it('Should throw error when incorrect prop type is given', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });

            let entity = { name: {}, age: 82, bDay: {} };
            let entity1 = { name: 'Alo', age: '', bDay: {} };
            let entity2 = { name: 'Alo', age: 82, bDay: 56 };
            assert.throws(() => repo.add(entity), 'Property name is not of correct type!');
            assert.throws(() => repo.add(entity1), 'Property age is not of correct type!');
            assert.throws(() => repo.add(entity2), 'Property bDay is not of correct type!');
        });

        it('Add Should return correct id', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            
            let entity = { name: 'Alo', age: 82, bDay: {} };
            assert.equal(repo.add(entity), 0);
            let entity1 = { name: 'Alo', age: 23, bDay: {} };
            assert.equal(repo.add(entity1), 1);
            let entity2 = { name: 'Alo', age: 82, bDay: {} };
            assert.equal(repo.add(entity2), 2);

            assert.deepEqual(repo.data.get(1), entity1);
        });
    });

    describe('getId', () => {

        it('If wrong id is given throws error', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);
            repo.add(entity);

            assert.throws(() => repo.getId(-1), 'Entity with id: -1 does not exist!');
            assert.throws(() => repo.getId(3), 'Entity with id: 3 does not exist!');
        });
    });

    describe('update', () => {
       
        it('If id incorrect in Update throws error', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);

            assert.throws(() => repo.update(-1, entity), 'Entity with id: -1 does not exist!');
            assert.throws(() => repo.update(2, entity), 'Entity with id: 2 does not exist!');
        });

        it('Update validates new entity and if valid , updates', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);

            let entity1 = { name: 'Kamen', age: 30, bDay: new Date(1990, 7, 18) };
            repo.update(0, entity1);
            assert.deepEqual(repo.getId(0), entity1);
        });

        it('Update validates new entity and if invalid throws errors', () => {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);

            let entity1 = { ala: 'Kamen', age: 30, bDay: new Date(1990, 7, 18) };
            let entity2 = { name: 'Kamen', age: 30, bb: new Date(1990, 7, 18) };
            let entity3 = { name: 15, age: 30, bDay: new Date(1990, 7, 18) };
            let entity4 = { name: 'Kamen', age: 30, bDay: true };
            assert.throws(() => repo.update(0, entity1), 'Property name is missing from the entity!');
            assert.throws(() => repo.update(0, entity2), 'Property bDay is missing from the entity!');
            assert.throws(() => repo.update(0, entity3), 'Property name is not of correct type!');
            assert.throws(() => repo.update(0, entity4), 'Property bDay is not of correct type!');
        });
    });

    describe('delete', function () {
    
        it('if id incorrect throw error', function () {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);

            assert.throws(() => repo.del(-1), 'Entity with id: -1 does not exist!');
            assert.throws(() => repo.del(2), 'Entity with id: 2 does not exist!');
        });

        it('if id correct deletes', function () {
            let repo = new Repository({ name: 'string', age: 'number', bDay: 'object' });
            let entity = { name: 'Alo', age: 82, bDay: {} };
            repo.add(entity);
            repo.add(entity);

            assert.equal(repo.count, 2);
            repo.del(0);
            assert.equal(repo.count, 1);
        });
    });
});