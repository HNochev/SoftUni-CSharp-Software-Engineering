function fromJSONToHTMLTable(input) {
    //Write your code here
    const escaper = (str) => {
      if (typeof str !== 'string') {
        return str
      } else {
        str = str.replace(/&/g, "&amp;")
        str = str.replace(/</g, "&lt;")
        str = str.replace(/>/g, "&gt;")
        str = str.replace(/"/g, "&quot;")
        str = str.replace(/'/g, "&#39;");
      }
      return str
    }
  
  
    //input = input.shift()
    //input = escaper(input)
    input = JSON.parse(input);
    let row = `<table>\n`;
    row += "\t<tr>";
    let keys = Object.keys(input[0]);
    keys.map((el) => row += `<th>${el}</th>`)
    row += `</tr>\n`;
    input.map((line) => {
      row += `\t<tr>`;
      Object.entries(line).map((el) => {
        if (keys.includes(el[0])) {
          row += `<td>${escaper(el[1])}</td>`;
        }
      })
      row += `</tr>\n`;
    })
    row += `</table>\n`;
    //console.log(row);
    return row;
  }