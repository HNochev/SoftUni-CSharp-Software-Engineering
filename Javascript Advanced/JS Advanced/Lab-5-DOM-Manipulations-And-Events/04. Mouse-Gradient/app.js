function attachGradientEvents() {
    let gradientBoxElement = document.getElementById('gradient-box');
    let resultElement = document.getElementById('result');

    gradientBoxElement.addEventListener('mousemove', (e) => {
        let percent = Math.floor(((e.offsetX / e.target.clientWidth) * 100));

        resultElement.textContent = `${percent}%`;
    })
}