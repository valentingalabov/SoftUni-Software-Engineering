function solve(matrix) {
let maxNum= Number.NEGATIVE_INFINITY;
for (let i = 0; i < matrix.length; i++) {
    for (let l = 0; l < matrix[i].length; l++) {
        if (matrix[i][l] > maxNum) {
            maxNum = matrix[i][l];
        }  
    }   
}

return maxNum;
}

console.log(solve([[20, 50, 10],
                    [8, 33, 145]]));

console.log(solve([[3, 5, 7, 12],
                  [-1, 4, 33, 2],
                    [8, 3, 0, 4]]));