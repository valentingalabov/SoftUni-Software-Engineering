function solve(inputArray) {
inputArray.sort((a, b) => a - b);

let result = [];

while (inputArray.length) {
    result.push(inputArray.shift());
    result.push(inputArray.pop())
}

return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));