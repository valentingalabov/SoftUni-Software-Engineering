function solve(inputArr, num) {
for (let i = 0; i < num; i++) {
    let temp = inputArr.pop();
    inputArr.unshift(temp);   
}

return inputArr.join(' ');
}

console.log(solve(['1', 
'2', 
'3', 
'4'], 
2
));

console.log(solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15

));