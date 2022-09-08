import React from "react";
import Navbar from "../../components/Navbar";
import '../../sass/css/main.css';

export default function MainPage() {
	return (
		<>
			<Navbar />
			<header>
				<div className='shadow'></div>
				<div className='header-text'>
					<h1>Witaj na praktykach w Sharply</h1>
					<p>
						W miejscu gdzie stworzysz Task<span className='blue-text'>Liste</span>
					</p>
				</div>
			</header>
		</>
	);
}
