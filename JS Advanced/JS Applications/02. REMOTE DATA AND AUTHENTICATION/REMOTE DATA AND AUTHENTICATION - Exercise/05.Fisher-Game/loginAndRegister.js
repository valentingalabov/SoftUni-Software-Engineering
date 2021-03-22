const register = document.querySelectorAll('form')[0];

register.addEventListener('submit', (event => {
    event.preventDefault();
    const formData = new FormData(event.target);

    OnSubmitRegister(formData);

}));

const login = document.querySelectorAll('form')[1];

login.addEventListener('submit', (event => {
    event.preventDefault();

    const formData = new FormData(event.target);
    OnSubmitLogin(formData);
}));

async function OnSubmitLogin(formData) {
    const email = formData.get('email');
    const password = formData.get('password');

   
    const body = JSON.stringify({
        email,
        password
    });

    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body
        });


        const data = await response.json();

        if (response.status == 200) {
            sessionStorage.setItem('authToken', data.accessToken);
            sessionStorage.setItem('userId', data._id);
            window.location.pathname = 'index.html';
        }else {
            throw new Error(data.message);
        }

        

    } catch (error) {
        console.log(error.message);
    }



}


async function OnSubmitRegister(formData) {
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (password != rePass) {
        return console.error('Passwords don\'t match!s');
    }

    const body = JSON.stringify({
        email,
        password
    });


    try {

        const response = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body
        });


        const data = await response.json();

        if (response.status == 200) {
            sessionStorage.setItem('authToken', data.accessToken);
            window.location.pathname = 'index.html';
        } else {
            throw new Error(data.message);
        }

    } catch (error) {
        return alert(error.message);
    }
}