function solve(inputArray) {
const result = [];

for (let i = 0; i < inputArray.length; i++) {
    let elem = inputArray[i];
   if (elem >= result[result.length - 1] || result.length === 0) {
       result.push(elem);
   }
}

return result;
}

function solve1(arr) {

return arr.reduce(function (result, currentValue, index, initialArr) {
    if (currentValue >= result[result.length - 1] || result.length === 0) {
     result.push(currentValue);
    }

    return result;
}, []);
}


console.log(solve1([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ));

    
console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ));

