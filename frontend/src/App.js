import logo from './logo.svg';
import './App.css';
import React, { useState, useEffect } from 'react';


function App() {
  const [cities, setCities] = useState([]);

  useEffect(() => {
    // declare the async data fetching function
    const fetchData = async () => {
      // get the data from the api
      const url = `https://citiesef.azurewebsites.net/api/cities`;
      console.log(url);
      const data = await fetch(url);
      // convert the data to jsonnpm start
      const json = await data.json();

      // set state with the result.
      setCities(json);
    }

    // call the function
    fetchData()
      // make sure to catch any error
      .catch(console.error);
  }, [])


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit !!!!<code>src/App.js</code> and save to reload.!!!
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <h1>My Cities</h1>
        <ul>
          {cities.map(city =>
            <li key={city.id}>
              {city.name}
            </li>
          )}
        </ul>
      </header>
    </div>
  );
}

export default App;
