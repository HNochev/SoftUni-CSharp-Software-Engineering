window.addEventListener('load', solution);

function solution() {
  let buttonElement = document.querySelector('#submitBTN');

  buttonElement.addEventListener('click', (e) => {
    e.preventDefault();

    let fnameElement = document.querySelector('#fname');
    let emailElement = document.querySelector('#email');
    let phoneElement = document.querySelector('#phone');
    let addressElement = document.querySelector('#address');
    let codeElement = document.querySelector('#code');

    if (!fnameElement.value || !emailElement.value) {
      return;
    }
    buttonElement.disabled = true;

    let editButtonElement = document.querySelector('#editBTN');
    editButtonElement.disabled = false;
    let continueButtonElement = document.querySelector('#continueBTN');
    continueButtonElement.disabled = false;

    let currentInformation = {
      fname: fnameElement.value,
      email: emailElement.value,
      phone: phoneElement.value,
      address: addressElement.value,
      code: codeElement.value
    }

    fnameElement.value = '';
    emailElement.value = '';
    phoneElement.value = '';
    addressElement.value = '';
    codeElement.value = '';


    let ulElement = document.querySelector('#infoPreview');

    let fnameLi = createElement('li', `Full Name: ${currentInformation.fname}`);
    let emailLi = createElement('li', `Email: ${currentInformation.email}`);
    let phoneLi = createElement('li', `Phone Number: ${currentInformation.phone}`);
    let addressLi = createElement('li', `Address: ${currentInformation.address}`);
    let codeLi = createElement('li', `Postal Code: ${currentInformation.code}`);


    ulElement.appendChild(fnameLi);
    ulElement.appendChild(emailLi);
    ulElement.appendChild(phoneLi);
    ulElement.appendChild(addressLi);
    ulElement.appendChild(codeLi);

    editButtonElement.addEventListener('click', (e) => {
      e.preventDefault();

      editButtonElement.disabled = true;
      continueButtonElement.disabled = true;

      buttonElement.disabled = false;

      fnameElement.value = currentInformation.fname;
      emailElement.value = currentInformation.email;
      phoneElement.value = currentInformation.phone;
      addressElement.value = currentInformation.address;
      codeElement.value = currentInformation.code;

      let listItems = Array.from(document.querySelectorAll('#infoPreview li'));

      for (let item of listItems) {
        item.remove();
      }
    });

    continueButtonElement.addEventListener('click', (e) => {
      e.preventDefault();

      let divBlockElement = document.querySelector('#block');

      while (divBlockElement.firstChild) {
        divBlockElement.removeChild(divBlockElement.firstChild);
      }

      let finalElement = document.createElement('h3');
      finalElement.textContent = 'Thank you for your reservation!';
      divBlockElement.appendChild(finalElement);
    });
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


