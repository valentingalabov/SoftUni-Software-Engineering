function solve(matrix) {
let mainDiag = 0;
let secDiag = 0;

    for (let row = 0; row < matrix.length; row++) {
        mainDiag += matrix[row][row];
        secDiag += matrix[row][matrix.length - row - 1];
}

return mainDiag + ' ' + secDiag;
}

console.log(solve([[20, 40],
                   [10, 60]]));

                 
console.log(solve([[3, 5, 17],
                   [-1, 7, 14],
                   [1, -8, 89]]));