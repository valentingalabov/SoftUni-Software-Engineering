function solve(inputArray) {
let firsElement = Number(inputArray[0]);
let secondElement = Number(inputArray[inputArray.length - 1]);

return firsElement + secondElement;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));