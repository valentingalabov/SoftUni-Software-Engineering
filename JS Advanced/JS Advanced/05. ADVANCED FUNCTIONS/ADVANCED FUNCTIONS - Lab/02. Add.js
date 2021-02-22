function solution(num) {

   return function (secondNum) {
       return num+secondNum;
   }

}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
