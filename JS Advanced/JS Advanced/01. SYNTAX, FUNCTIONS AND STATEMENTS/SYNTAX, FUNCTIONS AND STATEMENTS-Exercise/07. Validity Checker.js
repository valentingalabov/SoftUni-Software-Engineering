function solve(x1, y1, x2, y2) {


    return `{${x1}, ${y1}} to {0, 0} is ${GetResults(x1, y1, 0, 0)}\n` + 
    `{${x2}, ${y2}} to {0, 0} is ${GetResults(x2, y2, 0, 0)}\n` +
    `{${x1}, ${y1}} to {${x2}, ${y2}} is ${GetResults(x1, y1, x2, y2)}`;

    function GetResults(x1, y1, x2, y2){
        const distance = Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);


        return Number.isInteger(distance) ? 'valid' : 'invalid';
    }
}

console.log(solve(3, 0, 0, 4));
console.log(solve(2, 1, 1, 1));