function solve(inputArray) {
let sortedArray = inputArray.sort(function(a, b) {
    return a - b;
});

let [minVal,secondVal] = sortedArray;

return minVal + ' ' + secondVal;

}

console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));