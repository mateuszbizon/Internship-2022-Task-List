const burgerBtn = document.querySelector('.burger');
const mobileNav = document.querySelector('ul');

function clickOnBurgerIcon(){
    mobileNav.classList.toggle('active');
    burgerBtn.classList.toggle('active');
}

burgerBtn.addEventListener("click", clickOnBurgerIcon);