function solve (arg1, arg2, arg3) {
const sumOfLength = arg1.length + arg2.length + arg3.length;
const avrLength = Math.floor(sumOfLength / 3);

console.log(sumOfLength);
console.log(avrLength);
}

solve('chocolate', 'ice cream', 'cake');
solve('pasta', '5', '22.3');