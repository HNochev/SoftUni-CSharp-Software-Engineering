function colorize() {
    let evenRows = document.querySelectorAll('tr:nth-of-type(2n)');

    //nth-of-type(2n-1) - nth-of-type(odd) - odd
    //nth-of-type(2n) - nth-of-type(even) - even

    for (const row of evenRows) {
        row.style.background = 'Teal';
    }
}