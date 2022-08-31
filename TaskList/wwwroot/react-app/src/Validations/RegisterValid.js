import * as yup from 'yup'

const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
const passwordRegex = /[A-Z]/g;

export const registerValid = yup.object().shape({
    email: yup.string().matches(emailRegex, "Nieprawidłowy email").required("Email nie może byc pusty"),
    password: yup.string().min(6, "Hasło musi mieć co najmniej 6 znaków").matches(passwordRegex, "Hasło musi mieć co najmniej jedną dużą literę").required("Hasło nie może być puste"),
    confirmPassword: yup.string().oneOf([yup.ref('password'), null], "Hasła muszą być takie same").required("Hasła muszą być takie same")
})