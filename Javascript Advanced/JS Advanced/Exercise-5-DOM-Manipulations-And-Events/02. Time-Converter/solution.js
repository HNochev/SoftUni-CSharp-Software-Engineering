function attachEventsListeners() {
    let daysBtn = document.getElementById('daysBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let secondsBtn = document.getElementById('secondsBtn');

    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    daysBtn.addEventListener('click', (e) => {
        let days = Number(daysInput.value);
        hoursInput.value = days * 24;
        minutesInput.value = days * 24 * 60;
        secondsInput.value = days * 24 * 60 * 60;
    });

    hoursBtn.addEventListener('click', (e) => {
        let hours = Number(hoursInput.value);
        daysInput.value = hours / 24;
        minutesInput.value = hours * 60;
        secondsInput.value = hours * 60 * 60;
    });

    minutesBtn.addEventListener('click', (e) => {
        let minutes = Number(minutesInput.value);
        daysInput.value = minutes / 24 / 60;
        hoursInput.value = minutes / 60;
        secondsInput.value = minutes * 60;
    });

    secondsBtn.addEventListener('click', (e) => {
        let seconds = Number(secondsInput.value);
        daysInput.value = seconds / 24 / 60 / 60;
        hoursInput.value = seconds / 60 / 60;
        minutesInput.value = seconds / 60;
    });
}