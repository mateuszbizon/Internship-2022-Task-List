import React from 'react'
import "./css/index.css";

export default function MainPage() {
  return (
    <>
    <nav>
        <div class="logo">Task<span class="blue-text">List</span></div>
        <ul>
            <li><a href="/">Strona główna</a></li>
            <li><a href="/login">Zaloguj się</a></li>
            <li><a href="/register">Zarejestruj się</a></li>
        </ul>
        <button class="burger">
            <div class="line"></div>
            <div class="line"></div>
            <div class="line"></div>
        </button>
      </nav>
      <header>
      <div class="shadow"></div>
      <div class="header-text">
          <h1>Witaj na praktykach w Sharply</h1>
          <p>W miejscu gdzie stworzysz Task<span class="blue-text">Liste</span></p>
      </div>
      </header>
      <script src="js/main.js"></script>
    </>
  )
}
