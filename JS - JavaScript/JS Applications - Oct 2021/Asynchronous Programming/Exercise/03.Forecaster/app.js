function attachEvents() {
    const getWeatherBtn = document.querySelector('#submit');
    getWeatherBtn.addEventListener('click', displayWeather);
}

async function displayWeather() {

    const weatherSymbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '\&#176'
    };

    const locationValue = document.querySelector('#location').value;
    try {
        const res = await fetch(`http://localhost:3030/jsonstore/forecaster/locations`);
        if (res.status != 200) {
            throw new Error(`${res.status}:${res.statusText}`)
        }
        const data = await res.json();
        const location = data.find(x => x.name == locationValue);

        if (location == undefined) {
            throw new Error('Invalid location');
        }
        document.querySelector('#forecast').style.display = 'block';
        const locationCode = location.code;

        const [current, threeDays] = await Promise.all([
            currentCondition(locationCode),
            threeDayForecast(locationCode)
        ]);

        createCurrentElements(current);
        threeDaysElements(threeDays);
    }
    catch (error) {
        // const errorElement = document.createElement('div');
        // errorElement.classList.add('label');
        // errorElement.textContent = error.message;
        // forecast.style.display = 'inline';
        // forecast.appendChild(errorElement);
        console.log(error.message);
    }

    function createCurrentElements(currentWeather) {
        const currentWeatherCondition = currentWeather.forecast.condition;

        const currentDiv = document.getElementById('current');

        const forecastsDivElement = document.createElement('div');
        forecastsDivElement.classList.add('forecasts');

        const conditionSymbolSpanElement = document.createElement('span');
        conditionSymbolSpanElement.textContent = `${weatherSymbols[currentWeatherCondition]}`;

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');
        conditionSpan.innerHTML = `<span class="forecast-data">${currentWeather.name}</span>
        <span class="forecast-data">${currentWeather.forecast.low}°/${currentWeather.forecast.high}°</span>
        <span class="forecast-data">${currentWeatherCondition}</span>`

        forecastsDivElement.appendChild(conditionSymbolSpanElement);
        forecastsDivElement.appendChild(conditionSpan);

        currentDiv.appendChild(forecastsDivElement);
    }

    function threeDaysElements(threeDays) {
        const days = [...threeDays.forecast];
        const currentDiv = document.getElementById('upcoming');

        const forecastsDivElement = document.createElement('div');
        forecastsDivElement.classList.add('forecast-info');

        for (const day of days) {
            console.log(day);
            const conditionSpan = document.createElement('span');
            conditionSpan.innerHTML = `<span class="symbol">${weatherSymbols[day.condition]}</span>
            <span class="forecast-data">${day.low}°/${day.high}°</span>
            <span class="forecast-data">${day.condition}</span>`

            forecastsDivElement.appendChild(conditionSpan);
        }

        currentDiv.appendChild(forecastsDivElement);
    }

}

async function currentCondition(locationCode) {
    const res = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`);
    const data = await res.json();
    return data;

}

async function threeDayForecast(locationCode) {
    const res = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`);
    const data = await res.json();
    return data;
}

attachEvents();