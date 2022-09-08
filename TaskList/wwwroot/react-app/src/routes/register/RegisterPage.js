import React, { useState } from 'react'
import axios from 'axios'
import { useFormik } from "formik";
import { registerValid } from "../../Validations/RegisterValid";
import Navbar from "../../components/Navbar";
import '../../sass/css/register.css';

export default function RegisterPage() {
    const [registerMessage, setRegisterMessage] = useState('')

    function onSubmit(){
        console.log("submitted")

        var config = {
			method: "post",
			url: "Index/Register",
			headers: {
				"Content-Type": "application/json"
			},
			data: JSON.stringify({
                "email": formik.values.email,
                "password": formik.values.password,
            })
		};

		axios(config)
			.then(res => {
				setRegisterMessage(res.data.Message)
			})
			.catch(function (error) {
				console.log(error);
			});

            clearInputs();
    }

    function clearInputs(){
		formik.values.email = ''
		formik.values.password = ''
        formik.values.confirmPassword = ''
	}

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            confirmPassword: '',
        },
        validationSchema: registerValid,
        onSubmit
    })

  return (
    <>
    <Navbar />
    <section className="registration">
        <div className="wrapper">
            <form onSubmit={formik.handleSubmit}>
                <h1>Zarejestruj się</h1>
                <div className="form-box">
                    <label htmlFor="email">Adres email: </label>
                    <input type="email" id="email" value={formik.values.email} onChange={formik.handleChange} className={formik.errors.email ? "input-incorrect" : ""} placeholder="Adres email"/>
                    {formik.errors.email ? (<span className="error-text">{formik.errors.email}</span>) : null}
                </div>
                <div className="form-box">
                    <label htmlFor="password">Hasło: </label>
                    <input type="password" id="password" value={formik.values.password} onChange={formik.handleChange} className={formik.errors.password ? "input-incorrect" : ""} placeholder="Hasło"/>
                    {formik.errors.password ? (<span className="error-text">{formik.errors.password}</span>) : null}
                </div>
                <div className="form-box">
                    <label htmlFor="confirm-password">Powtórz hasło: </label>
                    <input type="password" id='confirm-password' name='confirmPassword' value={formik.values.confirmPassword} onChange={formik.handleChange} className={formik.errors.confirmPassword ? "input-incorrect" : ""} placeholder='Powtórz hasło'/>
                    {formik.errors.confirmPassword ? (<span className="error-text">{formik.errors.confirmPassword}</span>) : null}
                </div>
                <button type="submit" className="register-btn">Zarejestruj się</button>
                <p className="send-error">{registerMessage}</p>
            </form>
        </div>
    </section>
    </>
  )
}
