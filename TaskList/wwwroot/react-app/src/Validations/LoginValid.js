import * as yup from "yup"

const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

export const loginValid = yup.object().shape({
    email: yup.string().matches(emailRegex, "Nieprawidłowy email").required("Email nie może byc pusty"),
    password: yup.string().required("Hasło nie może być puste")
})