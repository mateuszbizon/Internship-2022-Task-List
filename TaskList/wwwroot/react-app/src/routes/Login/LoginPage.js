import React from "react";
import axios from "axios";
import { useFormik } from "formik";
import { loginValid } from "../../Validations/LoginValid";
import Navbar from "../../components/Navbar";
import '../../sass/css/login.css';

export default function LoginPage() {
	function onSubmit(values, actions) {
		console.log("submitted");
		var data = JSON.stringify({
			email: values.email,
			password: values.password,
		});

		var config = {
			method: "post",
			url: "https://localhost:7196/Index/Login",
			headers: {
				"Content-Type": "application/json",
			},
			data: data,
		};

		axios(config)
			.then(function (response) {
				console.log(JSON.stringify(response.data));
			})
			.catch(function (error) {
				console.log(error);
			});
	}

	const formik = useFormik({
		initialValues: {
			email: "",
			password: "",
		},
		validationSchema: loginValid,
		onSubmit,
	});
	return (
		<>
			<Navbar />

			<section className='login'>
				<div className='wrapper'>
					<form onSubmit={formik.handleSubmit}>
						<h1>Zaloguj się</h1>
						<div className='form-box'>
							<label htmlFor='email'>Adres email:</label>
							<input
								type='email'
								id='email'
								name='email'
								value={formik.values.email}
								onChange={formik.handleChange}
								className={formik.errors.email ? "input-incorrect" : ""}
								placeholder='Adres email'
							/>
							{formik.errors.email ? (
								<span className='error-text'>{formik.errors.email}</span>
							) : null}
						</div>
						<div className='form-box'>
							<label htmlFor='password'>Hasło:</label>
							<input
								type='password'
								id='password'
								value={formik.values.password}
								onChange={formik.handleChange}
								className={formik.errors.password ? "input-incorrect" : ""}
								placeholder='Hasło'
							/>
							{formik.errors.password ? (
								<span className='error-text'>{formik.errors.password}</span>
							) : null}
						</div>
						<button type='submit' className='login-btn'>
							Zaloguj się
						</button>						
						<p className='send-error'></p>
					</form>
				</div>
			</section>
		</>
	);
}
