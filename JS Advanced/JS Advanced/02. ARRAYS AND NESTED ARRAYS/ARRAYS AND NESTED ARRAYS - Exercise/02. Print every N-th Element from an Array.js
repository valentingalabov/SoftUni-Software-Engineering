function solve(inputArray, num) {
    const result = [];
for (let i = 0; i < inputArray.length; i+=num) {
    result.push(inputArray[i]);
    
}
return result;
}

const solve2 = (arr,num) => arr.filter((elem, i) =>{
    return i % num === 0;
})

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));

console.log(solve2(['5', 
'20', 
'31', 
'4', 
'20'], 
2));