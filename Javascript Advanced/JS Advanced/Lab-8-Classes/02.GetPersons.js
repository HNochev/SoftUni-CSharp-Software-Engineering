const Person = require('./01.Person');

function getPersons() {
    let persons = [];

    persons.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
    persons.push(new Person('SoftUni'));
    persons.push(new Person('Stephan', 'Johnson', 25));
    persons.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));

    return persons;
}

console.log(getPersons());

// Done as continue to first task 01.Persons