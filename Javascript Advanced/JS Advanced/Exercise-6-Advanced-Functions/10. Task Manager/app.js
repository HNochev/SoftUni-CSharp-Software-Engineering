function solve() {
    const addTaskBtn = document.querySelector('#add');
    const sectionsArray = document.querySelectorAll('.wrapper > section');
    const openDiv = sectionsArray[1].querySelector('div:nth-child(2)');
    const inProgressDiv = document.querySelector('#in-progress');
    const completedDiv = sectionsArray[3].querySelector('div:nth-child(2)');
    addTaskBtn.addEventListener('click', addTaskToOpen)

    function addTaskToOpen(e){
        e.preventDefault();
        let task = document.querySelector('#task');
        let description = document.querySelector('#description');
        let date = document.querySelector('#date');
        if(task.value == '' || description.value == '' || date.value == ''){
            return;
        }
        let article = createElement('article');
        let h3 = createElement('h3', task.value);
        let descriptionParagraph = createElement('p',`Description: ${description.value}`);
        let dueDateParagraph = createElement('p',`Due Date: ${date.value}`);
        let div = createElement('div',undefined,'flex');
        let startButton = createElement('button','Start','green');
        let deleteButton = createElement('button','Delete','red');

        startButton.addEventListener('click', startTask);
        deleteButton.addEventListener('click', deleteTask);

        div.appendChild(startButton);
        div.appendChild(deleteButton);
        
        article.appendChild(h3);
        article.appendChild(descriptionParagraph);
        article.appendChild(dueDateParagraph);
        article.appendChild(div);

        task.value = '';
        description.value = '';
        date.value = '';
        openDiv.appendChild(article);

    }
    function startTask(e){
        let targetTask = e.target.parentElement.parentElement;
        e.target.className = 'orange';
        e.target.textContent = 'Finish';
        e.target.removeEventListener('click',startTask);
        e.target.addEventListener('click', finishTask);
        e.target.parentElement.appendChild(e.target);
        inProgressDiv.appendChild(targetTask);
    }
    function finishTask(e){
        let targetTask = e.target.parentElement.parentElement;
        let div = e.target.parentElement;
        div.remove();
        completedDiv.appendChild(targetTask);
    }
    function deleteTask(e){
        e.target.parentElement.parentElement.remove();
    }
    function createElement(type,text,classType){
        let element = document.createElement(type);
        if(text != undefined){
            element.textContent = text;
        }
        if(classType != undefined){
            element.classList.add(classType);
        }
        return element;
    }
}