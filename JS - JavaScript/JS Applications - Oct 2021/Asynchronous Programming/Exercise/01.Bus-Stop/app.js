async function getInfo() {
    const stopId = document.querySelector('#stopId').value;
    const stopName = document.querySelector('#stopName');
    const busesUl = document.querySelector('#buses');
    busesUl.replaceChildren();

    try {
        stopName.textContent = 'Loading';
        
        const res = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);
        if (res.status != 200) {
            throw new Error(`${res.status}:${res.statusText}`);
        }

        const data = await res.json();
        stopName.textContent = data.name;

        console.log(data);
        Object.entries(data.buses).forEach(bus => {

            const liElement = document.createElement('li');
            liElement.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`
            busesUl.appendChild(liElement);
        });
    } catch (error) {
        stopName.textContent = 'Error';
    }

}
