function solve(inputArray) {
    inputArray.sort((a, b) => a.length - b.length || a.localeCompare(b));

    return inputArray.join('\n');
}

console.log(solve(
['alpha', 
'beta', 
'gamma']
));

console.log(solve(
    ['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
));

console.log(solve(['test', 
'Deny', 
'omen', 
'Default']
));