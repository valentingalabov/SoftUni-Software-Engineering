function solve(num1, num2) {
    while(num2) {
        var t = num2;
        num2 = num1 % num2;
        num1 = t;
      }
      return num1;
}

console.log(solve(15, 5));
console.log(solve(2154, 458));
