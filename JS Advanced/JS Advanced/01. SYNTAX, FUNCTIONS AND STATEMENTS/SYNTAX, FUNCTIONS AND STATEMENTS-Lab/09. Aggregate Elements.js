function solve(input) {
let arr = input.map(Number);
let sum = 0;
let sumOfInverse = 0;
let asString="";

for (let index = 0; index < arr.length; index++) {
    let currElement = arr[index];
    sum +=currElement;
    sumOfInverse += 1/currElement;
    asString +=currElement; 
}
console.log(sum);
console.log(sumOfInverse);
console.log(asString);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);