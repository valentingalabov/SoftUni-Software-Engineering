function solve(n, k) {
let arr = [];
arr[0] = 1;

for (let i = 1; i < n; i++) {
    let nextElement = 0;
  for (let l = i - k; l < i; l++) {
      if(l >= 0) {
        nextElement += Number(arr[l]);
      }
  }
    arr[i] = nextElement;

}
return arr;

}

console.log(solve(6, 3));
console.log(solve(8, 2));
