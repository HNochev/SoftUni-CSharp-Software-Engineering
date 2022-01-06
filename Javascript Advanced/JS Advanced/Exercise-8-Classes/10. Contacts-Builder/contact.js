class Contact{
    constructor(firstName,lastName,phone,email){
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this._online = false;
    }
    get online(){
        return this._online;
    }
    set online(value){
        this._online = value;
        let div = document.getElementById(this.email);
        if (div !== null){
            this.online == true ? div.className = 'title online' : div.className ='title';
        }
    }
    render(id){
        let parent = document.getElementById(id);
        let article = document.createElement('article');
        let divTitle = document.createElement('div');
        let button = document.createElement('button');
        let divInfo = document.createElement('div');
        let spanPhone = document.createElement('span');
        let spanEmail = document.createElement('span');

        this.online == true ? divTitle.className = 'title online' : divTitle.className = 'title';
        divTitle.textContent = `${this.firstName} ${this.lastName}`;
        divTitle.id = this.email;
        button.textContent = '\u2139'
        button.addEventListener('click',(e) =>{
            let info = e.target.parentElement.nextSibling;
            info.style.display == 'none' ? 
            info.style.display = 'block' : 
            info.style.display = 'none';
        })
        divTitle.appendChild(button);

        divInfo.className = 'info';
        divInfo.style.display = 'none';
        spanPhone.textContent = `\u260E ${this.phone}`; 
        spanEmail.textContent = `\u2709 ${this.email}`;
        
        divInfo.appendChild(spanPhone);
        divInfo.appendChild(spanEmail);
        article.appendChild(divTitle);
        article.appendChild(divInfo);
        parent.appendChild(article);
    }
}