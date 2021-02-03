function solve(inputArray) {
let result = [];

for (let i = 0; i < inputArray.length; i++) {
    if (inputArray[i] == 'add' ) {
        result.push(i + 1);
    }else if (inputArray[i] == 'remove' && result.length > 0) {
        result.pop();
    }   
}

return result.length > 0 ? result.join('\n') :'Empty' ;
}

console.log(solve(['remove', 
'remove', 
'remove']

));

console.log(solve(['add', 
'add', 
'add', 
'add'
));