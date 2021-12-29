function solve() {

  //1. Select element
  let textElement = document.querySelector('#text');
  let caseElement = document.querySelector('#naming-convention');

  //2. Parse Data
  let text = textElement.value;
  let namingConvention = caseElement.value;

  //3. Main Logic
  let result = applyNamingConvention(text, namingConvention);

  //4. Display result in DOM
  let spanElement = document.getElementById('result');
  spanElement.textContent = result;


  function applyNamingConvention(text, convention) {

    switch (convention) {
      case 'Pascal Case':
        {
          return text
            .toLowerCase()
            .split(' ')
            .map(x => x.charAt(0).toUpperCase() + x.slice(1))
            .join('');
        }
      case 'Camel Case':
        {
          return text
            .toLowerCase()
            .split(' ')
            .map((x, i) => x = i !== 0 ? x.charAt(0).toUpperCase() + x.slice(1) : x)
            .join('');
        }
      default:
        return 'Error!';
    }
    /*  const conventionSwitch = {
        'Pascal Case': () => text
          .toLowerCase()
          .split(' ')
          .map(x => x.charAt(0).toUpperCase() + x.slice(1))
          .join(''),
        'Camel Case': () => text
          .toLowerCase()
          .split(' ')
          .map((x, i) => x = i !== 0 ? x.charAt(0).toUpperCase() + x.slice(1) : x)
          .join(''),
        default: () => 'Error!'
      };
  
      return (conventionSwitch[convention] || conventionSwitch.default)();            */
  }
}