let baseUrl = 'http://localhost:3030/jsonstore/collections/students';

async function extractStudents() {
    let response = await fetch(baseUrl);
    let students = await response.json();
    console.log(students);

    let tableBody = document.querySelector('#results tbody');

    Object.keys(students).forEach(el => {
        let student = students[el];
        let studentTableRow = fillTableRow(student);
        tableBody.appendChild(studentTableRow);
    })
}
extractStudents()


let createStudentForm = document.getElementById('form');
createStudentForm.addEventListener('submit', createStudent);

async function createStudent(e) {
    let formData = new FormData(e.currentTarget);
    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = formData.get('grade');

    if (firstName == '' || lastName == '' || facultyNumber == '' || grade == '') {
        return alert('all fields are required!')
    }

    try {
        let response = await fetch(baseUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                firstName: firstName,
                lastName: lastName,
                facultyNumber: facultyNumber,
                grade: grade
            })
        });

        let tableRow = await response.json();
        console.log(tableRow);

    } catch (error) {
        return alert(error)
    }
}

function fillTableRow(student) {
    let trElement = document.createElement('tr');

    let firstNameTd = document.createElement('td');
    firstNameTd.textContent = student.firstName;

    let lastNameTd = document.createElement('td');
    lastNameTd.textContent = student.lastName;

    let facNumTd = document.createElement('td');
    facNumTd.textContent = student.facultyNumber;

    let gradeTd = document.createElement('td');
    gradeTd.textContent = student.grade;

    trElement.appendChild(firstNameTd);
    trElement.appendChild(lastNameTd);
    trElement.appendChild(facNumTd);
    trElement.appendChild(gradeTd);

    return trElement;
}