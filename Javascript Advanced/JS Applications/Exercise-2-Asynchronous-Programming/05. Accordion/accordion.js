function solution() {
    const section = document.querySelector('#main');
    let url = 'http://localhost:3030/jsonstore/advanced/articles/list';

    async function solve() {
        let resposne = await fetch(url);
        let data = await resposne.json();
        data.forEach(x => {
            section.appendChild(createDiv(x.title, x._id));

        });
    }
    async function click(e) {
        let div = e.target.parentElement.parentElement;
        let extra = div.querySelector('.extra');
        let p = div.querySelector('p');

        if (p.textContent == false) {
            let url = `http://localhost:3030/jsonstore/advanced/articles/details/${e.target.id}`;
            let resposne = await fetch(url);
            let data = await resposne.json();
            p.textContent = data.content;
        }

        if (extra.style.display == 'block') {
            extra.style.display = 'none';
            e.target.textContent = 'MORE';
        } else {
            extra.style.display = 'block';
            e.target.textContent = 'LESS';
        }
    }

    function createDiv(name, id) {
        let result =
            el('div', null, { class: 'accordion' },
                el('div', null, { class: 'head' },
                    el('sapn', name),
                    el('button', 'More', { id: id, class: 'button' })
                ),
                el('div', null, { class: 'extra' },
                    el('p', null, {})
                )
            )
        result.querySelector('.button').addEventListener('click', click);
        return result;
    }

    solve();
    function el(type = '', content = '', attributesObj = {}, ...nestedElements) {
        let result = document.createElement(type);

        if (content === 0 || content) {
            result.textContent = content;
        }

        if (attributesObj) {
            for (const key in attributesObj) {
                if (key === 'class') {
                    if (Array.isArray(attributesObj[key])) {
                        result.classList.add(...attributesObj[key]);
                    } else {
                        result.classList.add(attributesObj[key]);
                    }
                } else {
                    result.setAttribute(key, attributesObj[key]);
                }
            }
        }

        if (nestedElements) {
            nestedElements.forEach(x => result.appendChild(x));
        }
        return result;
    }
}
solution()