function solve() {
    document.getElementById('form').addEventListener('submit', addStudent);
}
getAllStudents();
solve();

async function addStudent(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = formData.get('facultyNumber');
    const grade = Number(formData.get('grade'));

    const faciltyRegex = new RegExp('^\\d+$', 'g');

    // console.log(facultyNumber);

    // console.log(faciltyRegex.test(facultyNumber));

    if (firstName == "" ||
        lastName == "" ||
        !faciltyRegex.test(facultyNumber) ||
        !grade ||
        grade < 2 ||
        grade > 6 ||
        grade == "") {
        return alert('All fields are required!');
   
    }
    const student = {
        firstName,
        lastName,
        facultyNumber,
        grade
    };

    const result = await request('http://localhost:3030/jsonstore/collections/students', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(student)
    });
    event.target.reset();
    getAllStudents();
    return result;
}

async function getAllStudents() {

    const table = document.querySelector('tbody');
    table.innerHTML = '';
    const data = await request('http://localhost:3030/jsonstore/collections/students');

    Object.entries(data).map(createRow).join('');
}

function createRow([id, student]) {
    const table = document.querySelector('tbody');


    const row = document.createElement('tr');

    const firstName = document.createElement('th');
    firstName.textContent = student.firstName;

    const lastName = document.createElement('th')
    lastName.textContent = student.lastName;

    const facultyNumber = document.createElement('th')
    facultyNumber.textContent = student.facultyNumber;

    const grade = document.createElement('th')
    grade.textContent = Number(student.grade).toFixed(2);

    row.appendChild(firstName);
    row.appendChild(lastName);
    row.appendChild(facultyNumber);
    row.appendChild(grade);

    table.appendChild(row);

}

async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok != true) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = await response.json();

    return data;
}
