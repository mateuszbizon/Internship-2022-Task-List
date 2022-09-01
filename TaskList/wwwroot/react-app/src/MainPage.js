import React from "react";
import "./sass/index.scss";
import Navbar from "./components/Navbar";

export default function MainPage() {
	return (
		<>
			<Navbar />
			<header>
				<div class='shadow'></div>
				<div class='header-text'>
					<h1>Witaj na praktykach w Sharply</h1>
					<p>
						W miejscu gdzie stworzysz Task<span class='blue-text'>Liste</span>
					</p>
				</div>
			</header>
		</>
	);
}
