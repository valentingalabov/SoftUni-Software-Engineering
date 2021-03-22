function attachEvents() {
    document.getElementsByClassName('load')[0].addEventListener('click', getAllCatches);

    const loginBtnDiv = document.querySelectorAll('a')[1];

    const addBtn = document.getElementsByClassName('add')[0];




    const currenUserToken = sessionStorage.getItem('authToken');


    if (currenUserToken != null) {



        loginBtnDiv.href = 'javascript:void(0)';
        addBtn.disabled = false;
        addBtn.addEventListener('click', addCatch);



    } else {
        loginBtnDiv.href = 'login.html';
        addBtn.disabled = true;
    }


}

attachEvents();

async function addCatch(event) {
    event.preventDefault();

    const angler = document.querySelector('#addForm>.angler').value;
    const weight = document.querySelector('#addForm>.weight').value;
    const species = document.querySelector('#addForm>.species').value;
    const location = document.querySelector('#addForm>.location').value;
    const bait = document.querySelector('#addForm>.bait').value;
    const captureTime = document.querySelector('#addForm>.captureTime').value;
    const _ownerId = sessionStorage.getItem('userId');
    const token = sessionStorage.getItem('authToken');

    if (token == null) {
        return alert('You\'re not logged in!');
    }

    const catcha = {
        _ownerId,
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    };


    const result = await request('http://localhost:3030/data/catches', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body: JSON.stringify(catcha)
    });

}

async function getAllCatches() {
    const result = await request("http://localhost:3030/data/catches");
    const catchesDiv = document.getElementById('catches');
    catchesDiv.innerHTML = '';
    const val = Object.values(result).map(createCatch).join();;

}

function createCatch(result) {
    const currenUserId = sessionStorage.getItem('userId');

    let disebleBtn = true;
    if (currenUserId == result._ownerId) {
        disebleBtn = false;
    }

    const div =
        e('div', { className: 'catch' },
            e('label', {}, 'Angler'),
            e('input', { type: 'text', className: 'angler', defaultValue: result.angler },),
            e('input', { type: 'hidden', className: 'currId', defaultValue: result._id },),
            e('hr', {},),
            e('label', {}, 'Weight'),
            e('input', { type: 'number', className: 'weight', defaultValue: result.weight },),
            e('hr', {},),
            e('label', {}, 'Species'),
            e('input', { type: 'text', className: 'species', defaultValue: result.species },),
            e('hr', {},),
            e('label', {}, 'Location'),
            e('input', { type: 'text', className: 'location', defaultValue: result.location },),
            e('hr', {},),
            e('label', {}, 'Bait'),
            e('input', { type: 'text', className: 'bait', defaultValue: result.bait },),
            e('hr', {},),
            e('label', {}, 'Capture'),
            e('input', { type: 'number', className: 'captureTime', defaultValue: result.captureTime },),
            e('hr', {},),
            e('button', { disabled: disebleBtn, id: 'update', onClick: update }, 'Update'),
            e('button', { disabled: disebleBtn, id: 'delete', onClick: deleteCatch }, 'Delete')
        );

    const catchesDiv = document.getElementById('catches');

    catchesDiv.appendChild(div);



}

async function deleteCatch (event) {
    const divCatch = event.target.parentNode;
    const currId = divCatch.querySelector('.currId').value;

    const token = sessionStorage.getItem('authToken');
    
    const result = await request(`http://localhost:3030/data/catches/${currId}`, {
        method: 'delete',
        headers: {
            
            'X-Authorization': token
        },
    });

    getAllCatches();
}

async function update(event) {
    const currELement = event.target;
    const divCatchDiv = currELement.parentNode;

    const angler = divCatchDiv.querySelector('.angler').value;
    const weight = divCatchDiv.querySelector('.weight').value;
    const species = divCatchDiv.querySelector('.species').value;
    const location = divCatchDiv.querySelector('.location').value;
    const bait = divCatchDiv.querySelector('.bait').value;
    const captureTime = divCatchDiv.querySelector('.captureTime').value;

    const currId = divCatchDiv.querySelector('.currId').value;

    const token = sessionStorage.getItem('authToken');

    const body = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    }

    const result = await request(`http://localhost:3030/data/catches/${currId}`, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body: JSON.stringify(body)
    });

    getAllCatches();

}


async function request(url, options) {
    const response = await fetch(url, options);

    if (response.ok != true) {
        const error = await response.json();
        console.log(error.message);
        throw new Error(error.message);
    }

    const data = await response.json();

    return data;
}


function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}
