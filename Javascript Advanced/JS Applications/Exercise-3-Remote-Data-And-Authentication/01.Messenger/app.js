let sendButton = document.querySelector('#submit');
sendButton.addEventListener('click', createMessage);
let refreshButton = document.querySelector('#refresh');
refreshButton.addEventListener('click', getAllMessages);

let textArea = document.querySelector('#messages');

async function getJsonReasource(url){
    let getMessagesResult = await fetch(url);
    let result = await getMessagesResult.json();
    return result;
}

async function getAllMessages(){
    try{
        let url = 'http://localhost:3030/jsonstore/messenger';
        let messages = await getJsonReasource(url);

        let messagesString = Object.values(messages)
        .map(m=> `${m.author}: ${m.content}`)
        .join('\n');

        textArea.value = messagesString;
    }
    catch(error){
        console.error(error);
    }
}

async function createMessage(){
    try {
        let authorInput = document.querySelector('#author');
        let contentInput = document.querySelector('#content');
        let url = 'http://localhost:3030/jsonstore/messenger';

        let newMessage = {
            author: authorInput.value,
            content: contentInput.value
        };

        let createResponse = await fetch(url, {
            headers: {
                'Content-Type':'application/json'
            },
            method: 'Post',
            body: JSON.stringify(newMessage)
        });

        let createResult = await createResponse.json();

        let createMessageString = `${createResult.author}: ${createResult.content}`;
        textArea.value = textArea.value + `\n${createMessageString}`;
    } catch (error) {
        console.error(error);
    }
}