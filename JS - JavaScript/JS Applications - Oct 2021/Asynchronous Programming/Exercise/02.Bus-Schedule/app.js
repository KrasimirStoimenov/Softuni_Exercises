function solve() {
    const infoBoard = document.querySelector('#info');
    const departBtn = document.querySelector('#depart');
    const arriveBtn = document.querySelector('#arrive');
    let currentStop = 'depot';
    async function depart() {
        try {
            const res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentStop}`);
            if (res.status != 200) {
                throw new Error(`${res.status}:${res.statusText}`);
            }
            const data = await res.json();
            infoBoard.textContent = `Next stop ${data.name}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        } catch (error) {
            infoBoard.textContent = 'Error';
            departBtn.disabled = true;
        }

    }

    async function arrive() {
        try {
            const res = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentStop}`);
            if (res.status != 200) {
                throw new Error(`${res.status}:${res.statusText}`);
            }
            const data = await res.json();
            infoBoard.textContent = `Arriving at ${data.name}`;
            currentStop = data.next;
            departBtn.disabled = false;
            arriveBtn.disabled = true;
        } catch (error) {
            infoBoard.textContent = 'Error';
            arriveBtn.disabled = true;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();