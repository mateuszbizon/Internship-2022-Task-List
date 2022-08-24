const emailInput = document.querySelector("#email");
const passwordInput = document.querySelector("#password");

const emailError = document.querySelector('.email-error');
const passwordError = document.querySelector('.password-error');
const sendError = document.querySelector('.send-error');

const loginBtn = document.querySelector('.login-btn');

const loginForm = document.querySelector('form');

const burgerBtn = document.querySelector('.burger');
const mobileNav = document.querySelector('ul');

function validateEmail(){
    const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(emailInput.value == ''){
        emailInput.classList.add('input-incorrect');
        emailError.textContent = "Email nie może być pusty";
        return false;
    }

    if(!emailInput.value.match(emailRegex)){
        emailInput.classList.add('input-incorrect');
        emailError.textContent = "Nieprawidłowy email";
        return false;
    }
    
    emailError.textContent = '';
    emailInput.classList.remove('input-incorrect');
    emailInput.classList.add('input-correct');
    return true;
}

function validatePassword(){
    if(passwordInput.value == ''){
        passwordInput.classList.add('input-incorrect');
        passwordError.textContent = "Hasło nie może byc puste";
        return false;
    }

    passwordError.textContent = '';
    passwordInput.classList.remove('input-incorrect');
    passwordInput.classList.add('input-correct');
    return true;
}

function clickOnBurgerIcon(){
    mobileNav.classList.toggle('active');
    burgerBtn.classList.toggle('active');
}

burgerBtn.addEventListener('click', clickOnBurgerIcon)

emailInput.addEventListener("input", validateEmail);
passwordInput.addEventListener("input", validatePassword);

loginForm.addEventListener("submit", e => {
    if(!validateEmail() || !validatePassword()){
        e.preventDefault();
        sendError.textContent = "Wypełnij pola poprawnie";
        setTimeout( () => {
            sendError.textContent = "";
        }, 4000)
    }
});