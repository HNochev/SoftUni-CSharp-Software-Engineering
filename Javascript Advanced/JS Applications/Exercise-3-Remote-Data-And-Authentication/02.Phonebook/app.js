document.querySelector('#btnLoad').addEventListener('click', loadAllContacts);
document.querySelector('#btnCreate').addEventListener('click', addContact);

async function loadAllContacts() {
    const response = await fetch('http://localhost:3030/jsonstore/phonebook');
    const contacts = await response.json();
    console.log(contacts);
    const phoneBookUl = document.querySelector('#phonebook');
    phoneBookUl.querySelectorAll('li').forEach(li => li.remove());
    Object.values(contacts).map(createContactLi).forEach(li => phoneBookUl.appendChild(li));
}

function createContactLi(contact) {
    const li = document.createElement('li');
    li.textContent = `${contact.person}: ${contact.phone}`;
    li.dataset.id = contact._id;

    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', deleteContact);

    li.appendChild(deleteBtn);

    return li;
}

async function deleteContact(e) {
    const li = e.target.closest('li')
    const id = e.target.closest('li').dataset.id;

    const response = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: 'DELETE'
    });

    if (response.ok) {
        li.remove();
    }
}

async function addContact() {
    const person = document.querySelector('#person');
    const phone = document.querySelector('#phone');

    let response = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ person: person.value, phone: phone.value })
    });

    const contact = await response.json();
    const li = createContactLi(contact);
    document.querySelector('#phonebook').appendChild(li);

    person.value = '';
    phone.value = '';
}