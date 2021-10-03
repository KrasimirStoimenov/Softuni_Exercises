function attachGradientEvents() {
    const gradient = document.getElementById('gradient');
    gradient.addEventListener('mousemove', onMove);

    function onMove(e) {
        const box = e.target;
        const offset = Math.floor(e.offsetX / box.clientWidth * 100);

        document.getElementById('result').textContent = offset + '%';
    }
}