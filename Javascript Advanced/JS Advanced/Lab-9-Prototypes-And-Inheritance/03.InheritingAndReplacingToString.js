function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString(end = ')') {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email}${end}`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString(`, subject: ${this.subject})`);
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString(`, course: ${ this.course })`);
        }
    }

    let person = new Person('AAA', 'AAA@abv.bg');
    let teacher = new Teacher('Georgi', 'G@abv.bg', 'Math');
    let student = new Student('Petar', 'Pet@abv.bg', 'ABC');

    console.log(person.toString());
    console.log(teacher.toString());
    console.log(student.toString());

    return {
        Person,
        Teacher,
        Student
    }
}

toStringExtension();

