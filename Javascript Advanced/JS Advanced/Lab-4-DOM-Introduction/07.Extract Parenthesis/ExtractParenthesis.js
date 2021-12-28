function extract(content) {

    let paragraphElement = document.getElementById('content').textContent;
    
    //let text = content;

    let regex = RegExp(/\(([A-z ]+)\)/gm);
    let match = regex.exec(paragraphElement);

    let result = [];

    while (match != null) {
        result.push(match[1]);
        match = regex.exec(paragraphElement);
    }

    return result.join(', ');
}

//let result = extract('The Rose Valley (Bulgaria) is located just south of the Balkan Mountains (Kazanlak).The most common oil - bearing rose found in the valley is the pink - petaled Damask rose(Rosa damascena Mill).');

//console.log(result);