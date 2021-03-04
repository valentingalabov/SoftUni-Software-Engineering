function validate() {
 
    let isCheked = false;
    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirm-password');
    const email = document.getElementById('email');
    const companyCheck = document.getElementById('company');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');


    const submit = document.getElementById('submit');
    const validationDiv = document.getElementById('valid');

    const usernamePattern = /^[A-Za-z0-9]{3,20}$/gm;
    const passwordPattern = /^[\w]{5,15}$/gm;
    const emailPattern = /^.*@.*\..*$/gm;
    const companyNumberPatern = /^[1-9][0-9]{3}$/gm;

    companyCheck.addEventListener('change', () => {
        if (companyCheck.checked == true) {
            companyInfo.style.display = '';
            isCheked = true;
        } else {
            companyInfo.style.display = 'none';
            isCheked = false;
        }
    });
  


    submit.addEventListener('click', (e) => {
        e.preventDefault();
        let isValid = true;

        if (!usernamePattern.test(username.value)) {

            username.style.borderColor = 'red';
            isValid = false;

        } else {
            username.style.border = 'none';


        }

        if (!passwordPattern.test(password.value)) {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';
            isValid = false;
        } else {
            if (confirmPassword.value !== password.value) {
                confirmPassword.style.borderColor = 'red';
                password.style.borderColor = 'red';
                isValid = false;
            } else {
                password.style.border = 'none';
                confirmPassword.style.border = 'none';
    
            }

        }

        

        if (!emailPattern.test(email.value)) {
            email.style.borderColor = 'red';
            isValid = false;
        } else {
            email.style.border = 'none';

        }
        



        if (isCheked) {
            
            if (!companyNumberPatern.test(companyNumber.value)) {
                companyNumber.style.borderColor = 'red';
                isValid = false;
            } else {
                companyNumber.style.border = 'none';
            }
        }


        if (isValid) {
            validationDiv.style.display = '';

        }
    });






}
