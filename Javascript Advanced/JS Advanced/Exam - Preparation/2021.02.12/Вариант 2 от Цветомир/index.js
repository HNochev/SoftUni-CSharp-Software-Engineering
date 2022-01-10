function solve() {
    let addBtn = document.querySelector('.form-control > button');
    addBtn.addEventListener('click', addToTrainings);
    let state = {};

    function addToTrainings(e) {
        e.preventDefault();

        const lectureName = document.querySelector('input[name="lecture-name"]').value;
        const date = document.querySelector('input[name="lecture-date"]').value;
        const module = document.querySelector('select[name="lecture-module"]').value;

        const displayModules = document.querySelector('div[class="modules"]');

        //use this regex instead of let modifiedDate = date.replaceAll('-', '/');
        //bacause judge gives 12/100 instead
        //had to learn it in the hard way. 
        let modifiedDate = date.replace(/-/g, '/');
        modifiedDate = modifiedDate.replace('T', ' - ');


        if (lectureName == '' || date == '' || module.includes('Select')) {
            return;
        }
        const div = el('div', undefined, 'module');
        const h3 = el('h3', `${module.toUpperCase()}-MODULE`);
        const ul = el('ul');

        if (!state.hasOwnProperty(module)) {

            const li = el('li', undefined, 'flex');
            const h4 = el('h4', `${lectureName} - ${modifiedDate}`);
            const delButton = el('button', 'Del', 'red');
            delButton.addEventListener('click', delLi);

            li.appendChild(h4);
            li.appendChild(delButton);
            ul.appendChild(li);
            div.appendChild(h3);
            div.appendChild(ul);
            displayModules.appendChild(div);

            state[module] = [];
            state[module].push({ li, date });
        } else {
            let modulesArr = Array.from(displayModules.querySelectorAll('h3'));

            const li = el('li', undefined, 'flex');
            const h4 = el('h4', `${lectureName} - ${modifiedDate}`);
            const delButton = el('button', 'Del', 'red');
            delButton.addEventListener('click', delLi);

            li.appendChild(h4);
            li.appendChild(delButton);

            let ul;
            modulesArr.forEach((elem) => {
                if (elem.textContent == `${module.toUpperCase()}-MODULE`) {
                    ul = elem.parentNode.querySelector('ul');
                    ul.appendChild(li);
                }
            });

            state[module].push({ li, date });
            let sorted = Object.values(state[module]).sort((a, b) => a.date.localeCompare(b.date));
            sorted.forEach((lis) => {
                ul.appendChild(lis.li);
            });
        }

        function delLi(e) {
            let li = e.target.parentNode;
            let ul = e.target.parentNode.parentNode;

            li.remove();
            if (ul.children.length == 0) {
                ul.parentNode.remove();
                delete state[module];
            }
        }


        function el(type, content, addClass) {
            let result = document.createElement(type);
            result.textContent = content;

            if (addClass) {
                result.className = addClass;
            }
            return result;
        }
    }
};