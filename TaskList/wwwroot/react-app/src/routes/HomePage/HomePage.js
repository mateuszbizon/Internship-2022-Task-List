import React from 'react'
import HomeNavbar from '../../components/HomeNavbar'
import '../../sass/css/home.css';

function HomePage() {
  return (
    <> 
        <HomeNavbar />
        <section className='home'>
            <div className='shadow'></div>
            <div className='item'><a href='/home'>Utwórz grupę</a></div>
            <div className='item'><a href='/home'>Utwórz listę zadań</a></div>
            <div className='item'><a href='/home'>Dodaj zadanie</a></div>
        </section>
    </>
  )
}

export default HomePage