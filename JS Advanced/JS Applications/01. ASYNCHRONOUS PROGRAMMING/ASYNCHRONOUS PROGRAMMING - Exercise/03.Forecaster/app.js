function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}

attachEvents();

async function getWeather() {
    const input = document.getElementById('location');
    const cityName = input.value;

    try {
        const divForecast = document.getElementById('forecast');
        divForecast.style.display = 'none';

        const classForecast = document.getElementsByClassName('current')
        classForecast.innerHTML = '';
   

        const getError = document.querySelectorAll('#error');
        console.log(getError);
        
            getError.forEach(element => {
                element.remove();
            });
        
            
        
        const code = await getCode(cityName);

        const [current, upcoming] = await Promise.all([
            getCurrent(code),
            getUpcomming(code)
        ]);
        const values = Object.values(current);
        const name = values[1];
        const currConditions = values[0];

        divForecast.style.display = 'block';
        const divForecastClass = e('div', { className: 'forecast' },
            e('span', { className: 'condition symbol' }, getSymbol(currConditions['condition'])),
            e('span', { className: 'condition' },
                e('span', { className: 'forecast-data' }, name),
                e('span', { className: 'forecast-data' }, `${currConditions['low']}${'°'}/${currConditions['high']}${'°'}`),
                e('span', { className: 'forecast-data' }, currConditions['condition'])
            )
        );
        const divCurrentId = document.getElementById('current');
        divCurrentId.appendChild(divForecastClass);
        const [key, value] = Object.values(upcoming);
        console.log(key[0]['condition']);


        const divForecastInfo = e('div', { className: 'forecast-info' },);
        key.forEach(k => {
            const current =
                e('span', { className: 'upcoming' },
                    e('span', { className: 'symbol' }, getSymbol(k['condition'])),
                    e('span', { className: 'forecast-data' }, `${k['low']}${'°'}/${k['high']}${'°'}`),
                    e('span', { className: 'forecast-data' }, k['condition']));
            divForecastInfo.appendChild(current);
        });


        const divUpcoming = document.getElementById('upcoming');
        divUpcoming.appendChild(divForecastInfo);

    } catch (error) {
        const request = document.getElementById('request');
        
        const errorMessage = e('h1', { id: 'error', style: 'color:red' }, 'Error!');
        
        request.appendChild(errorMessage);

    }



}

function getSymbol(condition) {
    let result = '';
    switch (condition) {
        case 'Sunny':
            result = '☀';
            break;
        case 'Partly sunny':
            result = '⛅';
            break;
        case 'Overcast':
            result = '☁';
            break;
        case 'Rain':
            result = '☂';
            break;
    }

    return result;
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}



async function getCode(cityName) {
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;

    const response = await fetch(url);
    const data = await response.json();

    return data.find(x => x.name.toLowerCase() == cityName.toLowerCase()).code;

}

async function getCurrent(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

    const response = await fetch(url);
    const data = await response.json();

    return data;

}

async function getUpcomming(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

    const response = await fetch(url);
    const data = await response.json();

    return data;
}