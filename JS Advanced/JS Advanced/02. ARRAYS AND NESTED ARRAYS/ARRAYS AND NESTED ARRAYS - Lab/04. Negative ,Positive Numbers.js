function solve(inputArray) {
    const result = [];
    for (const num of inputArray) {
        if (num < 0) {
            result.unshift(num);
        }else {
            result.push(num);
        }
        
    }
       return result.join('\n');
        
    }

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));