function attachEvents() {
    let getWeatherButton = document.querySelector('#submit');
    getWeatherButton.addEventListener('click', getweatherHandler);
    let locationinput = document.querySelector('#location');

    let conditions = {
        Sunny: () => '☀',
        "Partly sunny": () => '⛅',
        Overcast: () => '☁',
        Rain: () => '☂'
    }

    function getweatherHandler() {
        let forecastContainer = document.querySelector('#forecast');

        let currentForecastContainer = document.querySelector('#current');
        Array.from(currentForecastContainer.querySelectorAll('div')).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        })

        let upcomingForecastContainer = document.querySelector('#upcoming');
        Array.from(upcomingForecastContainer.querySelectorAll('div')).forEach((el, i) => {
            i !== 0 ? el.remove() : el;
        })

        fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then(body => body.json())
            .then(locations => {
                let locationName = locationinput.value;
                let location = locations.find(x => x.name === locationName);

                let curPromise = fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
                    .then(body => body.json())
                    .then(currentWeatherReport => ({ code: location.code, currentWeatherReport }))
                    .then(({ code, currentWeatherReport }) => {
                        let htmlReport = createCurrentWeatherElement(currentWeatherReport);
                        currentForecastContainer.appendChild(htmlReport);
                    });

                let upcomingPromise = fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)
                    .then(x => x.json())
                    .then(upcommingWeatherReport => {
                        console.log(upcommingWeatherReport);
                        let upcomingForecast = createUpcomingWeatherElement(upcommingWeatherReport);
                        upcomingForecastContainer.appendChild(upcomingForecast);
                    });

                Promise.all([curPromise, upcomingPromise]).then(x => {
                    forecastContainer.style.display = 'block';
                });
            })
            .catch(err => {
                let errorDiv = document.createElement('div');
                errorDiv.classList.add('label');
                errorDiv.textContent = 'Error';
                currentForecastContainer.appendChild(errorDiv);
            });

        function createUpcomingWeatherElement(weatherReport) {
            let forecastInfoDiv = document.createElement('div');
            forecastInfoDiv.classList.add('forecast-info');

            let day1Html = createDayReport(weatherReport.forecast[0]);
            let day2Html = createDayReport(weatherReport.forecast[1]);
            let day3Html = createDayReport(weatherReport.forecast[2]);

            forecastInfoDiv.appendChild(day1Html);
            forecastInfoDiv.appendChild(day2Html);
            forecastInfoDiv.appendChild(day3Html);

            return forecastInfoDiv;
        }

        function createDayReport(forecast) {
            let upcomingSpan = document.createElement('span');
            upcomingSpan.classList.add('upcoming');
 
            let symbolSpan = document.createElement('span');
            symbolSpan.classList.add('symbol');
            symbolSpan.textContent = conditions[forecast.condition]();
 
            let tempSpan = document.createElement('span');
            tempSpan.classList.add('forecast-data');
            tempSpan.textContent = `${forecast.low}°/${forecast.high}°`;
 
            let weatherSpan = document.createElement('span');
            weatherSpan.classList.add('forecast-data');
            weatherSpan.textContent = forecast.condition;
 
            upcomingSpan.appendChild(symbolSpan);
            upcomingSpan.appendChild(tempSpan);
            upcomingSpan.appendChild(weatherSpan);
            return upcomingSpan;
        }
 
        function createCurrentWeatherElement(weatherReport) {
            let forecastsDiv = document.createElement('div');
            forecastsDiv.classList.add('forecasts');
 
            let conditionSymbolSpan = document.createElement('span');
            conditionSymbolSpan.classList.add('condition', 'symbol');
            conditionSymbolSpan.textContent = conditions[weatherReport.forecast.condition]();
 
            let conditionSpan = document.createElement('span');
            conditionSpan.classList.add('condition');
 
            let nameSpan = document.createElement('span');
            nameSpan.classList.add('forecast-data');
            nameSpan.textContent = weatherReport.name;
 
            let tempSpan = document.createElement('span');
            tempSpan.classList.add('forecast-data');
            tempSpan.textContent = `${weatherReport.forecast.low}°/${weatherReport.forecast.high}°`;
 
            let weatherSpan = document.createElement('span');
            weatherSpan.classList.add('forecast-data');
            weatherSpan.textContent = weatherReport.forecast.condition;
 
            conditionSpan.appendChild(nameSpan);
            conditionSpan.appendChild(tempSpan);
            conditionSpan.appendChild(weatherSpan);
 
            forecastsDiv.appendChild(conditionSymbolSpan);
            forecastsDiv.appendChild(conditionSpan);
            return forecastsDiv;
        }
    }
}

attachEvents();