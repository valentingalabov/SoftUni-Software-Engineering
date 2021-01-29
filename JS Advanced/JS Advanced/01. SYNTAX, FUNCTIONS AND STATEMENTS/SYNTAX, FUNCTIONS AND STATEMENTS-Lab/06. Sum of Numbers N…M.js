function solve(n, m) {
    let num1 = Number(n);
    let num2 = Number(m);
    let sum = 0;

    for (let index = num1; index <= num2; index++) {

        sum += index;
    }
    return sum
   
}

console.log(solve('1', '5'));
console.log(solve('-8', '20'));