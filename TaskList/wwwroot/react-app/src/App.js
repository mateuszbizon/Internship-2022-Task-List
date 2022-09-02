import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainPage from "./routes/Index/MainPage";
import LoginPage from "./routes/Login/LoginPage";
import RegisterPage from "./routes/register/RegisterPage";

function App() {
	return (
		<Router>
			<Routes>
				<Route path='/' element={<MainPage />} />
				<Route path='/login' element={<LoginPage />} />
				<Route path='/register' element={<RegisterPage />} />
			</Routes>
		</Router>
	);
}

export default App;
