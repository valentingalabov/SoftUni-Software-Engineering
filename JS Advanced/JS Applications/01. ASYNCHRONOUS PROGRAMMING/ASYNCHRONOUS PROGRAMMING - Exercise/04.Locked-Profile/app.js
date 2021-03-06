async function lockedProfile() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(url);
    const data = await response.json();


    const users = Object.values(data);
    const main = document.getElementById('main');

    main.innerHTML = '';
    users.forEach(u => {
        const username = u['username'];
        const email = u['email'];
        const age = u['age'];

        const currCard = e('div', { className: 'profile' },
            e('img', { src: './iconProfile2.png', className: 'userIcon' },),
            e('label', {}, 'Lock'),
            e('input', { type: 'radio', name: `${username}Locked`, value: 'lock', checked: 'true' },),
            e('lable', {}, 'Unlock'),
            e('input', { type: 'radio', name: `${username}Locked`, value: 'unlock' }), e('br', {},),
            e('hr', {},),
            e('label', {}, 'Username'),
            e('input', { type: 'text', name: `${username}Username`, value: username, disabled: 'true', readOnly: 'true' },),
            e('div', { id: `${username}HiddenFields`, },
                e('hr', {},),
                e('label', {}, 'Email:'),
                e('input', { type: 'email', name: `${username}${email}`, value: email, disabled: 'true', readOnly: 'true' },),
                e('label', {}, 'Age:'),
                e('input', { type: 'email', name: `${username}${age}`, value: age, disabled: 'true', readOnly: 'true' },)
            ),
            e('button', {}, 'Show more'));

      
        main.appendChild(currCard);

        const div = document.getElementById(`${username}HiddenFields`);
        div.style.display = 'none';

 
    });

    const btns = [...document.getElementsByTagName('button')];

    btns.forEach(btn => btn.addEventListener('click', showHide));


}

function showHide(event) {
    const button = event.target;
    const profile = button.parentNode;
    const moreInformation = profile.getElementsByTagName('div')[0];
  
    
    const lockStatus = profile.querySelector('input[type="radio"]:checked').value;

    if (lockStatus === 'unlock') {
        if (button.textContent === 'Show more') {
            moreInformation.style.display = 'inline-block';
            button.textContent = 'Hide it';
        } else if (button.textContent === 'Hide it') {
            moreInformation.style.display = 'none';
            button.textContent = 'Show more';
        }
    }
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