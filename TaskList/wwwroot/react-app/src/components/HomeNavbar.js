import React, { useRef } from 'react'
import "../sass/css/navbar.css";

function HomeNavbar() {
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
                <a href='/home'>Strona domowa</a>
            </li>
            <li>
                <a href='/weather'>Sprawdź pogodę</a>
            </li>
            <li>
                <a href='/'>Wyloguj się</a>
            </li>
        </ul>
        <button className='burger' ref={burgerBtnRef} onClick={showNavbar}>
            <div className='line'></div>
            <div className='line'></div>
            <div className='line'></div>
        </button>
    </nav>
  )
}

export default HomeNavbar