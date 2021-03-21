function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', getAllContacts);

    document.getElementById('btnCreate').addEventListener('click', createContact);
}

attachEvents();

async function getAllContacts() {
    const records = await request('http://localhost:3030/jsonstore/phonebook');
    const getUl = document.getElementById('phonebook');
    getUl.innerHTML = '';

    Object.entries(records).map(appendLiElements).join('');

}


function appendLiElements([key, value]) {
    const getUl = document.getElementById('phonebook');
    const li = document.createElement('li');
    li.textContent = `${value.person}:${value.phone}`;
    let btn = document.createElement('button');
    btn.textContent = 'Delete';
    btn.id = key;
    btn.addEventListener('click', deleteContact);

    li.appendChild(btn);

    getUl.appendChild(li);
}


async function deleteContact(event) {

    const result = await request(`http://localhost:3030/jsonstore/phonebook/${event.target.id}`, {
        method: 'delete'
    });
    getAllContacts();
    return result;
}


async function createContact() {
    const person = document.getElementById('person');
    const phone = document.getElementById('phone');

    if (person.value === "" || phone.value === "") {
        return alert("All fields are required!");
    }

    const contact = {
        person: person.value,
        phone: phone.value
    };

    await request('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: { 'Content-Type': 'aplication/json' },
        body: JSON.stringify(contact)
    });
    getAllContacts();
    person.value = '';
    phone.value = ''

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
