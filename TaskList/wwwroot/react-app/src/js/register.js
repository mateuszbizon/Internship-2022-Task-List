const emailError = document.querySelector('.email-error');
const passwordError = document.querySelector('.password-error');
const confirmPasswordError = document.querySelector('.confirm-password-error');
const errorText = document.querySelector('.error-text');
const sendError = document.querySelector('.send-error');

const emailInput = document.querySelector('#email');
const passwordInput = document.querySelector('#password');
const confirmPasswordInput = document.querySelector('#confirm-password');

const registerForm = document.querySelector('form');

const burgerBtn = document.querySelector('.burger');
const mobileNav = document.querySelector('ul');

let errorMessages = [];

function validateEmail(){
    const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if(emailInput.value == ''){
        emailInput.classList.add("input-incorrect");
        emailError.textContent = 'Email nie może być pusty';
        return false;
    }

    if(!emailInput.value.match(emailRegex)){
        emailInput.classList.add("input-incorrect");
        emailError.textContent = 'Nieprawidłowy email';
        return false;
    }

    emailInput.classList.remove("input-incorrect");
    emailInput.classList.add("input-correct");
    emailError.textContent = '';
    return true;
}

function validatePassword(){
    const passwordRegex = /[A-Z]/g;

    if(passwordInput.value == ''){
        passwordInput.classList.add("input-incorrect");
        passwordError.textContent = 'Hasło nie może być puste';
        return false;
    }

    if(passwordInput.value.length < 6){
        passwordInput.classList.add("input-incorrect");
        passwordError.textContent = 'Hasło musi zawierac co najmniej 6 znaków';
        return false;
    }

    if(!passwordInput.value.match(passwordRegex)){
        passwordInput.classList.add("input-incorrect");
        passwordError.textContent = 'Hasło musi zawierac co najmniej jedna litere';
        return false;
    }


    passwordInput.classList.remove("input-incorrect");
    passwordInput.classList.add("input-correct");
    passwordError.textContent = '';
    return true;
}

function validateConfirmPassword(){
    if(confirmPasswordInput.value !== passwordInput.value){
        confirmPasswordInput.classList.add("input-incorrect");
        confirmPasswordError.textContent = 'Hasła muszą być takie same';
        return false;
    }

    confirmPasswordInput.classList.remove("input-incorrect");
    confirmPasswordInput.classList.add("input-correct");
    confirmPasswordError.textContent = '';
    return true;
}

function clickOnBurgerIcon(){
    mobileNav.classList.toggle('active');
    burgerBtn.classList.toggle('active');
}

burgerBtn.addEventListener('click', clickOnBurgerIcon);

emailInput.addEventListener("input", validateEmail);
passwordInput.addEventListener("input", validatePassword);
confirmPasswordInput.addEventListener("input", validateConfirmPassword);

registerForm.addEventListener("submit", (e) => {
    if(!validateEmail() || !validatePassword() || !validateConfirmPassword()){
        e.preventDefault();
        sendError.textContent = 'Wypelnij formularz poprawnie';
        setTimeout(() =>{
            sendError.textContent = '';
        }, 4000)
    }
})
