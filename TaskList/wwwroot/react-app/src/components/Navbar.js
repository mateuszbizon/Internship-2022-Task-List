import { useRef } from "react";
import "../sass/css/navbar.css";

export function Navbar() {
	const navRef = useRef();
	const burgerBtnRef = useRef();

	function showNavbar() {
		navRef.current.classList.toggle("active");
		burgerBtnRef.current.classList.toggle("active");
	}

	return (
		<nav>
			<div className='logo'>
				Task<span className='blue-text'>List</span>
			</div>
			<ul ref={navRef}>
				<li>
					<a href='/'>Strona główna</a>
				</li>
				<li>
					<a href='/login'>Zaloguj się</a>
				</li>
				<li>
					<a href='/register'>Zarejestruj się</a>
				</li>
			</ul>
			<button className='burger' ref={burgerBtnRef} onClick={showNavbar}>
				<div className='line'></div>
				<div className='line'></div>
				<div className='line'></div>
			</button>
		</nav>
	);
}
