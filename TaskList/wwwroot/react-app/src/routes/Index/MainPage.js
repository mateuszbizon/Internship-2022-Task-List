import React from "react";
import { Navbar } from "../../components/Navbar";
import '../../sass/css/main.css';

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
