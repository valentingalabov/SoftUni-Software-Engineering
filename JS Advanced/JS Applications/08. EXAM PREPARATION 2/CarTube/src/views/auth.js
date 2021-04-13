import { html } from '../../node_modules/lit-html/lit-html.js';
import { login, register } from '../api/data.js'

const loginTemplate = (onSubit) => html`
<section id="login">
    <div class="container">
        <form @submit=${onSubit} id="login-form">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="/register">Sign up</a>.
            </p>
        </div>
    </div>
</section>`;


const registerTemplate = (onSubit) => html`
<section id="register">
    <div class="container">
        <form @submit=${onSubit} id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="/login">Sign in</a>.
            </p>
        </div>
    </div>
</section>`;


export async function loginPage(ctx) {
    ctx.render(loginTemplate(onSubit));

    async function onSubit(event){
        event.preventDefault();
        const formData = new FormData(event.target);
        const username = formData.get('username');
        const password = formData.get('password');

        await login(username,password);
        event.target.reset();
        ctx.setUserNav();
        ctx.page.redirect('/all-listings');
    }
}

export async function registerPage(ctx) {
    ctx.render(registerTemplate(onSubit));

    async function onSubit(event){
        event.preventDefault();
        const formData = new FormData(event.target);
        const username = formData.get('username');
        const password = formData.get('password');
        const repeatPass = formData.get('repeatPass');

        if (!username, !password) {
            return alert('All fields are required!');
        }
        if (password != repeatPass) {
            return alert('Passwords does not match!');
        }



        await register(username,password);
        event.target.reset();
        ctx.setUserNav();
        ctx.page.redirect('/all-listings');
    }
}