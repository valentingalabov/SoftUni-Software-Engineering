async function getInfo() {
    const busId = document.getElementById('stopId');

    const url = `http://localhost:3030/jsonstore/bus/businfo/${busId.value}`;

    try {
        const ulElement = document.getElementById('buses');
        ulElement.innerHTML = '';
        const respons = await fetch(url);
        const data = await respons.json();


        document.getElementById('stopName').textContent = data.name;
    

        Object.entries(data.buses).map(([bus, time]) => {
            const result = document.createElement('li');
            result.textContent = `Bus ${bus} arrives in ${time} minutes`;
            ulElement.appendChild(result);
        });

        busId.value = '';

    } catch (error) {
        document.getElementById('stopName').textContent = 'Error';
        busId.value = '';
    }

}

