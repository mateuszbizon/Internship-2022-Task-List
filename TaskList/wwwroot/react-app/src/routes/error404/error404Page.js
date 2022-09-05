import React from 'react'
import '../../sass/css/error404.css'

function error404Page() {
  return (
    <section className='error'>
        <h1>404</h1>
        <p className='error-title'>Nie znaleziono strony</p>
        <p className='error-text'>Wygląda na to że się zgubiłeś</p>
    </section>
  )
}

export default error404Page