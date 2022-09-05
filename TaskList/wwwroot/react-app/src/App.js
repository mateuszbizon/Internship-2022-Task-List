import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainPage from "./routes/Index/MainPage";
import LoginPage from "./routes/Login/LoginPage";
import RegisterPage from "./routes/register/RegisterPage";
import WeatherPage from "./routes/Weather/Weather";
import Error404Page from "./routes/error404/error404Page";

function App() {
	return (
		<Router>
			<Routes>
				<Route path='/' element={<MainPage />} />
				<Route path='/login' element={<LoginPage />} />
				<Route path='/register' element={<RegisterPage />} />
				<Route path='/weather' element={<WeatherPage />} />
				<Route path='*' element={<Error404Page />} />
			</Routes>
		</Router>
	);
}

export default App;
