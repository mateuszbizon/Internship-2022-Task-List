import React, { useState} from 'react';
import '../../sass/css/weather.css';
import HomeNavbar from "../../components/HomeNavbar";

const data = {
    key: "c875cbbe45dc9b365cf478e4074bde63",
    url: "https://api.openweathermap.org/data/2.5/"
}

function Weather() {
    const [searchValue, setSearchValue] = useState('');
    const [weather, setWeather] = useState({});

    const search = e =>{
        if(e.key === "Enter"){
            fetch(`${data.url}weather?q=${searchValue}&units=metric&lang=pl&appid=${data.key}`)
            .then(res => res.json())
            .then(result =>{
                setWeather(result);
                setSearchValue('');
                console.log(result);
            })
        }
    }

    const dateBuilder = d =>{
        let days = ["Niedziela", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota"];
        let months = ["Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpien", "Wrzesień", "Październik", "Listopad", "Grudzień"];

        let day = days[d.getDay()];
        let date = d.getDate();
        let month = months[d.getMonth()];
        let year = d.getFullYear();

        return `${day}, ${date} ${month} ${year}`
    }

  return (
    <>
        <HomeNavbar />
        <section className='check-weather'>
            <div className='shadow'></div>
            <input type='text' className='search-input' value={searchValue} onChange={e => setSearchValue(e.target.value)} onKeyPress={search} placeholder='Sprawdź pogodę wyszukując po nazwie miasta' />
            {(typeof weather.main != "undefined") ? (
                <div>
                    <div className='location-box'>
                        <div className='location'>{weather.name}, {weather.sys.country}</div>
                        <div className='date'>{dateBuilder(new Date())}</div>
                    </div>

                    <div className='weather-box'>
                        <div className='temperature'>{Math.round(weather.main.temp)}° C</div>
                        <div className='weather'>{weather.weather[0].description}</div>
                    </div>
                </div>
            ) : ('')}
        </section>
    </>
  )
}

export default Weather