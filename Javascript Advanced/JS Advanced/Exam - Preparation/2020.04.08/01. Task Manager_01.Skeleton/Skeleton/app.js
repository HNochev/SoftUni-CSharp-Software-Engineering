function solve() {
    let buttonElement = document.querySelector('#add');

    buttonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let taskElement = document.querySelector('#task');
        let descriptionElement = document.querySelector('#description');
        let dateElement = document.querySelector('#date');

        if (!taskElement.value || !descriptionElement.value || !dateElement.value) {
            return;
        }


        let currentTask = {
            taks: taskElement.value,
            description: descriptionElement.value,
            date: dateElement.value,
        }

        taskElement.value = '';
        descriptionElement.value = '';
        dateElement.value = '';

        let articleElement = createElement('article');

        let h3Element = createElement('h3', currentTask.taks);
        let pDescriptionElement = createElement('p', `Description: ${currentTask.description}`);
        let pDateElement = createElement('p', `Due Date: ${currentTask.date}`);

        let divElement = createElement('div', '', 'flex')

        let startButton = createElement('button', 'Start', 'green');
        startButton.addEventListener('click', (e) => {
            let wholeArticleElement = e.target.parentElement.parentElement;

            e.target.parentElement.remove();

            let divElement = createElement('div', '', 'flex')

            let deleteButton = createElement('button', 'Delete', 'red');
            deleteButton.addEventListener('click', (e) => {
                e.target.parentElement.parentElement.remove();
            });

            let finishButton = createElement('button', 'Finish', 'orange');
            finishButton.addEventListener('click', (e) => {
                let wholeArticleElementFOrFinish = e.target.parentElement.parentElement;

                e.target.parentElement.remove();

                let allSections = document.querySelectorAll('section');
                let orangeSection = allSections[3];
                let allDivs = orangeSection.querySelectorAll('div');
                let specificDiv = allDivs[1];
                specificDiv.appendChild(wholeArticleElementFOrFinish);
            });

            divElement.appendChild(deleteButton);
            divElement.appendChild(finishButton);

            wholeArticleElement.appendChild(divElement);

            let allSections = document.querySelectorAll('section');
            let orangeSection = allSections[2];
            let allDivs = orangeSection.querySelectorAll('div');
            let specificDiv = allDivs[1];
            specificDiv.appendChild(wholeArticleElement);
        });
        let deleteButton = createElement('button', 'Delete', 'red');
        deleteButton.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        });

        divElement.appendChild(startButton);
        divElement.appendChild(deleteButton);

        articleElement.appendChild(h3Element);
        articleElement.appendChild(pDescriptionElement);
        articleElement.appendChild(pDateElement);
        articleElement.appendChild(divElement);

        let allSections = document.querySelectorAll('section');
        let orangeSection = allSections[1];
        let allDivs = orangeSection.querySelectorAll('div');
        let specificDiv = allDivs[1];
        specificDiv.appendChild(articleElement);
    });

    function createElement(type, text, attr) {
        let result = document.createElement(type);

        if (text) {
            result.textContent = text;
        }

        if (attr) {
            result.className = attr;
        }
        return result;
    }
}